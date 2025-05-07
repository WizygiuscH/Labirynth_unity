using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 12f; // szybkoœæ naszej postaci
    Vector3 velocity; // pos³u¿y do wyliczenia prêdkoœci w dó³
    CharacterController characterController; //komponent character Controller

    public Transform groundCheck;
    public LayerMask groundMask;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
    }


    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        RaycastHit hit; //zmienna w której zapisywana jest referencja do uderzonego obiektu
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 4.0f, groundMask))
        {
            string terrainType;
            terrainType = hit.collider.gameObject.tag; // sprawdzamy tag tego w co uderzyliœmy
        switch (terrainType)
            {
                default: //standardowa prêdkoœæ gdy chodzimy po dowolnym terenie
                    speed = 12;
                    break;
                case "Low": //prêdkoœæ gdy chodzimy po terenie spowalniaj¹cym
                    speed = 3;
                    break;
                case "High": //prêdkoœæ gdy chodzimy po terenie przyspieszaj¹cym
                    speed = 20;
                    break;
            }
        }
    }
}
