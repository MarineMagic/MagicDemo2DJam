using UnityEngine;

public class TeteChercheuse : MonoBehaviour
{
    public Transform target; // La cible à suivre (un autre objet, par exemple un joueur)
    public float speed = 5f; // Vitesse de déplacement de l'objet
    public float rotationSpeed = 200f; // Vitesse de rotation pour tourner vers la cible
    public float detectionDistance = 10f; // Distance à laquelle la cible est détectée

    private Rigidbody2D rb; // Référence au Rigidbody2D pour gérer la physique de l'objet

    void Start() {
        // Récupère le composant Rigidbody2D attaché à l'objet (pour gérer les déplacements physiques)
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // Vérifie si la cible est dans la portée de détection
        if (Vector2.Distance(transform.position, target.position) <= detectionDistance) {
            // Calcule la direction vers la cible en 2D
            Vector2 direction = (target.position - transform.position).normalized;

            // Calcule l'angle nécessaire pour tourner vers la cible
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // On ajuste l'angle de -90° si nécessaire pour l'orientation

            // Applique une rotation fluide pour tourner vers la cible
            Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward); // Crée la rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed); // Rotation douce vers la cible

            // Déplace l'objet en fonction de sa rotation (avance dans la direction de "transform.up")
            rb.velocity = transform.up * speed; // Utilise "transform.up" pour avancer dans la direction de l'objet
        }
        else {
            // Si la cible est trop loin, arrête le mouvement
            rb.velocity = Vector2.zero; // Arrête l'objet
        }
    }
}
