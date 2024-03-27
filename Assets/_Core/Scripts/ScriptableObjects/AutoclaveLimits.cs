using UnityEngine;

//these are the minimum and maximum settings possible on the autoclave
[CreateAssetMenu(fileName = "AutoclaveLimitsObject", menuName = "ScriptableObjects/AutoclaveLimits", order = 0)]
public class AutoclaveLimits : ScriptableObject
{
    [SerializeField] public float MinTime; //seconds
    [SerializeField] public float MaxTime; //seconds
    [SerializeField] public float MinTemp; //°C
    [SerializeField] public float MaxTemp; //°C
    [SerializeField] public float MinWaterLevel; //ml
    [SerializeField] public float MaxWaterLevel; //ml
    [SerializeField] public float MinPressure;
    [SerializeField] public float MaxPressure;
}
