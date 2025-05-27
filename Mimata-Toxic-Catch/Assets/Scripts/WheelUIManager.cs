using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WheelUIManager : MonoBehaviour
{
    [Header("UI Segments (Fill)")]
    public Image toxicImage;
    public Image junkImage;
    public Image safeImage;

    [Header("Indicator")]
    public Indicator indicator;

    private float _toxicAngle, _junkAngle, _safeAngle;
    [SerializeField] private Pollution pollution;

    [SerializeField] private float junkRandomizerMin = 3f;
    [SerializeField] private float junkRandomizerMax = 10f;

    private void Start()
    {
        pollution.PollutionIncreased += OnPollutionIncreased;
        OnPollutionIncreased(pollution.currentPollution);
    }

    private void OnPollutionIncreased(float pollutionLevel)
    {
        float randomJunk = Random.Range(junkRandomizerMin, junkRandomizerMax);
        InitializeUI(pollutionLevel, randomJunk);
    }

    public void InitializeUI(float toxicPercent, float junkPercent)
    {
        float safePercent = Mathf.Min(100f - (toxicPercent + junkPercent), 0f);

        if (toxicPercent < 0 || junkPercent < 0 || safePercent < 0)
        {
            Debug.LogError("Invalid percentages! They must not be negative.");
            return;
        }

        float totalAngle = 180f;
        _toxicAngle = totalAngle * (toxicPercent / 100f);
        _junkAngle = totalAngle * (junkPercent / 100f);
        _safeAngle = totalAngle * (safePercent / 100f);

        toxicImage.fillAmount = _toxicAngle / 180f;
        junkImage.fillAmount = (_toxicAngle + _junkAngle) / 180f;
        safeImage.fillAmount = 1f;
    }

    public void Catch()
    {
        if (!indicator.isSpinning) return;
        
        indicator.StopSpinning();
        
        float angle = indicator.GetCurrentAngle();
        float normalized = Mathf.Repeat(angle, 180f);

        Debug.Log($"Indicator stopped at angle: {normalized}°");
        Debug.Log("safe angle " + _safeAngle);

        if (normalized < _toxicAngle)
        {
            Debug.Log("Caught: TOXIC");
        }
        else if (normalized < _toxicAngle + _junkAngle)
        {
            Debug.Log("Caught: JUNK");
        }
        else
        {
            Debug.Log("Caught: SAFE");
        }
    }
}