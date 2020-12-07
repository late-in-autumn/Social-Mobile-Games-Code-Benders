using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayer : MonoBehaviour
{
    public string player1, player2;
    
    // called before the first frame update;
    private void Start()
    {
        GetComponent<Text>().text = String.Empty;
        player1 = GameObject.FindWithTag("pl1").GetComponent<InputField>().text + "'s Turn!";
        player2 = GameObject.FindWithTag("pl2").GetComponent<InputField>().text + "'s Turn!";
    }

    public void Display() {
        GetComponent<Text>().text = player1;
        FadeInAndOut();
    }

    public void ChangePlayer(GameObject projectile)
    {
        GetComponent<Text>().text = (projectile.CompareTag("ProjectileP1")) ? player2 : player1;
        FadeInAndOut();
    }

    public void FadeInAndOut()
    {
        StartCoroutine(FadeTextAlpha());
    }

    public IEnumerator FadeTextAlpha()
    {
        Text i = GetComponent<Text>();
        float fadeInTime  = 1f;
        float fadeOutTime = 1f;

        // First let the Text Fade In over Specified Fade-In Time
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / fadeInTime));
            yield return new WaitForEndOfFrame();
        }

        // Next, Wait for the Frame to Change before Proceeding to Fade Out
        yield return new WaitForEndOfFrame();

        // Finally let the Text Fade Out over Specified Fade-Out Time
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / fadeOutTime));
            yield return new WaitForEndOfFrame();
        }
    }

}
