using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Used for jumping to levels from the home screen.
/// </summary>
public class Home :MonoBehaviour
{
    /// <summary>
    /// Jump to Level 1.
    /// </summary>
    public void MainLevel() => PlayGame(2);

    /// <summary>
    /// Jump to Level 2.
    /// </summary>
    public void ExtendedLevel() => PlayGame(3);

    // jump to a given level
    private void PlayGame(int scene)
    {
        Transform parentTransform = GameObject.FindWithTag("pl1").transform;

        // If this object doesn't have a parent then its the root transform.
        while (parentTransform.parent != null)
        {
            // Keep going up the chain.
            parentTransform = parentTransform.parent;
        }

        DontDestroyOnLoad(parentTransform.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + scene);
    }
}
