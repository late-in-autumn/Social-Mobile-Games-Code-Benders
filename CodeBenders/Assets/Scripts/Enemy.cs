﻿using UnityEngine;

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

    // called once upon collision
    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        source.Play();

        // optionally increase the health if gets hit by a wooden block
        if (!String.IsNullOrWhiteSpace(woodenBlockTag))
        {
            if (!colInfo.gameObject.CompareTag(woodenBlockTag)) return;
            
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
        if (lowFire == null || String.IsNullOrWhiteSpace(woodenBlockTag)) return;
        // initialize to low fire
        GetComponent<SpriteRenderer>().sprite = lowFire;
        currentFireLevel = 1;
    }
}