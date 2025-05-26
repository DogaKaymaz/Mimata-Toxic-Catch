using System;
using UnityEngine;
using UnityEngine.UI;

public class SandalUI : MonoBehaviour
{
    [SerializeField] private Sandal sandal;
    [SerializeField] private Image infoBar;
    private void Start()
    {
        sandal.PlayerNear += OnPlayerNear;
    }

    private void OnPlayerNear(bool playerNear)
    {
        if(infoBar != null) infoBar.gameObject.SetActive(playerNear);
    }
}