using UnityEngine;

public class TirJoueur : MonoBehaviour
{
    public GameObject projectilePrefab; // Le prefab du projectile � tirer
    public float forceTir = 10f; // La force avec laquelle le projectile est tir�

    void Update() {
        // V�rifie si le bouton Fire2 (clic droit) est press�
        if (Input.GetButtonDown("Fire2")) {
            Tirer();
        }
    }

    void Tirer() {
        // Calcule la direction du tir en fonction de la position de la souris
        Vector2 positionSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (positionSouris - (Vector2)transform.position).normalized;

        // Instancie le projectile � la position du joueur
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Applique une force au projectile dans la direction calcul�e
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * forceTir, ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}