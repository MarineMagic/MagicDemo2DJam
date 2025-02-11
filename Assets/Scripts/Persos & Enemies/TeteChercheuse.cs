using UnityEngine;

public class TeteChercheuse : MonoBehaviour
{
    public Transform target; // La cible à suivre
    public float speed = 5f; // Vitesse de déplacement
    public float rotationSpeed = 200f; // Vitesse de rotation
    public float detectionDistance = 10f; // Distance de détection de la cible

    private Rigidbody2D rb;

    void Start() {
        // Récupérer le composant Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // Vérifier si la cible est à portée
        if (Vector2.Distance(transform.position, target.position) <= detectionDistance) {
            // Calculer la direction vers la cible en 2D
            Vector2 direction = (target.position - transform.position).normalized;

            // Calculer l'angle de rotation vers la direction calculée
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // -90f pour ajuster l'orientation si nécessaire

            // Faire tourner l'objet vers la direction calculée autour de l'axe Z
            Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

            // Déplacer l'objet en utilisant Rigidbody2D pour respecter les collisions
            rb.velocity = transform.up * speed; // Utiliser transform.up pour avancer dans la direction actuelle
        }
        else {
            // Si la cible est hors de portée, arrêter le mouvement
            rb.velocity = Vector2.zero;
        }
    }
}