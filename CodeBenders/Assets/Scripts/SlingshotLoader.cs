using System;
using UnityEngine;

/// <summary>
/// Allows simple reloading of the slingshot with new projectiles.
/// </summary>
public class SlingshotLoader : MonoBehaviour
{
    // class-specific constant: the name of the projectile that is initially loaded to the slingshot
    private const string InitialProjectileName = "Projectile";
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

    // called before the first frame update
    private void Start()
    {
        // assumes that initially the slingshot is loaded with a projectile
        _projectile = GameObject.Find(InitialProjectileName) ?
            GameObject.Find(InitialProjectileName) :
            throw new UnityException("Initial projectile not found!");
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
