using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 dir;
    public float power;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.attachedRigidbody.AddForce(dir * power, ForceMode2D.Impulse);
    }
}
