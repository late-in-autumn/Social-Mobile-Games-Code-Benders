using UnityEngine;
using UnityEngine.UI;

public class WinDetector : MonoBehaviour
{
    /// <summary>
    /// The tag for the targets of Player 1.
    /// </summary>
    public string tagPlayerOne;

    /// <summary>
    /// The tag for the targets of Player 2.
    /// </summary>
    public string tagPlayerTwo;

    // name of player 1
    private string _playerOne;

    // name of player 2
    private string _playerTwo;

    // called before the first frame update
    private void Start()
    {
        _playerOne = GameObject.FindWithTag("pl1").GetComponent<InputField>().text;
        _playerTwo = GameObject.FindWithTag("pl2").GetComponent<InputField>().text;
    }
    
    // called once per frame
    private void Update()
    {
        // count the number of targets left for each player
        var targetsOne = GameObject.FindGameObjectsWithTag(tagPlayerOne).Length;
        var targetsTwo = GameObject.FindGameObjectsWithTag(tagPlayerTwo).Length;

        // log the target counts for telemetry
        GameObject.Find("Telemetry").SendMessage("SetPlayerOneTargets", targetsOne);
        GameObject.Find("Telemetry").SendMessage("SetPlayerTwoTargets", targetsTwo);

        // the opponent of a given player wins once his or her own target count becomes 0
        if (targetsOne == 0) Win(PlayersEnum.PlayerTwo, _playerTwo);
        else if (targetsTwo == 0) Win(PlayersEnum.PlayerOne, _playerOne);
    }

    // activate the winning screen upon a player winning
    private static void Win(PlayersEnum player, string playerName)
    {
        GameObject.Find("Telemetry").SendMessage("GameOver", player);
        GameObject.FindWithTag("gameOver").GetComponent<Canvas>().enabled = true;
        GameObject.FindWithTag("winMessage").GetComponent<Text>().text = $"{playerName} Won!";
    }
}