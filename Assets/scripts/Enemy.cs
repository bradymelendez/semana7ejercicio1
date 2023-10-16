using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public float enemySpeed = 3.0f;  
    public int enemyHealth = 100;   
    public int enemyDamage = 10;    
    public Transform player;        

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.LookAt(player);
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
