using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;

    // Called every frame
    private void Update()
    {
        // If not moving, check for input
        if (!isMoving) 
        {
            // Stick with GetAxisRaw?
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                // transform.position is the stored position of our player, seen from Unity
                var targetPos = transform.position;

                // Change position of player based on input
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos)); // Runs constantly in our game
            }
        }
    }

    // Unity Coroutine functions and IEnumerators
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        // Move only if needed
        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }
}