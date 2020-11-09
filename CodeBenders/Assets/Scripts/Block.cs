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
    /// Tag for identifying the targets.
    /// </summary>
    public string targetTag;

    // called before the first frame update
    private void Start() => insideGrid = false;

    // called once upon collision
    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        // the same behavior before if current block is not a wooden block
        if (!gameObject.CompareTag(woodenBlockTag)) return;
        
        // self-destruct if current block is a wooden block and hits the target
        if (colInfo.gameObject.CompareTag(targetTag))
            Destroy(gameObject);
    }
}