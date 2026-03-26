using System;
using UnityEngine;

public class ShopkeeperDetectPlayer : MonoBehaviour
{
    private bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    public bool IsPlayerInRange()
    {
        return playerInRange;
    }
    
}
