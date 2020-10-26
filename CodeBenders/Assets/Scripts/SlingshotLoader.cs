using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Allows simple reloading of the slingshot with new projectiles.
/// </summary>
public class SlingshotLoader : MonoBehaviour
{
    // class-specific constant: the break force of the spring joint
    private const float SpringJointBreakForce = Single.PositiveInfinity;
    // class-specific constant: the damping ratio of the spring joint
    private const float SpringJointDampingRatio = 0f;
    // class-specific constant: the distance of the spring joint
    private const float SpringJointDistance = 0.005f;
    // class-specific constant: the frequency of the spring joint
    private const float SpringJointFrequency = 1.5f;
    // class-specific constant: time to wait in seconds for signaling reload
    private const int SecondsBeforeUnload = 1;

    /// <summary>
    /// The currently loaded projectile.
    /// </summary>
    public GameObject projectile;
    
    // the rigidbody component of the slingshot itself
    private Rigidbody2D _slingshotBody;

    /// <summary>
    /// Load the slingshot with a new projectile.
    /// </summary>
    /// <param name="projectileToLoad">The projectile to be loaded (w/o the spring joint component).</param>
    public void LoadProjectile(GameObject projectileToLoad)
    {
        // update the internal reference
        projectile = projectileToLoad ? projectileToLoad : throw new ArgumentNullException(nameof(projectileToLoad));
        // position the projectile
        projectile.transform.position = transform.position;

        // create the spring joint component for the slingshot
        var slingshotSpringJoint = projectile.AddComponent<SpringJoint2D>();
        slingshotSpringJoint.connectedBody = _slingshotBody;
        slingshotSpringJoint.distance = SpringJointDistance;
        slingshotSpringJoint.frequency = SpringJointFrequency;
        slingshotSpringJoint.dampingRatio = SpringJointDampingRatio;
        slingshotSpringJoint.breakForce = SpringJointBreakForce;
        
        // create the projectile component
        var projectileComponent = projectile.AddComponent<Projectile>();
        projectileComponent.allowFiring = true; // for now we always allow firing
        projectileComponent.slingshot = _slingshotBody;
    }

    /// <summary>
    /// Update the internal projectile reference and signal for reload after each firing.
    /// </summary>
    public IEnumerator ReloadProjectileCoroutine()
    {
        yield return new WaitForSeconds(SecondsBeforeUnload);
        projectile = null;
        GetComponent<ProjectileGenerator>().newProjectileNeeded = true;
    }
    
    // called before the first frame update
    private void Start() => _slingshotBody = GetComponent<Rigidbody2D>();
}
