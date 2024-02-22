using UnityEngine;

//these are the minimum and maximum settings possible on the autoclave
public class AutoclaveLimits : ScriptableObject
{
    [SerializeField] public float minTime; //seconds
    [SerializeField] public float maxTime; //seconds
    [SerializeField] public float minTemp; //°C
    [SerializeField] public float maxTemp; //°C
    [SerializeField] public float minWaterLevel; //ml
    [SerializeField] public float maxWaterLevel; //ml
    [SerializeField] public float minPressure;
    [SerializeField] public float maxPressure;
}
