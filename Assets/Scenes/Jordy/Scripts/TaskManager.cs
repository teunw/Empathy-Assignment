using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : EventHandler {

    public List<Task> tasks;

    private Task activeTask;

    // Use this for initialization
    void Start () {
		
	}
	
    public override void SubscribeEvents()
    {
        EventManager.Instance.AddListener<TaskStateChanged>(OnTaskStateChanged);
    }

    public override void UnsubscribeEvents()
    {
        EventManager.Instance.RemoveListener<TaskStateChanged>(OnTaskStateChanged);
    }

    private void OnActiveTask(Task task)
    {
		
    }

    private void OnFinishedTask(Task task)
    {
        RemoveTask(task);

        if (task == activeTask || activeTask == null)
        {
            SetNextTask();
        }
    }

    private void SetNextTask()
    {
        if (tasks.Count < 1)
        {
            activeTask = null;
        }
        else
        {
            activeTask = tasks[0];
            activeTask.State = TaskState.ACTIVE;
        }
    }

    private void RemoveTask(Task task)
    {
		Debug.Log ("Removing task: " + task.description);

        if (tasks.Contains(task)) tasks.Remove(task);

		foreach (Task t in tasks) {
			Debug.Log ("Remaining task: " + t.description);
		}
    }

    private void OnTaskStateChanged(TaskStateChanged e)
    {
        switch (e.Task.State)
        {
            case TaskState.TODO:
                break;
            case TaskState.ACTIVE:
                OnActiveTask(e.Task);
                break;
            case TaskState.FINISHED:
                OnFinishedTask(e.Task);
                break;
        }
    }
}
