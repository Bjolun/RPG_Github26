using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    private int currentHealth = 100;
    private int maxHealth = 150;
    private int currentGold = 100;
    private int strength = 10;

    // Når vi handler med shopkeeperen vår må vi se om vi har nok til � handle eller ikke.
    private bool canBuy;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Health relaterte metoder...
    public int CurrentHealth()
    {
        return currentHealth;
    }
    
    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
    
    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
    }

    // Currency relaterte metoder
    public int CurrentGold() 
    {
        return currentGold;
    }
    
    public bool CanBuyItem(int itemPrice)
    {
        if(currentGold >= itemPrice)
        {   
            // Har råd
            canBuy = true;
            return canBuy;
        } else
        {
            // Har ikke råd
            canBuy = false;
            return canBuy;
        }
    }
    
    public void DecreaseGold(int amount)
    {
        currentGold -= amount;
    }
    
    public void IncreaseGold(int amount)
    {
        currentGold += amount;
    }
    
    // Strength relaterte metoder
    public int CurrentStrength()
    {
        return strength;
    }
    
    public void IncreaseStrength(int amount)
    {
        strength += amount;
    }
}
