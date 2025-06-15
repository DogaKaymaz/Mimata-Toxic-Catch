using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{
    public int toxicCatch = 0;
    public int safeCatch = 0;
    public int junk = 0;

    public float safeCatchHungerBoost = 15;
    public float toxicCatchHungerBoost = 20;
    public float toxicCatchHealthDecrease = 10;

    public Action<int> ToxicCatchCountChanged;
    public Action<int> SafeCatchCountChanged;
    public Action<int> JunkCountChanged;
    
    public void AddSafeCatch()
    {
        safeCatch++;
        SafeCatchCountChanged?.Invoke(safeCatch);
    }
    public void ConsumeSafeCatch()
    {
        safeCatch--;
        SafeCatchCountChanged?.Invoke(safeCatch);
    }
    public void AddToxicCatch()
    {
        toxicCatch++;
        ToxicCatchCountChanged?.Invoke(toxicCatch);
    }
    public void ConsumeToxicCatch()
    {
        toxicCatch--;
        ToxicCatchCountChanged?.Invoke(toxicCatch);
    }
    public void AddJunk()
    {
        junk++;
        JunkCountChanged?.Invoke(junk);
    }
    public void ConsumeJunk()
    {
        junk--;
        JunkCountChanged?.Invoke(junk);
    }
}