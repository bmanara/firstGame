using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 input;
    private Rigidbody2D rb;
    private Animator animator;

    // Called when script is loaded
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Called every frame
    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (input != Vector2.zero)
        {
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void FixedUpdate()
    {
        // Control movement using Rigidbody
        rb.MovePosition(rb.position + input * moveSpeed * Time.fixedDeltaTime);
    }

    // Unity Coroutine functions and IEnumerators
    /*
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
    */
}
