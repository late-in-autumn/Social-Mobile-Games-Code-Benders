using System;
using UnityEngine;

/// <summary>
/// Component for the target objects.
/// </summary>
public class Block : MonoBehaviour
{
    /// <summary>
    /// Tag for identifying the wooden blocks.
    /// </summary>
    public string woodenBlockTag;

    /// <summary>
    /// Whether the current block is inside the building grid.
    /// </summary>
    public bool insideGrid;

    /// <summary>
    /// Whether we are in battle mode or not
    /// </summary>
    public bool battleMode;

    /// <summary>
    /// Tag for identifying the targets.
    /// </summary>
    public string targetTag;

    // called before the first frame update
    private void Start()
    {
        insideGrid = false;
        battleMode = false;
    }

    // called once upon collision
    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        // do nothing if not in battle mode
        if (!battleMode) return;
        
        // the same behavior before if required tag variables are not set or current block is not a wooden block
        if (String.IsNullOrWhiteSpace(woodenBlockTag)
            || String.IsNullOrWhiteSpace(targetTag)
            || !gameObject.CompareTag(woodenBlockTag))
            return;

        // self-destruct if current block is a wooden block and hits the target
        if (colInfo.gameObject.CompareTag(targetTag))
            Destroy(gameObject);
    }
}