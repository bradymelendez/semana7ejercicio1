using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public int playerDamage = 10;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public int maxPlayerHealth = 100;

    private int playerHealth;
    private float shootCooldown = 0.5f; 
    private float lastShootTime;

    private void Start()
    {
        playerHealth = maxPlayerHealth; 
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Move(horizontalInput, verticalInput);

        if (Input.GetButtonDown("Fire1") && Time.time > lastShootTime + shootCooldown)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    private void Move(float horizontalInput, float verticalInput)
    {
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * playerSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(newBullet, 2.0f); 
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0)
        {
            Debug.Log("FAIL");
        }
    }
}
