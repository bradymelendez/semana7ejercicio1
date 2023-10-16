using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;  // Velocidad de la bala
    public int damage = 10;     // Daño que inflige

    private void Update()
    {
        // Mueve la bala hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        //if (other.CompareTag("Enemy"))
        //{
        //    Enemy enemy = other.GetComponent<Enemy>();

        //    if (enemy != null)
        //    {
        //        // Inflige daño al enemigo
        //        enemy.TakeDamage(damage);
        //    }

        //    Destroy(gameObject);
        //}
     /*   else */if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
