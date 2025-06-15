using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveUIManager : MonoBehaviour
{
    public List<GameObject> objects;
    public Action<InteractiveUIManager> clickedTab;
    public void ChangeTabVisibility()
    {
        foreach (GameObject ui in objects)
        {
            clickedTab?.Invoke(this);
            if (ui.activeSelf) ui.SetActive(false);
            else ui.SetActive(true);
        }
    }
    
    public void ChangeTabVisibility(bool visibilityStatus)
    {
        if (objects == null) return;
        foreach (GameObject ui in objects) ui.SetActive(visibilityStatus);
    }
}
