using System;
using TMPro;
using UnityEngine;

public class BaitUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI baitCount;
    private void Start()
    {
        CharacterBehaviour.Instance.BaitCountChanged += OnBaitCountChanged;
        OnBaitCountChanged(CharacterBehaviour.Instance.baitCount);
    }

    private void OnBaitCountChanged(int amount)
    {
        baitCount.SetText(amount.ToString());
    }
}