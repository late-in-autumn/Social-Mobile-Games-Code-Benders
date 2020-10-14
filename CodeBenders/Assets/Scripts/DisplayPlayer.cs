using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayer : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject show;
    public string playername;
    void Start()
    {
        show = GameObject.FindGameObjectWithTag("PlayerTurn");
        show.SetActive(false);
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

        playername = GameObject.FindWithTag("pl1").GetComponent<InputField>().text;
        show.GetComponent<Text>().text = playername + "'s turn";
        
    }
}
