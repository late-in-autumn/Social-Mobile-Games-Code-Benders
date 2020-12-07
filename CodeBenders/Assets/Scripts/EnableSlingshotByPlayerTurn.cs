using UnityEngine;

/// <summary>
/// Enable the slingshot for a single player in a given turn.
/// </summary>
public class EnableSlingshotByPlayerTurn : MonoBehaviour
{
    /// <summary>
    /// Enable the slingshot for a given player.
    /// </summary>
    /// <param name="player">The player to enable the slingshot for.</param>
    public void EnableSlingshotForPlayer(PlayersEnum player)
    {
        switch (player)
        {
            case PlayersEnum.PlayerOne:
                if (GameObject.FindWithTag("SlingshotP1"))
                    GameObject.FindWithTag("SlingshotP1").SendMessage("EnableSlingshotReloading");
                return;
            case PlayersEnum.PlayerTwo:
                if (GameObject.FindWithTag("SlingshotP2"))
                    GameObject.FindWithTag("SlingshotP2").SendMessage("EnableSlingshotReloading");
                return;
            default:
                return;
        }
    }
}
