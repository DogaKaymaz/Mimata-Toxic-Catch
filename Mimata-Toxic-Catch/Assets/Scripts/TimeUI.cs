using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI dateText;
        
    [SerializeField] private TimeManager timeManager;

    [SerializeField] private Image night;

    private void Start()
    {
        timeManager.NewDayStarted += OnNewDayStarted;
        timeManager.NewNightStarted += OnNewNightStarted;
    }

    private void OnNewNightStarted()
    {
        night.enabled = true;
    }

    private void OnNewDayStarted()
    {
        night.enabled = false;
    }

    private void Update()
    {
        if (timeManager != null && dateText != null && timeText != null)
        {
            var currentTime = timeManager.GetCurrentDateTime();
            dayText.SetText(currentTime.DayOfWeek.ToString());
            timeText.SetText(currentTime.ToString("HH:mm"));
            dateText.SetText(currentTime.ToString("dd.MM.yyyy"));
        }
    }
}