using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTir2D : MonoBehaviour
{
    public Transform player; // Référence au joueur, pour savoir où il se trouve
    public float detectionDistance = 10f; // Distance à laquelle la tourelle détecte le joueur
    public float fireRate = 1f; // Temps entre chaque tir (en secondes)
    public GameObject projectilePrefab; // Le modèle du projectile à tirer
    public Transform firePoint; // Le point d'origine du tir (l'endroit où le projectile apparaît)
    public float puissance; // La puissance du tir, pour la vitesse du projectile

    private float timer = 0f; // Un timer pour contrôler la cadence de tir

    void Update() {
        // Vérifie si le joueur est à portée (distance par rapport à la tourelle)
        if (Vector2.Distance(transform.position, player.position) <= detectionDistance) {

            // Oriente la tourelle vers le joueur (en 2D)
            Vector2 direction = (player.position - transform.position).normalized; // Trouve la direction vers le joueur
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Calcul l'angle en degrés pour la rotation
            transform.rotation = Quaternion.Euler(0f, 0f, angle); // Applique la rotation sur l'axe Z

            // Gère le tir
            if (timer <= 0f) {
                Tirer(); // Appelle la fonction pour tirer
                timer = fireRate; // Réinitialise le timer pour le prochain tir
            }
            else {
                timer -= Time.deltaTime; // Décrémente le timer à chaque frame
            }
        }
    }

    void Tirer() {
        // Crée le projectile et l'envoie dans la direction du joueur
        if (projectilePrefab && firePoint) {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation); // Crée une copie du projectile

            // Applique une vitesse au projectile (le fait bouger)
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>(); // Récupère le composant physique du projectile
            if (rb) {
                Vector2 direction = (player.position - firePoint.position).normalized; // Trouve la direction du tir
                rb.velocity = direction * puissance; // Donne une vitesse au projectile en fonction de la direction et de la puissance
            }
        }
    }
}
