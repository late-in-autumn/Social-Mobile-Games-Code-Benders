using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour {

	//public GameObject deathEffect;

	public float health = 2f;

	public static int EnemiesAlive = 0;

    public string pl1;

	void Start ()
	{
        pl1 = GameObject.FindWithTag("pl1").GetComponent<InputField>().text;
		EnemiesAlive++;
	}

	void OnCollisionEnter2D (Collision2D colInfo)
	{
		if (colInfo.relativeVelocity.magnitude > health)
		{
			Die();
		}
	}

	void Die ()
	{
		//Instantiate(deathEffect, transform.position, Quaternion.identity);

		EnemiesAlive--;
		if (EnemiesAlive <= 0)
			Debug.Log("LEVEL WON by Player 1!");

		Destroy(gameObject);
        if(EnemiesAlive == 0) {
		    GameObject.FindWithTag("gameOver").GetComponent<Canvas>().enabled = true;
            GameObject.FindWithTag("winMessage").GetComponent<Text>().text = pl1 + " Won!";
        }
	}

}
