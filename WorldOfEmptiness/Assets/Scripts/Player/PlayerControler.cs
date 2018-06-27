using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

[RequireComponent(typeof (CharacterController))]
[RequireComponent(typeof (AudioSource))]
public class PlayerControler : MonoBehaviour
{
        [SerializeField] [Range(0.1f,30f)] private float m_WalkSpeed;
        [SerializeField] [Range(0.0f,10f)]private float jumpSpeed;
        [SerializeField] [Range(0.0f,15f)]private float m_StickToGroundForce;
        [SerializeField] [Range(0.0f,10f)]private float m_GravityMultiplier;
        [SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;
        [SerializeField] [Range(0.9f,3f)] private float m_StepInterval;
        [SerializeField] private AudioClip[] m_FootstepSounds;
        [SerializeField] private AudioClip jumpSound;           
        [SerializeField] private AudioClip m_LandSound;    
        [SerializeField] private MouseLook  m_MouseLook;

        private bool jump;
        private Vector2 input;
        private Vector3 moveDir = Vector3.zero;
        private CharacterController characterController;
        private CollisionFlags collisionFlags;
        private bool previouslyGrounded;
        private float stepCycle;
        private float nextStep;
        private bool jumping;
        private AudioSource audioSource;

        
        private void Start()
        {
            characterController = GetComponent<CharacterController>();
            stepCycle = 0f;
            nextStep = stepCycle/2f;
            jumping = false;
            audioSource = GetComponent<AudioSource>();
			m_MouseLook.Init(transform);
        }

        private void Update()
        {
            RotateView();
            if (!jump)
            {
                jump = Input.GetButtonDown("Jump");
            }

            if (!previouslyGrounded && characterController.isGrounded)
            {
                PlayLandingSound();
                moveDir.y = 0f;
                jumping = false;
            }
            if (characterController.isGrounded && !jumping && previouslyGrounded)
            {
               moveDir.y = 0f;
            }

           previouslyGrounded = characterController.isGrounded;
        }


        private void PlayLandingSound()
        {
            audioSource.clip = m_LandSound;
           audioSource.Play();
            nextStep = stepCycle + .5f;
        }


        private void FixedUpdate()
        {
            float speed;
            GetInput(out speed);
            Vector3 desiredMove = transform.forward * input.y + transform.right * input.x;

            RaycastHit hitInfo;
            Physics.SphereCast(transform.position, characterController.radius, Vector3.down, out hitInfo,
            characterController.height/2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
            desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

            moveDir.x = desiredMove.x * speed;
            moveDir.z = desiredMove.z * speed;


            if (characterController.isGrounded)
            {
                moveDir.y = -m_StickToGroundForce;

                if (jump)
                {
                    moveDir.y = jumpSpeed;
                    PlayJumpSound();
                    jump = false;
                    jumping = true;
                }
            }
            else
            {
                moveDir += Physics.gravity*m_GravityMultiplier*Time.fixedDeltaTime;
            }
           collisionFlags = characterController.Move(moveDir*Time.fixedDeltaTime);

            ProgressStepCycle(speed);
        }


        private void PlayJumpSound()
        {
            audioSource.clip = jumpSound;
            audioSource.Play();
        }


        private void ProgressStepCycle(float speed)
        {
            if (characterController.velocity.sqrMagnitude > 0 && (input.x != 0 || input.y != 0))
            {
                stepCycle += (characterController.velocity.magnitude + (speed * m_RunstepLenghten))*Time.fixedDeltaTime;
            }

            if (!(stepCycle > nextStep))
            {
                return;
            }

            nextStep = stepCycle + m_StepInterval;

            PlayFootStepAudio();
        }


        private void PlayFootStepAudio()
        {
            if (!characterController.isGrounded)
            {
                return;
            }

            int n = Random.Range(1, m_FootstepSounds.Length);

            audioSource.clip = m_FootstepSounds[n];
            audioSource.PlayOneShot(audioSource.clip);
            m_FootstepSounds[n] = m_FootstepSounds[0];
            m_FootstepSounds[0] = audioSource.clip;
        }

        private void GetInput(out float speed)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            speed = m_WalkSpeed;
            input = new Vector2(horizontal, vertical);

            if (input.sqrMagnitude > 1)
            {
                input.Normalize();
            }
         }


        private void RotateView()
        {
            m_MouseLook.LookRotation (transform);
        }


        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Rigidbody body = hit.collider.attachedRigidbody;
            if (collisionFlags == CollisionFlags.Below)
            {
                return;
            }

            if (body == null || body.isKinematic)
            {
                return;
            }
            body.AddForceAtPosition(characterController.velocity*0.1f, hit.point, ForceMode.Impulse);
        }
}
