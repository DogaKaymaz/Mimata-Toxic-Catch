using System;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI safeCatchCount;
    [SerializeField] private TextMeshProUGUI toxicCatchCount;
    private void Start()
    {
        var inventory = GameManager.Instance.inventory;
        inventory.SafeCatchCountChanged += OnSafeCatchCountChanged;
        inventory.ToxicCatchCountChanged += OnToxicCatchCountChanged;
    }

    private void OnToxicCatchCountChanged(int count)
    {
        toxicCatchCount.SetText(count + " toxic fish");
    }

    private void OnSafeCatchCountChanged(int count)
    {
        safeCatchCount.SetText(count + " safe fish");
    }
}
