using UnityEngine;

public enum AutoclaveMode
{
    Mode1,
    FillWater,
    Sterilize,
    ExhaustDry
}

//these are the current settings and variables of the autoclave
public class AutoclaveStats : ScriptableObject
{
    [SerializeField] public float Timer; //seconds
    [SerializeField] public float Temp; //°C
    [SerializeField] public float WaterLevel; //ml
    [SerializeField] public AutoclaveMode Mode;
    [SerializeField] public bool IsPowerOn;
    [SerializeField] public bool IsWaterCapOpen;
    [SerializeField] public bool IsDoorOpen;
    [SerializeField] public bool IsDoorHandleOpen;

    [SerializeField] public float Pressure; //for visual pressure guage
}
