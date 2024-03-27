using System.Collections;
using System.Collections.Generic;
using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.Events;

public class AutoclaveController : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] public AutoclaveStats AutoclaveStatsObject; //the current autoclave settings and variables
    [SerializeField] public AutoclaveRequirements AutoclaveRequirementsObject; //the settings required for a successful sterilization
    [SerializeField] public AutoclaveLimits AutoclaveLimitsObject; //the physical minimum and maximum settings on the autoclave

    [Header("Door")]
    public GameObject Door;

    private HingeJoint _doorHinge;

    public UnityEvent OnDoorOpen;
    public UnityEvent OnDoorClosed;
    private DoorState _doorState;

    [Header("Timer")]
    [SerializeField] public XRKnob TimerDial;

    [Header("Temperature")]
    [SerializeField] public XRKnob TempDial;

    [Header("Mode")]
    [SerializeField] public XRKnob ModeDial;

    //TODO: add power switch
    //TODO: add water level
    //TODO: add water cap

    public DoorState DoorState { get { return _doorState; } }

    private void Start()
    {
        _doorHinge = Door.GetComponent<HingeJoint>();

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
        _doorState = DoorState.CLOSED;

        //reset dials/switches
        TimerDial.value = 0.0f;
        TempDial.value = 0.0f;
        //TODO: reset water level
        ModeDial.value = 0.0f;
        //TODO: reset power switch
        //TODO: reset water cap
        //TODO: reset door
    }

    public void AddWater(float ml)
    {
        _doorState = DoorState.CLOSED;
        _doorHinge = Door.GetComponent<HingeJoint>();
    }


    // Update is called once per frame
    void Update()
    {

    public void OnTimerDialChange()
    {
        AutoclaveStatsObject.Timer = Mathf.Lerp(AutoclaveLimitsObject.MinTime, AutoclaveLimitsObject.MaxTime, TimerDial.value);
        Debug.Log(AutoclaveStatsObject.Timer);
    }

    public void OnTempDialChange()
    {
        AutoclaveStatsObject.Temp = Mathf.Lerp(AutoclaveLimitsObject.MinTemp, AutoclaveLimitsObject.MaxTemp, TempDial.value);
        Debug.Log(AutoclaveStatsObject.Temp);
    }

    public void OnModeDialChange()
    {
        int mode = Mathf.RoundToInt(ModeDial.value * 4.0f);
        switch (mode)
        {
            case 1: //right
                AutoclaveStatsObject.Mode = AutoclaveMode.FillWater;
                Debug.Log(AutoclaveStatsObject.Mode);
                break;

            case 2: //down
                AutoclaveStatsObject.Mode = AutoclaveMode.Sterilize;
                Debug.Log(AutoclaveStatsObject.Mode);
                break;

            case 3: //left
                AutoclaveStatsObject.Mode = AutoclaveMode.ExhaustDry;
                Debug.Log(AutoclaveStatsObject.Mode);
                break;

            case 4: //up
            case 0: //up
            default:
                AutoclaveStatsObject.Mode = AutoclaveMode.Mode1;
                Debug.Log(AutoclaveStatsObject.Mode);
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
        //TODO: check against requirements and do something
    }
}