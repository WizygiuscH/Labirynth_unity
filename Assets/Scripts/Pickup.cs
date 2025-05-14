using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void Update()
    {
        Rotation();
    }

    public virtual void Picked()
    {
        Debug.Log("PickedUp");
        Destroy(this.gameObject);
    }

    public void Rotation()
    {
        transform.Rotate(new Vector3(0, 0, 0.5f));
    }
}
