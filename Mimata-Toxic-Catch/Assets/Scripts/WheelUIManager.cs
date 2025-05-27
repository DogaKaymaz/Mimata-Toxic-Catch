using System;
using System.Collections;
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

    [SerializeField] private string toxicGradient;
    [SerializeField] private string junkGradient;
    [SerializeField] private string safeGradient;
    private void Start()
    {
        pollution.PollutionIncreased += OnPollutionIncreased;
        pollution.PollutionMaxed += OnPollutionMaxed;
        OnPollutionIncreased(pollution.currentPollution);
    }

    private void OnPollutionMaxed()
    {
        OnPollutionIncreased(pollution.currentPollution);
    }

    private void OnPollutionIncreased(float pollutionLevel)
    {
        float randomJunk = Random.Range(junkRandomizerMin, junkRandomizerMax);
        InitializeUI(pollutionLevel, randomJunk);
    }

    public void InitializeUI(float toxicPercent, float junkPercent)
    {
        float safePercent = Mathf.Max(Mathf.Min(100f - (toxicPercent + junkPercent), 0f), 0f);

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
        
        CharacterBehaviour.Instance.AddBaitCount(-1);
        float angle = indicator.GetCurrentAngle();
        float normalized = Mathf.Repeat(angle, 180f);

        Debug.Log($"Indicator stopped at angle: {normalized}°");
        Debug.Log("safe angle " + _safeAngle);
        
        indicator.StopAllCoroutines();
        indicator.StartCoroutine(indicator.Timer());
        if (normalized < _toxicAngle)
        {
            indicator.SetCatchInfoText("<gradient=" + toxicGradient + ">" + "TOXIC");
        }
        else if (normalized < _toxicAngle + _junkAngle)
        {
            indicator.SetCatchInfoText("<gradient=" + junkGradient + ">" + "just a junk");
        }
        else
        {
            indicator.SetCatchInfoText("a safe and tasteful "+ "<gradient=" + safeGradient + ">" + "FISH");
        }
    }
}