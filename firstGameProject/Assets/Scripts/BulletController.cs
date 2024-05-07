using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Can add more tags if needed
        // Can add animations or sound effects here as well

        // Destroy the bullet after collision
        Destroy(gameObject);

        // Destroy the bullet after a certain amount of time
        Destroy(gameObject, 2f);
    }
}
