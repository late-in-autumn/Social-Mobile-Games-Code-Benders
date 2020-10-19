using System.Collections;
using System.Collections.Generic;
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
        player1 = GameObject.FindWithTag("pl1").GetComponent<InputField>().text + "'s turn";
        player2 = GameObject.FindWithTag("pl2").GetComponent<InputField>().text + "'s turn";
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
            
    }

    public void changePlayer(GameObject projectile) {
        GameObject.FindWithTag("PlayerTurn").GetComponent<Text>().text = (projectile.tag == "ProjectileP1") ? player2 : player1;        
    }
}
