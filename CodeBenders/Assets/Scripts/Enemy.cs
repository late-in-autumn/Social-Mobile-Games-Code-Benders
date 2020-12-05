using System;
using UnityEngine;

/// <summary>
/// Component for the target objects.
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>
    /// The sound effect that is attached.
    /// </summary>
    public AudioSource source;
    
    /// <summary>
    /// How much damage can a target withstand.
    /// </summary>
    public float health = 2f;

    /// <summary>
    /// Tag for identifying the wooden blocks.
    /// </summary>
    public string woodenBlockTag;

    /// <summary>
    /// Level of the current fire.
    /// </summary>
    public int currentFireLevel;

    /// <summary>
    /// Sprite for low fire.
    /// </summary>
    public Sprite lowFire;

    /// <summary>
    /// Sprite for medium fire.
    /// </summary>
    public Sprite mediumFire;

    /// <summary>
    /// Sprite for high fire.
    /// </summary>
    public Sprite highFire;

    /// <summary>
    /// Whether we are in battle mode or not
    /// </summary>
    public bool battleMode;
    
    // called once upon collision
    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        // do nothing if not in battle mode
        if (!battleMode) return;

        // play the sound effect
        source.Play();
        
        // optionally increase the health if gets hit by a wooden block
        if (!String.IsNullOrWhiteSpace(woodenBlockTag) && colInfo.gameObject.CompareTag(woodenBlockTag))
        {
            switch (currentFireLevel)
            {
                case 1: // promote low fire to medium fire
                    health += colInfo.relativeVelocity.magnitude;
                    GetComponent<SpriteRenderer>().sprite = mediumFire;
                    currentFireLevel++;
                    break;
                case 2: // promote medium fire to high fire
                    health += colInfo.relativeVelocity.magnitude;
                    GetComponent<SpriteRenderer>().sprite = highFire;
                    currentFireLevel++;
                    break;
            }
        }
        else
        {
            // if the collision is more than what the target can withstand then it gets destroyed
            if (health.CompareTo(colInfo.relativeVelocity.magnitude) <= 0) Destroy(gameObject);
            // else its health gets decreased
            else health -= colInfo.relativeVelocity.magnitude;
        }
    }

    // called before the first frame update
    private void Start()
    {
        // initialize the sound effect
        source = GetComponent<AudioSource>();
        
        if (lowFire == null || String.IsNullOrWhiteSpace(woodenBlockTag)) return;
        // initialize to low fire
        GetComponent<SpriteRenderer>().sprite = lowFire;
        currentFireLevel = 1;
    }
}