using System;
using UnityEngine;

public class CharacterBehaviour : Singleton<CharacterBehaviour>
{
    public int baitCount = 3;
    public int dailyBait = 3;

    public Action<int> BaitCountChanged;
    private void Start()
    {
        TimeManager.Instance.NewDayStarted += OnNewDayStarted;
    }

    private void OnNewDayStarted()
    {
        AddBaitCount(dailyBait);
    }

    public void AddBaitCount(int amount)
    {
        baitCount += amount;
        BaitCountChanged?.Invoke(baitCount);
    }
}