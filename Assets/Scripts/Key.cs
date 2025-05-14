using UnityEngine;

public class Key : Pickup
{
    public KeyColor color;

    public override void Picked()
    {
        GameManager.gamemanager.AddKey(color);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        Rotation();
    }
}

public enum KeyColor
{
    Red,
    Green,
    Gold
}
