using UnityEngine;

public enum TaskState
{
    TODO,
    ACTIVE,
    FINISHED
};

public class Task : MonoBehaviour{

    public PostIt postIt;
    public TaskState startState;
    public TaskState State { get { return state; } set { SetState(value); } }
    public string description;

    private TaskState state;

    private void Start()
    {
        if (!postIt) Debug.LogWarning("Post-it needs to be set!");
        postIt.Text = description;
        State = startState;
    }

    public void Complete()
    {
        State = TaskState.FINISHED;
    }

    public void SetState(TaskState newState)
    {
        switch(newState)
        {
            case TaskState.TODO:
                postIt.UnHighlight();
                break;
            case TaskState.ACTIVE:
                postIt.Highlight();
                break;
            case TaskState.FINISHED:
                postIt.UnHighlight();
                break;
        }

        state = newState;

        EventManager.Instance.Invoke(new TaskStateChanged() { Task = this });
    }

}
