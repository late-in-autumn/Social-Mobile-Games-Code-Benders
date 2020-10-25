using UnityEngine;

/// <summary>
/// Component for the target objects.
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>
    /// How much damage a target can withstand.
    /// </summary>
    public float health = 2f;

    // called once upon collision
    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        // if the collision is more than what the target can withstand then it gets destroyed
        if (colInfo.relativeVelocity.magnitude > health) Destroy(gameObject);
    }
}