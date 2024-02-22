using UnityEngine;

//these are the settings required for a successful sterilization
public class AutoclaveRequirements : ScriptableObject
{
    [SerializeField] public float minTime; //seconds
    [SerializeField] public float maxTime; //seconds
    [SerializeField] public float minTemp; //°C
    [SerializeField] public float maxTemp; //°C
    [SerializeField] public float minWaterLevel; //ml
    [SerializeField] public float maxWaterLevel; //ml
    [SerializeField] public AutoclaveMode requiredMode = AutoclaveMode.Sterilize;
}
