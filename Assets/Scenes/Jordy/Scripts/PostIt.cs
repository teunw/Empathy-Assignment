using UnityEngine;
using UnityEngine.UI;
using VRTK.Highlighters;
using VRTK;

public class PostIt : MonoBehaviour
{

	public Color highlightColor;
    public string Text { get { return uiText.text; } set { uiText.text = value; } }

    private Text uiText;
    private VRTK_BaseHighlighter highlighter;

	// Use this for initialization
	void Awake () {
        uiText = GetComponentInChildren<Text>();
        
        if (!uiText)
        {
            Debug.LogWarning("Could not find a UI 'Text' component on this gameobject or its children.");
        }

        InitialiseHighlighter();
	}

	public void Highlight()
	{
		highlighter.Highlight(highlightColor);
	}

	public void UnHighlight()
	{
		highlighter.Unhighlight();
	}
	
	private void InitialiseHighlighter()
	{
		VRTK_BaseHighlighter existingHighlighter = VRTK_BaseHighlighter.GetActiveHighlighter(gameObject);
		//If no highlighter is found on the GameObject then create the default one
		if (existingHighlighter == null)
		{
			gameObject.AddComponent<VRTK_OutlineObjectCopyHighlighter>();
		}
		else
		{
			VRTK_SharedMethods.CloneComponent(existingHighlighter, gameObject);
		}

		//Initialise highlighter and set highlight colour
		highlighter = GetComponent<VRTK_BaseHighlighter>();
		highlighter.unhighlightOnDisable = false;
		highlighter.Initialise();
		highlighter.Highlight(highlightColor);

//		//if the object highlighter is using a cloned object then disable the created highlight object's renderers
//		if (highlighter.UsesClonedObject())
//		{
//			foreach (Renderer renderer in GetComponentsInChildren<Renderer>(true))
//			{
//				if (!VRTK_PlayerObject.IsPlayerObject(renderer.gameObject, VRTK_PlayerObject.ObjectTypes.Highlighter))
//				{
//					renderer.enabled = false;
//				}
//			}
//		}
	}
}
