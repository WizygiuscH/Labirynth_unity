using UnityEngine;

public class Freeze : Pickup
{
    public int freezeTime = 10;

    public override void Picked()
    {
        GameManager.gamemanager.FreezeTime(freezeTime);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        Rotation();
    }
}
