using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Modifier
{
    public float addition = 0f;
    public float multiplication = 0f;
    public float percentageAddition = 0f;
}
[Serializable]
public class ModifiableNumber
{
    [SerializeField] private float baseValue;
    private List<Modifier> modifiers = new List<Modifier>();

    public float BaseValue => baseValue;

    public float Value
    {
        get
        {
            float result = baseValue;
            float totalAddition = 0f;
            float totalPercentageAddition = 0f;
            float totalMultiplication = 1f;

            foreach (var mod in modifiers)
            {
                totalAddition += mod.addition;
                totalPercentageAddition += mod.percentageAddition;
                totalMultiplication *= mod.multiplication;
            }

            result += totalAddition;
            result += result * totalPercentageAddition;
            result *= totalMultiplication;

            return result;
        }
    }

    public void AddModifier(Modifier mod)
    {
        modifiers.Add(mod);
    }

    public void RemoveModifier(Modifier mod)
    {
        modifiers.Remove(mod);
    }

    public void ClearModifiers()
    {
        modifiers.Clear();
    }
}