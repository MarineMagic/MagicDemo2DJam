using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurAttaque : MonoBehaviour
{
    // Référence à l'Animator pour gérer les animations du joueur
    public Animator animator; // Contrôle les animations comme l'attaque

    // Collider utilisé pour détecter les objets touchés par l'attaque
    public Collider2D attaqueCollider; // Zone de détection de l'attaque

    // Durée pendant laquelle l'attaque reste active
    public float dureeAttaque; // Temps en secondes avant que l'attaque ne se désactive

    void Start() {
        // On désactive le collider d'attaque au départ pour éviter qu'il ne touche des objets par erreur
        attaqueCollider.enabled = false;
    }

    void Update() {
        // On vérifie si le joueur a appuyé sur le bouton d'attaque (par défaut, clic gauche ou touche Ctrl)
        if (Input.GetButtonDown("Fire1")) {
            // On déclenche l'animation d'attaque
            animator.SetTrigger("Attaque");

            // On active le collider d'attaque pour qu'il puisse détecter des collisions
            attaqueCollider.enabled = true;

            // On ignore les collisions entre le collider d'attaque et le collider du joueur
            // Cela évite que le joueur ne s'attaque lui-même
            Physics2D.IgnoreCollision(attaqueCollider, GetComponent<Collider2D>());

            // On démarre un timer pour désactiver l'attaque après la durée spécifiée
            Timers.StartTimer(dureeAttaque, stopAttaque);
        }
    }

    // Méthode appelée à la fin du timer pour désactiver l'attaque
    void stopAttaque() {
        // On désactive le collider d'attaque
        attaqueCollider.enabled = false;
    }
}