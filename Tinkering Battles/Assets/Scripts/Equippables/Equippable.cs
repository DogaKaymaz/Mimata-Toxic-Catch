using System.Collections.Generic;
using UnityEngine;

public class Equippable : MonoBehaviour
{
    [Header("Basic Info")]
    public string itemName;
    public Sprite icon;
    [TextArea] public string description;

    [Header("Equip Info")]
    public bool isStackable = false;
    public int maxStack = 1;

    [Header("Stat Modifiers")]
    public List<MultiStatModifier> modifiers;
}

[System.Serializable]
public class MultiStatModifier
{
    public StatType stat;
    public Modifier modifier;
}

public enum StatType
{
    Damage,
    Health,
    Stamina,
    Speed,
    Armour
}