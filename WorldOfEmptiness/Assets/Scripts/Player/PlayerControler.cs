using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public MouseLook mouseLook;

    public float speed = 1f;
    public float acceleration = 2.3f;

    private void Awake()
    {
        Bilboard.SetCamera(mouseLook.camera.GetComponentInChildren<Camera>());
        mouseLook.Init(this.transform);
    }

    private void FixedUpdate()
    {
        mouseLook.LookRotation(this.transform);
        Move(SpeedWihtAcceleration(speed,acceleration),GetInput("Horizontal", "Vertical"));
    }

    private void Move(float speed,Vector2 input)
    {
        transform.Translate(new Vector3(input.x * speed,0,input.y * speed));
    }

    private float SpeedWihtAcceleration(float speed, float acceleration)
    {
        float result = ((speed * acceleration + 3f) * Time.fixedDeltaTime) * 2f;
        return result;
    }

    private Vector2 GetInput(string key1, string key2)
    {
        Vector2 input = new Vector2(Input.GetAxis(key1), Input.GetAxis(key2));
        return input;
    }
}
