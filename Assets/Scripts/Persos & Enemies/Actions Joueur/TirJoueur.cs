using UnityEngine;

public class TirJoueur : MonoBehaviour
{
    public GameObject projectilePrefab; // Le prefab du projectile à tirer
    public float forceTir = 10f;       // La force avec laquelle le projectile est tiré
    public static int munitions = 10; // Nombre de munitions que le joueur a

    void Update() {
        // Vérifie si le bouton Fire2 (clic droit) est pressé et j'ai des munitions
        if (Input.GetButtonDown("Fire2") && munitions > 0) {
            Tirer();
        }
    }

    void Tirer() {
        // Calcule la direction du tir en fonction de la position de la souris
        Vector2 positionSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (positionSouris - (Vector2)transform.position).normalized;

        // Instancie le projectile à la position du joueur
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Applique une force au projectile dans la direction calculée
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * forceTir, ForceMode2D.Impulse);

        // Ignore les collisions entre le projectile et le joueur
        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        munitions -= 1;
    }
}