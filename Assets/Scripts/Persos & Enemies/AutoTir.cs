using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTir2D : MonoBehaviour
{
    public Transform player; // Référence au joueur
    public float detectionDistance = 10f; // Distance de détection du joueur
    public float fireRate = 1f; // Taux de tir (en secondes)
    public GameObject projectilePrefab; // Préfab du projectile à tirer
    public Transform firePoint; // Point d'origine du tir
    public float puissance;

    private float timer = 0f;

    void Update() {
        // Vérifier si le joueur est à portée
        if (Vector2.Distance(transform.position, player.position) <= detectionDistance) {

            // Orienter la tourelle vers le joueur (en 2D)
            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Calculer l'angle en degrés
            transform.rotation = Quaternion.Euler(0f, 0f, angle); // Appliquer la rotation autour de l'axe Z

            // Gérer le tir
            if (timer <= 0f) {
                Tirer();
                timer = fireRate; // Réinitialiser le timer
            }
            else {
                timer -= Time.deltaTime; // Décrémenter le timer
            }
        }
    }

    void Tirer() {
        // Instancier le projectile et le lancer dans la direction du joueur
        if (projectilePrefab && firePoint) {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            // Appliquer une vitesse au projectile (en 2D)
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb) {
                Vector2 direction = (player.position - firePoint.position).normalized;
                rb.velocity = direction * puissance; // Ajuste la vitesse selon tes besoins
            }
        }
    }
}