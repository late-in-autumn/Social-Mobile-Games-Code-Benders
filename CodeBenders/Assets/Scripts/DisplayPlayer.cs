using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayer : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject show;
    public string player1, player2;
    void Start()
    {
        show = GameObject.FindGameObjectWithTag("PlayerTurn");
        show.SetActive(false);
        player1 = GameObject.FindWithTag("pl1").GetComponent<InputField>().text + "'s Turn!";
        player2 = GameObject.FindWithTag("pl2").GetComponent<InputField>().text + "'s Turn!";
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void display() {

        GameObject battle;
        battle = GameObject.FindWithTag("Battle");

        if (battle.GetComponentInChildren<Text>().text == "Start Battle!") {
            show.SetActive(true);
        }
       
        show.GetComponent<Text>().text = player1;
        FadeInAndOut();

    }

    public void ChangePlayer(GameObject projectile)
    {
        GameObject.FindWithTag("PlayerTurn").GetComponent<Text>().text = (projectile.CompareTag("ProjectileP1")) ? player2 : player1;
        FadeInAndOut();
    }

    public void FadeInAndOut()
    {
        StartCoroutine(FadeTextAlpha());
    }

    public IEnumerator FadeTextAlpha()
    {
        Text i = show.GetComponent<Text>();
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
