using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorTask : Task
{
    private AutoclaveController _autoclaveController;

    public override void Start()
    {
        base.Start();

        _autoclaveController = FindObjectOfType<AutoclaveController>();
        if(!_autoclaveController)
        {
            Debug.Log("This task relies on the presence of an autoclave controller in the scene!");
        }
    }
    public override void BeginTask()
    {

        throw new System.NotImplementedException();
    }

    public override void CheckTask()
    {
        throw new System.NotImplementedException();
    }

    public override void TaskComplete()
    {
        throw new System.NotImplementedException();
    }

    public override void TaskFailed()
    {
        throw new System.NotImplementedException();
    }
}
