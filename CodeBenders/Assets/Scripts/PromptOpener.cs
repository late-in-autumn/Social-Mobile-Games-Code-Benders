using UnityEngine;

public class PromptOpener : MonoBehaviour
{
    public GameObject Prompt;
    public void OpenPrompt () {
        if(Prompt != null) {
            bool isActive = Prompt.activeSelf;
            Prompt.SetActive(!isActive);
        }
    }
}
