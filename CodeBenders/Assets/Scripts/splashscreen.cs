using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashscreen : MonoBehaviour
{

	void Start(){
		StartCoroutine(Display());
	}

    IEnumerator Display()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("home");
    }
}
