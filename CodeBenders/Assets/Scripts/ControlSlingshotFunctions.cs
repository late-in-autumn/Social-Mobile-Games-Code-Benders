using UnityEngine;

/// <summary>
/// Standalone component for enabling and disabling slingshot functions.
/// </summary>
public class ControlSlingshotFunctions : MonoBehaviour
{
    /// <summary>
    /// Disables one from firing the projectile.
    /// </summary>
    public void DisableProjectileFiring()
    {
        if (GetComponent<SlingshotLoader>().projectile)
            GetComponent<SlingshotLoader>().projectile.GetComponent<Projectile>().allowFiring = false;
    }
    
    /// <summary>
    /// Disables the slingshot reloading mechanism.
    /// </summary>
    public void DisableSlingshotReloading() => GetComponent<ProjectileGenerator>().allowReloading = false;

    /// <summary>
    /// Enables one from firing the projectile.
    /// </summary>
    public void EnableProjectileFiring()
    {
        if (GetComponent<SlingshotLoader>().projectile)
            GetComponent<SlingshotLoader>().projectile.GetComponent<Projectile>().allowFiring = true;
    }

    /// <summary>
    /// Enables the slingshot reloading mechanism.
    /// </summary>
    public void EnableSlingshotReloading() => GetComponent<ProjectileGenerator>().allowReloading = true;
}
