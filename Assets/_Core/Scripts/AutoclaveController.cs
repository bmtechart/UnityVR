using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum DoorState
{
    CLOSED,
    OPEN
}

public class AutoclaveController : MonoBehaviour
{

    [Header("Door")]
    public UnityEvent OnDoorOpen;
    public UnityEvent OnDoorClosed;
    private DoorState _doorState;
    public DoorState DoorState {  get { return _doorState; } }
    // Start is called before the first frame update
    void Start()
    {
        _doorState = DoorState.CLOSED;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
