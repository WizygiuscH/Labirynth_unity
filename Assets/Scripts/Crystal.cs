using UnityEngine;

public class Crystal : Pickup
{
    public int points = 5;
    public override void Picked()
    {
        GameManager.gamemanager.AddPoints(points);
        Destroy(this.gameObject);
    }

    void Update()
    {
        Rotation();
    }
}
