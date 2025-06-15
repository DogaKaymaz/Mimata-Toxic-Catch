using System;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : Singleton<GameManager>
{
    public CharacterMovement mcMovement;
    public Character mc = new Character();   // Main Character
    public Character wife = new Character();
    public Character child = new Character();

    public Inventory inventory;
    private void Start()
    {
        mc.Init();
        wife.Init();
        child.Init();
        mc.OnDied    += OnMCDied;
        wife.OnDied  += OnWifeDied;
        child.OnDied += OnChildDied;
    }

    private void Update()
    {
        float dt = Time.deltaTime;
        mc.Tick(dt);
        wife.Tick(dt);
        child.Tick(dt);
    }

    private void OnMCDied()
    {
        
    }

    private void OnWifeDied()
    {
        
    }
    
    private void OnChildDied()
    {
        
    }
    
    public void FeedMC()
    {
        if (mc.CurrentHunger >= mc.maxHunger) return;

        if (inventory.safeCatch > 0)
        {
            inventory.ConsumeSafeCatch();
            mc.CurrentHunger += inventory.safeCatchHungerBoost;
        }
        else if (inventory.toxicCatch > 0)
        {
            inventory.ConsumeToxicCatch();
            mc.CurrentHunger += inventory.toxicCatchHungerBoost;
            mc.CurrentHealth -= inventory.toxicCatchHealthDecrease;
        }
    }
    public void FeedWife()
    {
        if (wife.CurrentHunger >= wife.maxHunger) return;
        if (inventory.safeCatch > 0)
        {
            inventory.ConsumeSafeCatch();
            wife.CurrentHunger += inventory.safeCatchHungerBoost;
        }
        else if (inventory.toxicCatch > 0)
        {
            inventory.ConsumeToxicCatch();
            wife.CurrentHunger += inventory.toxicCatchHungerBoost;
            wife.CurrentHealth -= inventory.toxicCatchHealthDecrease;
        }
    }
    public void FeedChild()
    {
        if (child.CurrentHunger >= child.maxHunger) return;

        if (inventory.safeCatch > 0)
        {
            inventory.ConsumeSafeCatch();
            child.CurrentHunger += inventory.safeCatchHungerBoost;
        }
        else if (inventory.toxicCatch > 0)
        {
            inventory.ConsumeToxicCatch();
            child.CurrentHunger += inventory.toxicCatchHungerBoost;
            child.CurrentHealth -= inventory.toxicCatchHealthDecrease;
        }
    }
}


[Serializable]
public class Character
{
    public float maxHealth = 100f;
    public float maxHunger = 100f;

    private float currentHealth;
    private float currentHunger;
    
    private bool  isDead = false;    

    public float CurrentHealth
    {
        get => currentHealth;
        set => SetHealth(value);
    }

    public float CurrentHunger
    {
        get => currentHunger;
        set => SetHunger(value);
    }

    public event Action<float> OnHealthChanged;
    public event Action<float> OnHungerChanged;
    public event Action OnDied;    

    private float hungerDecreaseRate = 2f;
    private float healthDecreaseRate = 4f;

    public void Init()
    {
        SetHealth(maxHealth);
        SetHunger(maxHunger);
    }

    public void Tick(float deltaTime)
    {
        if (isDead) return;  
        if (CurrentHunger > 0)
        {
            CurrentHunger -= hungerDecreaseRate * deltaTime;
        }
        else if (CurrentHealth > 0)
        {
            CurrentHealth -= healthDecreaseRate * deltaTime;
        }
    }

    private void SetHealth(float value)
    {
        float newVal = Mathf.Clamp(value, 0, maxHealth);
        if (Mathf.Approximately(newVal, currentHealth)) return;

        currentHealth = newVal;
        OnHealthChanged?.Invoke(currentHealth);

        if (!isDead && currentHealth <= 0f)
        {
            isDead = true;
            OnDied?.Invoke();
        }
    }
    
    private void SetHunger(float value)
    {
        float newVal = Mathf.Clamp(value, 0, maxHunger);
        if (!Mathf.Approximately(currentHunger, newVal))
        {
            currentHunger = newVal;
            OnHungerChanged?.Invoke(currentHunger);
        }
    }
}