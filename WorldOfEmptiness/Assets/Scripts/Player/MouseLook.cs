using UnityEngine;

[System.Serializable]
public class MouseLook
{
    public float Sensitivity = 2f;
    public float MinimumX = -90F;
    public float MaximumX = 90F;

    [Range(1f,15f)]
    public float smoothTime = 5f;

    public Camera camera;

    private Quaternion m_CharacterTargetRot;
    private Quaternion m_CameraTargetRot;

    public void Init(Transform character)
    {
        m_CharacterTargetRot = character.localRotation;
        m_CameraTargetRot = camera.transform.localRotation;
        Bilboard.SetCamera(camera);
    }


    public void LookRotation(Transform character)
    {
        float yRot = Input.GetAxis("Mouse X") * Sensitivity;
        float xRot = Input.GetAxis("Mouse Y") * Sensitivity;

        m_CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
        m_CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

        m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);

        character.localRotation = Quaternion.Slerp(character.localRotation, m_CharacterTargetRot,smoothTime * Time.deltaTime);
        camera.transform.localRotation = Quaternion.Slerp(camera.transform.localRotation, m_CameraTargetRot,smoothTime * Time.deltaTime);

        //camera.localRotation = m_CameraTargetRot;
        //character.localRotation = m_CharacterTargetRot;
        Cursor.lockState = CursorLockMode.Locked;
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
