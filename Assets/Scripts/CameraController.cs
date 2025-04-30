using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float mouseSensivity = 100f; //czu³oœæ myszy
    Transform playerBody; //referencja do naszego gracza, obrót kamery bêdzie obraca³ naszym graczem
    float xRotation = 0; // obrót wzglêdem osi x kamery

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent;
    }

    void Update()
    {
        CameraRotation();
    }

    void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY; //xRotation = xRotation - mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
