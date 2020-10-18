using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Behavior script for a single slingshot projectile.
/// </summary>
public class Projectile : MonoBehaviour
{
    // class-specific constant: how far is the player allowed to drag the projectile
    private const float MaxDragDistance = 3f;
    // class-specific constant: the delay after disabling SpringJoin2D component for actions like self-destruction
    private const float SpringJointPostDisableDelay = 6f;
    // class-specific constant: the delay after release to disable SpringJoint2D component
    private const float SpringJointReleaseDelay = 0.15f;

    /// <summary>
    /// Whether we are allowed firing the projectile.
    /// </summary>
    public bool allowFiring;
    
    /// <summary>
    /// The rigidbody component of the slingshot.
    /// </summary>
    public Rigidbody2D slingshot;
    
    // whether the projectile is being dragged by the user
    private bool _beingDragged;
    // the main camera
    private Camera _mainCamera;
    // the rigidbody component of the projectile itself
    private Rigidbody2D _projectileBody;
    // the spring joint of the projectile itself
    private SpringJoint2D _projectileSpringJoint;

    // coroutine to simulate actual slingshot firing of the projectile
    private IEnumerator FireCoroutine()
    {
        // disable the SpringJoint2D component after some delay to allow the projectile to fly freely
        yield return new WaitForSeconds(SpringJointReleaseDelay);
        _projectileSpringJoint.enabled = false;
        
        // update the telemetry counter
        GameObject.Find("Telemetry").SendMessage(
            gameObject.tag.Equals("ProjectileP1") ? "PlayerOneFired" : "PlayerTwoFired");
        
        // start the slingshot reload coroutine
        StartCoroutine(slingshot.gameObject.GetComponent<SlingshotLoader>().ReloadProjectileCoroutine());

        // wait before further actions such as self-destruction
        yield return new WaitForSeconds(SpringJointPostDisableDelay);

        //Change player name on display
        GameObject.FindWithTag("PlayerTurn").SendMessage("changePlayer", gameObject);
        Destroy(gameObject);
    }
    
    // event trigger for mouse click (left button down, also touch events on phones)
    private void OnMouseDown()
    {
        // short circuit if one is not allowed to fire
        if (!allowFiring) return;
        
        _beingDragged = true;
        // this allow the projectile to be dragged
        _projectileBody.isKinematic = true;
    }

    // event trigger for mouse release (also touch events on phones)
    private void OnMouseUp()
    {
        // short circuit if one is not allowed to fire
        if (!allowFiring) return;
        
        _beingDragged = false;
        // this allows the projectile to be controlled by the spring again, simulating a slingshot
        _projectileBody.isKinematic = false;
        // activate the slingshot fire coroutine
        StartCoroutine(FireCoroutine());
    }
    
    // called before the first frame update
    private void Start()
    {
        _beingDragged = false;
        _mainCamera = Camera.main;
        _projectileBody = GetComponent<Rigidbody2D>();
        _projectileSpringJoint = GetComponent<SpringJoint2D>();
    }

    // called once per frame
    private void Update()
    {
        // short circuit when the player is not or unable of dragging the projectile
        if (!_beingDragged || !_mainCamera) return;
        
        // update the projectile location to reflect it being dragged
        var mousePosition = (Vector2)_mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var slingshotPosition = slingshot.position;
        if (Vector2.Distance(mousePosition, slingshotPosition) > MaxDragDistance)
            _projectileBody.position = slingshotPosition +
                                    (mousePosition - slingshotPosition).normalized * MaxDragDistance;
        else _projectileBody.position = mousePosition;
    }
}
