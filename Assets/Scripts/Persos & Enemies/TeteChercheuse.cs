using UnityEngine;

public class TeteChercheuse : MonoBehaviour
{
    public Transform target; // La cible � suivre
    public float speed = 5f; // Vitesse de d�placement
    public float rotationSpeed = 200f; // Vitesse de rotation
    public float detectionDistance = 10f; // Distance de d�tection de la cible

    private Rigidbody2D rb;

    void Start() {
        // R�cup�rer le composant Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // V�rifier si la cible est � port�e
        if (Vector2.Distance(transform.position, target.position) <= detectionDistance) {
            // Calculer la direction vers la cible en 2D
            Vector2 direction = (target.position - transform.position).normalized;

            // Calculer l'angle de rotation vers la direction calcul�e
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // -90f pour ajuster l'orientation si n�cessaire

            // Faire tourner l'objet vers la direction calcul�e autour de l'axe Z
            Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

            // D�placer l'objet en utilisant Rigidbody2D pour respecter les collisions
            rb.velocity = transform.up * speed; // Utiliser transform.up pour avancer dans la direction actuelle
        }
        else {
            // Si la cible est hors de port�e, arr�ter le mouvement
            rb.velocity = Vector2.zero;
        }
    }
}