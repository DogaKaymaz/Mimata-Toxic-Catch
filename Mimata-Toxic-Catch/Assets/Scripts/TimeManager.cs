using System;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public enum TimeSpeed
    {
        Paused,
        Normal,
        Fast,
        VeryFast
    }

    [Header("Time Settings")]
    public int startYear = 1956;
    public int startMonth = 1;
    public int startDay = 1;
    public int startHour = 6;
    public int startMinute = 0;
    
    [Header("Night Settings")]
    public int nightStartHour = 21;
    public int nightEndHour = 6;    

    public float secondsPerGameMinute = 0.1f; // 0.1 seconds = 1 game minute (in real time)

    private DateTime _currentDateTime;
    private float _minuteTimer = 0f;
    private float _speedMultiplier = 1f;
    private TimeSpeed _currentSpeed = TimeSpeed.Normal;

    void Start()
    {
        _currentDateTime = new DateTime(startYear, startMonth, startDay, startHour, startMinute, 0);
        UpdateSpeedMultiplier();
    }

    private void OnCharacterCreated()
    {
        _currentDateTime = new DateTime(startYear, startMonth, startDay, startHour, startMinute, 0);
        UpdateSpeedMultiplier();
    }

    void Update()
    {
        if (_currentSpeed == TimeSpeed.Paused)
            return;

        _minuteTimer += Time.deltaTime * _speedMultiplier;

        while (_minuteTimer >= secondsPerGameMinute)
        {
            _minuteTimer -= secondsPerGameMinute;
            AdvanceMinute();
        }
    }

    void AdvanceMinute()
    {
        _currentDateTime = _currentDateTime.AddMinutes(1); 
    }

    void UpdateSpeedMultiplier()
    {
        switch (_currentSpeed)
        {
            case TimeSpeed.Paused: _speedMultiplier = 0f; break;
            case TimeSpeed.Normal: _speedMultiplier = 1f; break;
            case TimeSpeed.Fast: _speedMultiplier = 3f; break;
            case TimeSpeed.VeryFast: _speedMultiplier = 10f; break;
        }
    }

    public void SetTimeSpeed(TimeSpeed newSpeed)
    {
        _currentSpeed = newSpeed;
        UpdateSpeedMultiplier();
    }

    public DateTime GetCurrentDateTime()
    {
        return _currentDateTime;
    }
    
    public string GetFormattedTime()
    {
        return _currentDateTime.ToString("HH:mm dd.MM.yyyy");
    }
    
    public bool IsNight()
    {
        int hour = _currentDateTime.Hour;
        // Gece saatleri akşam 20'den sabah 6'ya kadar (örnek)
        return (hour >= nightStartHour || hour < nightEndHour);
    }
}