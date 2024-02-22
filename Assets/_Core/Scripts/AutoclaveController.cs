using Unity.VRTemplate;
using UnityEngine;

public class AutoclaveController : MonoBehaviour
{
    [SerializeField] public AutoclaveStats autoclaveStats; //the current autoclave settings and variables
    [SerializeField] public AutoclaveRequirements autoclaveRequirements; //the settings required for a successful sterilization
    [SerializeField] public AutoclaveLimits autoclaveLimits; //the physical minimum and maximum settings on the autoclave

    [SerializeField] public XRKnob timerDial;
    [SerializeField] public XRKnob tempDial;
    //add water level
    [SerializeField] public XRKnob modeDial;
    //add power switch
    //add water cap
    //add door
    //add door handle

    [SerializeField] public GameObject pressureGauge;

    private void Start()
    {
        ResetAutoclave();
    }

    public void ResetAutoclave()
    {
        //reset settings and variables to zero/default
        autoclaveStats.Timer = autoclaveLimits.minTime;
        autoclaveStats.Temp = autoclaveLimits.minTemp;
        autoclaveStats.WaterLevel = autoclaveLimits.minWaterLevel;
        autoclaveStats.Mode = AutoclaveMode.Mode1;
        autoclaveStats.IsPowerOn = false;
        autoclaveStats.IsWaterCapOpen = false;
        autoclaveStats.IsDoorOpen = false;
        autoclaveStats.IsDoorHandleOpen = false;

        //reset dials/switches
        timerDial.value = 0.0f;
        tempDial.value = 0.0f;
        //TODO: reset water level
        modeDial.value = 0.0f;
        //TODO: reset power switch
        //TODO: reset water cap
        //TODO: reset door
        //TODO: reset door handle
    }

    public void AddWater(float ml)
    {
        autoclaveStats.WaterLevel += ml;

        UpdateVisibleWaterLevel();
    }

    public void RemoveWater(float ml)
    {
        autoclaveStats.WaterLevel -= ml;

        UpdateVisibleWaterLevel();
    }

    private void UpdateVisibleWaterLevel()
    {
        //TODO: change visible water level based on autoclaveStats.WaterLevel
    }

    public void OnTimerDialChange()
    {
        autoclaveStats.Timer = Mathf.Lerp(autoclaveLimits.minTime, autoclaveLimits.maxTime, timerDial.value);
    }

    public void OnTempDialChange()
    {
        autoclaveStats.Temp = Mathf.Lerp(autoclaveLimits.minTemp, autoclaveLimits.maxTemp, tempDial.value);
    }

    public void OnModeDialChange()
    {
        int mode = Mathf.RoundToInt(modeDial.value * 4.0f);
        switch (mode)
        {
            case 1: //right
                autoclaveStats.Mode = AutoclaveMode.FillWater;
                break;

            case 2: //down
                autoclaveStats.Mode = AutoclaveMode.Sterilize;
                break;

            case 3: //left
                autoclaveStats.Mode = AutoclaveMode.ExhaustDry;
                break;

            case 4: //up
            case 0: //up
            default:
                autoclaveStats.Mode = AutoclaveMode.Mode1;
                break;
        }
    }

    public void OnRun()
    {
        switch (autoclaveStats.Mode)
        {
            case AutoclaveMode.Mode1:
                //events if turned on while in mode 1
                break;

            case AutoclaveMode.FillWater:
                //events if turned on while in fill water mode
                break;

            case AutoclaveMode.Sterilize:
                Sterilize();
                break;

            case AutoclaveMode.ExhaustDry:
                //events if turned on while in exhaust/dry mode
                break;

            default:
                //nothing
                break;
        }
    }

    private void Sterilize()
    {
        //check against requirements
        
        //rotate pressure guage

    }
}
