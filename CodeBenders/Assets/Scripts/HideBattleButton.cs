using UnityEngine;

public class HideBattleButton : MonoBehaviour
{
    public bool buttonPress = false;
    public GameObject Prompt;
    public void onButtonPress() {
        if(buttonPress == false) {
            buttonPress = true;
        } else if(buttonPress == true) {
            Prompt.SetActive(false);
        }
    }
}
