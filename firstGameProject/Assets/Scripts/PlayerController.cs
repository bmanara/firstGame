using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 input;
    public Rigidbody2D rbPlayer;
    private Animator animator;

 
    private Vector2 mousePos;
    public GameObject weapon;
    public Rigidbody2D rbWeapon;
    public Camera cam;

    // Called when script is loaded
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Called every frame
    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Get position of mouse and update
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

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
        rbPlayer.MovePosition(rbPlayer.position + input * moveSpeed * Time.fixedDeltaTime);

        // Control weapon aim
        Vector2 lookDir = mousePos - rbWeapon.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(0, 0, angle);
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
