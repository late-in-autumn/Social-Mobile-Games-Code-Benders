using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

/// <summary>
/// Component for keeping track of the game statistic data points and upload them as a telemetry event.
/// </summary>
public class TelemetryController : MonoBehaviour
{
    // the number of targets that survived for player 1
    private int _playerOneTargets;
    // the number of targets that survived for player 2
    private int _playerTwoTargets;
    // the number of projectiles consumed by player 1
    private int _playerOneProjectiles;
    // the number of projectiles consumed by player 2
    private int _playerTwoProjectiles;
    // the winner of the game
    private PlayersEnum _winner;

    /// <summary>
    /// Set the number of targets for player 1.
    /// </summary>
    /// <param name="numOfTargets">Number of targets.</param>
    public void SetPlayerOneTargets(int numOfTargets) => _playerOneTargets = numOfTargets;

    /// <summary>
    /// Set the number of targets for player 2.
    /// </summary>
    /// <param name="numOfTargets">Number of targets</param>
    public void SetPlayerTwoTargets(int numOfTargets) => _playerTwoTargets = numOfTargets;
    
    /// <summary>
    /// Increase the number of projectiles consumed by player 1 by 1.
    /// </summary>
    public void PlayerOneFired() => _playerOneProjectiles++;
    
    /// <summary>
    /// Increase the number of projectiles consumed by player 2 by 1.
    /// </summary>
    public void PlayerTwoFired() => _playerTwoProjectiles++;

    /// <summary>
    /// Signalling that the game has ended, and the winner of the game.
    /// </summary>
    /// <param name="winner"></param>
    public void GameOver(PlayersEnum winner)
    {
        // update the game winner
        _winner = winner;
        
        // print the collected data points to debug console
        Debug.Log($"{Enum.GetName(typeof(PlayersEnum), _winner)} won, sending telemetry data...");
        Debug.Log((
            $"Player 1 used {_playerOneProjectiles} projectile(s); Player 2 used {_playerTwoProjectiles} projectile(s)."));
        Debug.Log(
            $"Player 1 has {_playerOneTargets} target(s) surviving; Player 2 has {_playerTwoTargets} target(s) surviving.");
        
        // upload the collected data points
        var result = UploadData();
        Debug.Log($"Telemetry submission result: {result.ToString()}");
    }
    
    // called before the first frame update
    private void Start()
    {
        _playerOneProjectiles = 0;
        _playerTwoProjectiles = 0;
    }
    
    // upload the telemetry data as a Unity Analytics custom event
    private AnalyticsResult UploadData() => 
        Analytics.CustomEvent("GameOver", new Dictionary<string, object> 
        {
            { "Winner", Enum.GetName(typeof(PlayersEnum), _winner) },
            { "PlayerOneProjectiles", _playerOneProjectiles },
            { "PlayerTwoProjectiles", _playerTwoProjectiles },
            { "PlayerOneTargets", _playerOneTargets },
            { "PlayerTwoTargets", _playerTwoTargets }
        });
}