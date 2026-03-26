using System;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private ShopkeeperDetectPlayer shopkeeper;

    private bool shopMenuEnabled = false;

    private void Awake()
    {
        player.OnInteractAction += PlayerOnOnInteractAction;
    }

    private void PlayerOnOnInteractAction(object sender, EventArgs e)
    {
        if (shopkeeper.IsPlayerInRange() && !shopMenuEnabled)
        {
            shopMenuEnabled = true;
            shopMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            shopMenuEnabled = false;
            shopMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
