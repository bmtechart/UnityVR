using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum DoorState
{
    OPEN,
    CLOSED,
    FREE
}

[RequireComponent(typeof(HingeJoint))]
public class DoorController : MonoBehaviour
{
    private DoorState doorState;

    private float _limitMin;
    private float _limitMax;

    JointLimits closedLimits;
    JointLimits openLimits;
    JointLimits freeLimits;

    private HingeJoint _hingeJoint;

    [Header("Events")]
    public UnityEvent DoorOpened;
    public UnityEvent DoorClosed;
    // Start is called before the first frame update
    void Start()
    {
        _hingeJoint = GetComponent<HingeJoint>();
        _limitMax = _hingeJoint.limits.max;
        _limitMin = _hingeJoint.limits.min;

        freeLimits = new JointLimits();
        freeLimits.max = _limitMax;
        freeLimits.min = _limitMin;

        closedLimits = new JointLimits();
        closedLimits.max = _limitMin;
        closedLimits.min = _limitMin;


        openLimits = new JointLimits();
        openLimits.max = _limitMax;
        openLimits.min = _limitMax;

    }

    public void SetOpen()
    {
        _hingeJoint.limits = openLimits;
        doorState = DoorState.OPEN;
    }

    public void SetClosed()
    {
        _hingeJoint.limits = closedLimits;
        doorState = DoorState.CLOSED;
    }

    public void SetFree()
    {
        _hingeJoint.limits = freeLimits;
        doorState = DoorState.FREE;
    }

    // Update is called once per frame
    void Update()
    {
        if(doorState == DoorState.FREE)
        {
            if(_hingeJoint.angle == _limitMin)
            {
                DoorClosed?.Invoke();
            }

            if(_hingeJoint.angle == _limitMax)
            {
                DoorOpened?.Invoke();
            }
        }
    }
}
