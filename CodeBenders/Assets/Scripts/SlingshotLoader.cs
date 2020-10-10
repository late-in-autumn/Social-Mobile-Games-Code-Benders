using System;
using UnityEngine;
using UnityEngine.Serialization;

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

    // the projectile that is being currently loaded
    private GameObject _projectile;
    // the rigidbody component of the slingshot itself
    private Rigidbody2D _slingshotBody;

    /// <summary>
    /// The initial projectile object. Will be removed in the future.
    /// </summary>
    public GameObject initialProjectile;

    // called before the first frame update
    private void Start()
    {
        _projectile = initialProjectile;
        _slingshotBody = GetComponent<Rigidbody2D>();
    }
    
    /// <summary>
    /// Load the slingshot with a new projectile.
    /// </summary>
    /// <param name="projectile">The projectile to be loaded (w/o the spring joint component).</param>
    public void LoadProjectile(GameObject projectile)
    {
        // update the internal reference
        _projectile = projectile ? projectile : throw new ArgumentNullException(nameof(projectile));
        // position the projectile
        _projectile.transform.position = transform.position;

        // create the spring joint component for the slingshot
        var slingshotSpringJoint = _projectile.AddComponent<SpringJoint2D>();
        slingshotSpringJoint.connectedBody = _slingshotBody;
        slingshotSpringJoint.distance = SpringJointDistance;
        slingshotSpringJoint.frequency = SpringJointFrequency;
        slingshotSpringJoint.dampingRatio = SpringJointDampingRatio;
        slingshotSpringJoint.breakForce = SpringJointBreakForce;
    }

    /// <summary>
    /// Update the internal projectile reference after being fired.
    /// </summary>
    public void UnloadProjectileAfterFire()
    {
        _projectile = null;
    }
}
