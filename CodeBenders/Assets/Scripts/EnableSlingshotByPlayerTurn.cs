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
                GameObject.FindWithTag("SlingshotP1").SendMessage("EnableSlingshotReloading");
                break;
            case PlayersEnum.PlayerTwo:
                GameObject.FindWithTag("SlingshotP2").SendMessage("EnableSlingshotReloading");
                break;
        }
    }
}
