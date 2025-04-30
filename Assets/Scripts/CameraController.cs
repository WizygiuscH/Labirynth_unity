using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float mouseSens = 100f;
    Transform playerBody;
    float xRotation;
  
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
        float mouseX = Input.GetAxis("MouseX") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("MouseY") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
