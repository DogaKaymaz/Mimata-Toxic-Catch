using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Pollution : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image fillingBar;
    private float targetAmount = 0f;
    private bool isIncreasing = false;
    [SerializeField] private float fillSpeed = 1f;
    
    [SerializeField] private TimeManager timeManager;
    private DayOfWeek _today;

    [Header("Mecha")]
    public float currentPollution = 0f;
    public float maxPollution = 100f;
    [SerializeField] private float pollutionIncreaseMin = 1f;
    [SerializeField] private float pollutionIncreaseMax = 5f;

    public Action<float> PollutionIncreased;
    private void Start()
    {
        timeManager.NewDayStarted += OnNewDayStarted;
        currentPollution = 0f;
    }

    private void OnNewDayStarted()
    {
        if (currentPollution >= 100f) return;
        float randomIncrease = Random.Range(pollutionIncreaseMin, pollutionIncreaseMax);
        currentPollution += randomIncrease;
        InitializeUI();
        PollutionIncreased?.Invoke(currentPollution);
    }
    
    private void InitializeUI()
    {
        targetAmount = Mathf.Clamp01(currentPollution/maxPollution);
        isIncreasing = true;
    }
    void Update()
    {
        if (isIncreasing)
        {
            fillingBar.fillAmount = Mathf.MoveTowards(fillingBar.fillAmount, targetAmount, fillSpeed * Time.deltaTime);

            if (Mathf.Approximately(fillingBar.fillAmount, targetAmount))
            {
                isIncreasing = false;
            }
        }
    }
}