using UnityEngine;

//these are the settings required for a successful sterilization
public class AutoclaveRequirements : ScriptableObject
{
    [SerializeField] public float MinTime; //seconds
    [SerializeField] public float MaxTime; //seconds
    [SerializeField] public float MinTemp; //°C
    [SerializeField] public float MaxTemp; //°C
    [SerializeField] public float MinWaterLevel; //ml
    [SerializeField] public float MaxWaterLevel; //ml
}
