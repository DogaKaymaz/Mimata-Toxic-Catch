using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FamilyUI : MonoBehaviour
{
    public Image mcHunger;
    public Image mcHealth;
    
    public Image wifeHunger;
    public Image wifeHealth;
    
    public Image childHunger;
    public Image childHealth;

    public GameObject warningBox;
    public TextMeshProUGUI warningBoxText;

    public GameObject exitObj;
    public GameObject wifeObj;
    public GameObject wifeVisualObj;
    public GameObject childObj;
    public GameObject childVisualObj;
    
    private void Start()
    {
        var gm = GameManager.Instance;

        // MC
        gm.mc.OnHealthChanged += (val) => UpdateBar(mcHealth, val, gm.mc.maxHealth);
        gm.mc.OnHungerChanged += (val) => UpdateBar(mcHunger, val, gm.mc.maxHunger);
        gm.mc.OnDied += OnMCDied;
        
        // Wife
        gm.wife.OnHealthChanged += (val) => UpdateBar(wifeHealth, val, gm.wife.maxHealth);
        gm.wife.OnHungerChanged += (val) => UpdateBar(wifeHunger, val, gm.wife.maxHunger);
        gm.wife.OnDied += OnWifeDied;
        
        // Child
        gm.child.OnHealthChanged += (val) => UpdateBar(childHealth, val, gm.child.maxHealth);
        gm.child.OnHungerChanged += (val) => UpdateBar(childHunger, val, gm.child.maxHunger);
        gm.child.OnDied += OnChildDied;
        
        InitUI();
        
        Debug.Log("health?  " + gm.wife.CurrentHealth +" / " +gm.wife.maxHealth);
    }

    private void OnChildDied()
    {
        warningBox.SetActive(true);
        childObj.SetActive(false);
        childVisualObj.SetActive(false);
        warningBoxText.SetText("KID IS DEAD\nrest in piece kiddo");
    }

    private void OnWifeDied()
    {
        warningBox.SetActive(true);
        wifeObj.SetActive(false);
        wifeVisualObj.SetActive(false);
        warningBoxText.SetText("WIFE IS DEAD\nher beautiful soul will be remembered");
    }

    private void OnMCDied()
    {
        warningBox.SetActive(true);
        exitObj.SetActive(false);
        warningBoxText.SetText("GAME OVER\nyou died");
    }

    private void UpdateBar(Image img, float current, float max)
    {
        if (img == null || max <= 0f) return;
        img.fillAmount = current / max;
    }

    private void InitUI()
    {
        var gm = GameManager.Instance;
        UpdateBar(mcHealth, gm.mc.CurrentHealth, gm.mc.maxHealth);
        UpdateBar(mcHunger, gm.mc.CurrentHunger, gm.mc.maxHunger);
        
        UpdateBar(wifeHealth, gm.wife.CurrentHealth, gm.wife.maxHealth);
        UpdateBar(wifeHunger, gm.wife.CurrentHunger, gm.wife.maxHunger);
        
        UpdateBar(childHealth, gm.child.CurrentHealth, gm.child.maxHealth);
        UpdateBar(childHunger, gm.child.CurrentHunger, gm.child.maxHunger);
    }
}
