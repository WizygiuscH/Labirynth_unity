using UnityEngine;

public class Clock : Pickup
{
    public bool addTime;
    public uint Time = 5;

    public override void Picked()
    {
        int sign;
        if (addTime)
        {
            sign = 1;
        }
        else
        {
            sign = -1;
        }

        GameManager.gamemanager.AddTime((int)Time*sign);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        Rotation();
    }
}
