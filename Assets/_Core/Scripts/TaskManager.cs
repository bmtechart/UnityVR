using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : Singleton<TaskManager>
{
    public List<Task> Tasks = new List<Task>();
    private int _currentTask;

    public void NextTask()
    {
        _currentTask++;
        if (_currentTask >= Tasks.Count)
        {
            GameManager.Instance.GameOver();
            return;
        }

        Tasks[_currentTask].BeginTask();
    }
}
