using System.Collections;
using System.Collections.Generic;
using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.Events;

public class AutoclaveController : MonoBehaviour
{

    [Header("Door")]
    public GameObject Door;

    private HingeJoint _doorHinge;

    public UnityEvent OnDoorOpen;
    public UnityEvent OnDoorClosed;
    private DoorState _doorState;

    [Header("Temperature")]
    public XRKnob TemperatureDial;

    [Header("Timer")]
    public XRKnob TimerDial;
    public DoorState DoorState {  get { return _doorState; } }
    // Start is called before the first frame update
    void Start()
    {
        _doorState = DoorState.CLOSED;
        _doorHinge = Door.GetComponent<HingeJoint>();
    }


    // Update is called once per frame
    void Update()
    {

        
    }
}
