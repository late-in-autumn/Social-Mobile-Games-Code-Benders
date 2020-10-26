using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Component for restarting a game.
/// </summary>
public class Restart : MonoBehaviour
{
    /// <summary>
    /// Restarts a game.
    /// </summary>
    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
