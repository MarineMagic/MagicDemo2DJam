using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTir2D : MonoBehaviour
{
    public Transform player; // R�f�rence au joueur
    public float detectionDistance = 10f; // Distance de d�tection du joueur
    public float fireRate = 1f; // Taux de tir (en secondes)
    public GameObject projectilePrefab; // Pr�fab du projectile � tirer
    public Transform firePoint; // Point d'origine du tir
    public float puissance;

    private float timer = 0f;

    void Update() {
        // V�rifier si le joueur est � port�e
        if (Vector2.Distance(transform.position, player.position) <= detectionDistance) {

            // Orienter la tourelle vers le joueur (en 2D)
            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Calculer l'angle en degr�s
            transform.rotation = Quaternion.Euler(0f, 0f, angle); // Appliquer la rotation autour de l'axe Z

            // G�rer le tir
            if (timer <= 0f) {
                Tirer();
                timer = fireRate; // R�initialiser le timer
            }
            else {
                timer -= Time.deltaTime; // D�cr�menter le timer
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