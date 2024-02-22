using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task : MonoBehaviour
{
    [TextArea(3, 10)]
    [SerializeField] protected string Instructions;
    /// <summary>
    /// Begin Task is called to initialize our task. For example, updating our task tracker UI, playing an audio, etc. 
    /// </summary>
    public abstract void BeginTask();

    /// <summary>
    /// Task failed is called when CheckTask() is called and the task has not yet been completed. 
    /// </summary>
    public abstract void TaskFailed();

    /// <summary>
    /// Task complete is called when a task is successfully complete.d 
    /// </summary>
    public abstract void TaskComplete();

    /// <summary>
    /// Check task is called to verify if the task has been completed or not. 
    /// If the task is complete, then this will call the TaskComplete method. 
    /// </summary>
    public abstract void CheckTask();

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
}
