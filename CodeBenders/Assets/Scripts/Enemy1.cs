using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour {

	//public GameObject deathEffect;

	public float health = 2f;

	public static int EnemiesAlive = 0;

  public string pl2;

	void Start ()
	{
    pl2 = GameObject.FindWithTag("pl2").GetComponent<InputField>().text;
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
			Debug.Log("LEVEL WON by Player 2!");

		Destroy(gameObject);

		if(EnemiesAlive == 0) {
			GameObject.Find("Telemetry").SendMessage("GameOver", PlayersEnum.PlayerTwo);
			GameObject.FindWithTag("gameOver").GetComponent<Canvas>().enabled = true;
			GameObject.FindWithTag("winMessage").GetComponent<Text>().text = pl2 + " Won!";
		}
	}

	void OnDestroy()
	{
			Debug.Log("OnDestroy1");
	}

}
