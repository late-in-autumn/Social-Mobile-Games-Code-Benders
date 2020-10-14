using UnityEngine;
using UnityEngine.SceneManagement;

public class Home :MonoBehaviour
{

    

    public void PlayGame()
    {
        Transform parentTransform = GameObject.FindWithTag("pl1").transform;

        // If this object doesn't have a parent then its the root transform.
        while (parentTransform.parent != null)
        {
            // Keep going up the chain.
            parentTransform = parentTransform.parent;
        }

        DontDestroyOnLoad(parentTransform.gameObject);
      //  DontDestroyOnLoad(GameObject.FindWithTag("pl2"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    


}
