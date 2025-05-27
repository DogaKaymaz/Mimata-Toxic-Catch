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

    private void Update()
    {
        if (timeManager != null && dateText != null && timeText != null)
        {
            var currentTime = timeManager.GetCurrentDateTime();
            dayText.SetText(currentTime.DayOfWeek.ToString());
            timeText.SetText(currentTime.ToString("HH:mm"));
            dateText.SetText(currentTime.ToString("dd.MM.yyyy"));

            if (timeManager.IsNight() && !night.enabled)
            {
                night.enabled = true;
            }
            else if (!timeManager.IsNight() && night.enabled)
            {
                night.enabled = false;
            }
        }
    }
}