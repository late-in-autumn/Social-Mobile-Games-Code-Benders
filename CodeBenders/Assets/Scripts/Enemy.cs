using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 2f;

    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.relativeVelocity.magnitude > health) Destroy(gameObject);
    }
}