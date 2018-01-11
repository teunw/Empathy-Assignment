using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GlowObjectCmd))]
public class PostIt : MonoBehaviour {

    public string Text { get { return uiText.text; } set { uiText.text = value; } }
    public bool Glow { get { return glowObjectCmd.Glow; } set { glowObjectCmd.Glow = value; } }

    private Text uiText;
    private GlowObjectCmd glowObjectCmd;

	// Use this for initialization
	void Awake () {
        uiText = GetComponentInChildren<Text>();
        
        if (!uiText)
        {
            Debug.LogWarning("Could not find a UI 'Text' component on this gameobject or its children.");
        }

        glowObjectCmd = GetComponent<GlowObjectCmd>();
	}
}
