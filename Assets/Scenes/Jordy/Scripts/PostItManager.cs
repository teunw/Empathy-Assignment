using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostItManager : MonoBehaviour {

    public PostIt[] postits;

    private Stack<PostIt> tasks;
    private PostIt currentTask;

	// Use this for initialization
	void Start () {

        // Reverse array
        for (int i = 0; i < postits.Length / 2; i++)
        {
            PostIt tmp = postits[i];
            postits[i] = postits[postits.Length - i - 1];
            postits[postits.Length - i - 1] = tmp;
        }

        tasks = new Stack<PostIt>(postits);
        //NextTask();
	}

    public void NextTask()
    {
        //if (tasks.Count < 1) return;

        //PostIt nextTask = tasks.Pop();
        //nextTask.SetState(PostItState.ACTIVE);

        //if (currentTask) currentTask.SetState(PostItState.FINISHED); // Delete this line in future

        //currentTask = nextTask;
    }
}
