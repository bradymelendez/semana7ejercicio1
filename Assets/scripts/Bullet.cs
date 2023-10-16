using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;  // Velocidad de la bala
    public int damage = 10;     // Daño que inflige
    public float lifetime = 2.0f; // Tiempo de vida de la bala

    private float elapsedTime = 0.0f;

    private void Update()
    {
        // Mueve la bala hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Actualiza el tiempo transcurrido
        elapsedTime += Time.deltaTime;

        // Destruye la bala si ha superado su tiempo de vida
        if (elapsedTime >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si la bala ha colisionado con un enemigo
        if (other.CompareTag("Enemy"))
        {
            // Accede al componente del enemigo
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                // Inflige daño al enemigo
                enemy.TakeDamage(damage);
            }

            // Destruye la bala cuando colisiona con un enemigo
            Destroy(gameObject);
        }
        else if (other.CompareTag("Obstacle"))
        {
            // Destruye la bala si colisiona con un obstáculo
            Destroy(gameObject);
        }
    }
}
