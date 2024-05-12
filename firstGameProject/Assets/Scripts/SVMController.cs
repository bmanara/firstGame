using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float bulletSpeed = 20f;
    private float fireRate = 0.5f;
    private float canFire = 0.1f;

    private Vector2 mousePos;
    public Rigidbody2D rbWeapon;
    public AudioManager audioManager;
    
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > canFire)
        {
            Shoot();
            canFire = Time.time + fireRate;
        }

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Flip gun sprite based on mouse position
        if (mousePos.x < rbWeapon.position.x)
        {
            // Left
            GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            // Right
            GetComponent<SpriteRenderer>().flipY = false;
        }
    }

    void Shoot()
    {
        audioManager.PlaySFX(audioManager.shoot);
        // Create bullet at firePoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // Give bullet velocity
        rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        // Rotate the gun based on mouse position
        Vector2 lookDir = mousePos - rbWeapon.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
