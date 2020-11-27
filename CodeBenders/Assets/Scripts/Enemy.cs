using UnityEngine;

/// <summary>
/// Component for the target objects.
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>
    /// How much damage can a target withstand.
    /// </summary>
    public float health = 2f;

    public AudioSource source;


    void Start() {
        source = GetComponent<AudioSource>();
    }

    // called once upon collision
    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        source.Play();
        // if the collision is more than what the target can withstand then it gets destroyed
        if (health.CompareTo(colInfo.relativeVelocity.magnitude) <= 0) Destroy(gameObject);
        // else its health gets decreased
        else health -= colInfo.relativeVelocity.magnitude;
    }
}