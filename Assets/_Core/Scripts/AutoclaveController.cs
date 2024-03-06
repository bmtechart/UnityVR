using Unity.VRTemplate;
using UnityEngine;

public class AutoclaveController : MonoBehaviour
{
    [SerializeField] public AutoclaveStats AutoclaveStatsObject; //the current autoclave settings and variables
    [SerializeField] public AutoclaveRequirements AutoclaveRequirementsObject; //the settings required for a successful sterilization
    [SerializeField] public AutoclaveLimits AutoclaveLimitsObject; //the physical minimum and maximum settings on the autoclave

    [SerializeField] public XRKnob TimerDial;
    [SerializeField] public XRKnob TempDial;
    //TODO: add water level
    [SerializeField] public XRKnob ModeDial;
    //TODO: add power switch
    //TODO: add water cap
    //TODO: add door
    //TODO: add door handle

    [SerializeField] public GameObject pressureGauge;

    private void Start()
    {
        ResetAutoclave();
    }

    public void ResetAutoclave()
    {
        //reset settings and variables to zero/default
        AutoclaveStatsObject.Timer = AutoclaveLimitsObject.MinTime;
        AutoclaveStatsObject.Temp = AutoclaveLimitsObject.MinTemp;
        AutoclaveStatsObject.WaterLevel = AutoclaveLimitsObject.MinWaterLevel;
        AutoclaveStatsObject.Mode = AutoclaveMode.Mode1;
        AutoclaveStatsObject.IsPowerOn = false;
        AutoclaveStatsObject.IsWaterCapOpen = false;
        AutoclaveStatsObject.IsDoorOpen = false;
        AutoclaveStatsObject.IsDoorHandleOpen = false;

        //reset dials/switches
        TimerDial.value = 0.0f;
        TempDial.value = 0.0f;
        //TODO: reset water level
        ModeDial.value = 0.0f;
        //TODO: reset power switch
        //TODO: reset water cap
        //TODO: reset door
        //TODO: reset door handle
    }

    public void AddWater(float ml)
    {
        AutoclaveStatsObject.WaterLevel += ml;

        UpdateVisibleWaterLevel();
    }

    public void RemoveWater(float ml)
    {
        AutoclaveStatsObject.WaterLevel -= ml;

        UpdateVisibleWaterLevel();
    }

    private void UpdateVisibleWaterLevel()
    {
        //TODO: change visible water level based on autoclaveStats.WaterLevel
    }

    public void OnTimerDialChange()
    {
        AutoclaveStatsObject.Timer = Mathf.Lerp(AutoclaveLimitsObject.MinTime, AutoclaveLimitsObject.MaxTime, TimerDial.value);
    }

    public void OnTempDialChange()
    {
        AutoclaveStatsObject.Temp = Mathf.Lerp(AutoclaveLimitsObject.MinTemp, AutoclaveLimitsObject.MaxTemp, TempDial.value);
    }

    public void OnModeDialChange()
    {
        int mode = Mathf.RoundToInt(ModeDial.value * 4.0f);
        switch (mode)
        {
            case 1: //right
                AutoclaveStatsObject.Mode = AutoclaveMode.FillWater;
                break;

            case 2: //down
                AutoclaveStatsObject.Mode = AutoclaveMode.Sterilize;
                break;

            case 3: //left
                AutoclaveStatsObject.Mode = AutoclaveMode.ExhaustDry;
                break;

            case 4: //up
            case 0: //up
            default:
                AutoclaveStatsObject.Mode = AutoclaveMode.Mode1;
                break;
        }
    }

    public void OnRun()
    {
        switch (AutoclaveStatsObject.Mode)
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

    public bool IsTimerCorrect()
    {
        return AutoclaveStatsObject.Timer >= AutoclaveRequirementsObject.MinTime && AutoclaveStatsObject.Timer <= AutoclaveRequirementsObject.MaxTime;
    }

    public bool IsTempCorrect()
    {
        return AutoclaveStatsObject.Temp >= AutoclaveRequirementsObject.MinTemp && AutoclaveStatsObject.Temp <= AutoclaveRequirementsObject.MaxTemp;
    }

    public bool IsWaterLevelCorrect()
    {
        return AutoclaveStatsObject.WaterLevel >= AutoclaveRequirementsObject.MinWaterLevel && AutoclaveStatsObject.WaterLevel <= AutoclaveRequirementsObject.MaxWaterLevel;
    }
}
