using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{

    public Transform player;
    public Transform receiver;
    
    private bool playerIsOverlapping = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIsOverlapping = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }

    void Teleportation()
    {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if (dotProduct < 0f)
            {
                float rotationDif = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDif += 180;
                player.Rotate(Vector3.up, rotationDif);

                Vector3 positionOffest = Quaternion.Euler(0f, rotationDif, 0f) * portalToPlayer;
                player.position = receiver.position + positionOffest;
                playerIsOverlapping = false ;
            }
        }
    }

    private void FixedUpdate()
    {
        Teleportation();
    }

}
