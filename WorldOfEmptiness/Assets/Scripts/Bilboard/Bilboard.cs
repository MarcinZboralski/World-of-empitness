using UnityEngine;

public class Bilboard : MonoBehaviour
{
    private static Camera targetCamera;

    public static void SetCamera(Camera camera)
    {
        targetCamera = camera;
    }

    private void Start()
    {
        if (targetCamera == null)
        {
            targetCamera = Camera.main;
        }
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0, targetCamera.transform.rotation.eulerAngles.y, 0);
    }
}
