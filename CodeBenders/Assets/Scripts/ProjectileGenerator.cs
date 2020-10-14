using System;
using UnityEngine;

/// <summary>
/// Generate a new projectile for reloading.
/// </summary>
public class ProjectileGenerator : MonoBehaviour
{
    /// <summary>
    /// Whether we allow reloading.
    /// </summary>
    public bool allowReloading;
    
    /// <summary>
    /// Whether a new projectile is needed.
    /// </summary>
    public bool newProjectileNeeded;
    
    /// <summary>
    /// The tag that indicates which player the projectile belongs to.
    /// </summary>
    public string projectileTag;
    
    /// <summary>
    /// The sprite for the generated projectile.
    /// </summary>
    public Sprite projectileSprite;
    
    /// <summary>
    /// The sorting order of the generated projectile.
    /// </summary>
    public int projectileSortingOrder;
    
    /// <summary>
    /// The collider radius of the generated projectile.
    /// </summary>
    public float projectColliderRadius;
    
    /// <summary>
    /// The mass of the generated projectile.
    /// </summary>
    public float projectileMass;
    
    /// <summary>
    /// The linear drag of the generated projectile.
    /// </summary>
    public float projectileLinearDrag;
    
    /// <summary>
    /// The angular drag of the generated projectile.
    /// </summary>
    public float projectileAngularDrag;
    
    /// <summary>
    /// The gravity scale of the generated projectile.
    /// </summary>
    public float projectileGravityScale;
    
    // the slingshot loader component
    private SlingshotLoader _slingshotLoader;

    /// <summary>
    /// Generates a projectile and returns the corresponding game object.
    /// </summary>
    /// <param name="sprite">The sprite to be used.</param>
    /// <param name="sortingOrder">The sorting or rendering order of the projectile.</param>
    /// <param name="radius">The collider radius of the projectile.</param>
    /// <param name="mass">The mass of the projectile.</param>
    /// <param name="linearDrag">The linear drag of the projectile.</param>
    /// <param name="angularDrag">The angular drag of the projectile.</param>
    /// <param name="gravityScale">The gravity scale of the projectile.</param>
    /// <returns>The game object corresponding to the generated projectile.</returns>
    public GameObject GenerateProjectile(Sprite sprite,
        int sortingOrder,
        float radius,
        float mass,
        float linearDrag,
        float angularDrag,
        float gravityScale)
    {
        // include a GUID in the name so no name collision could be possible
        var projectile = new GameObject("Projectile (" + Guid.NewGuid() + ")", 
            new []{typeof(CircleCollider2D), typeof(SpriteRenderer), typeof(Rigidbody2D)});
        // tag the projectile
        projectile.tag = projectileTag;
        // place the projectile in the same hierarchy as the slingshot
        projectile.transform.parent = transform.parent;
        
        // set up the parameters of the projectile
        projectile.GetComponent<SpriteRenderer>().sprite = sprite;
        projectile.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
        projectile.GetComponent<CircleCollider2D>().radius = radius;
        projectile.GetComponent<Rigidbody2D>().simulated = true;
        projectile.GetComponent<Rigidbody2D>().mass = mass;
        projectile.GetComponent<Rigidbody2D>().drag = linearDrag;
        projectile.GetComponent<Rigidbody2D>().angularDrag = angularDrag;
        projectile.GetComponent<Rigidbody2D>().gravityScale = gravityScale;

        return projectile;
    }
    
    //called before the first frame update
    private void Start() => _slingshotLoader = GetComponent<SlingshotLoader>();

    // called once per frame
    private void Update()
    {
        if (!allowReloading || !newProjectileNeeded) return; // short circuit for not needing a new projectile
        
        // currently this script handles invocation and reloading, but this should be moved out to somewhere else
        _slingshotLoader.LoadProjectile(
            GenerateProjectile(
                projectileSprite, projectileSortingOrder, projectColliderRadius, projectileMass,
                projectileLinearDrag, projectileAngularDrag, projectileGravityScale));
        // that the projectile has been reloaded and a new one is no longer needed
        newProjectileNeeded = false;
    }
}
