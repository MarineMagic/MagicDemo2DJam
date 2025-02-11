using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurAttaque : MonoBehaviour
{
    // R�f�rence � l'Animator pour g�rer les animations du joueur
    public Animator animator; // Contr�le les animations comme l'attaque

    // Collider utilis� pour d�tecter les objets touch�s par l'attaque
    public Collider2D attaqueCollider; // Zone de d�tection de l'attaque

    // Dur�e pendant laquelle l'attaque reste active
    public float dureeAttaque; // Temps en secondes avant que l'attaque ne se d�sactive

    void Start() {
        // On d�sactive le collider d'attaque au d�part pour �viter qu'il ne touche des objets par erreur
        attaqueCollider.enabled = false;
    }

    void Update() {
        // On v�rifie si le joueur a appuy� sur le bouton d'attaque (par d�faut, clic gauche ou touche Ctrl)
        if (Input.GetButtonDown("Fire1")) {
            // On d�clenche l'animation d'attaque
            animator.SetTrigger("Attaque");

            // On active le collider d'attaque pour qu'il puisse d�tecter des collisions
            attaqueCollider.enabled = true;

            // On ignore les collisions entre le collider d'attaque et le collider du joueur
            // Cela �vite que le joueur ne s'attaque lui-m�me
            Physics2D.IgnoreCollision(attaqueCollider, GetComponent<Collider2D>());

            // On d�marre un timer pour d�sactiver l'attaque apr�s la dur�e sp�cifi�e
            Timers.StartTimer(dureeAttaque, stopAttaque);
        }
    }

    // M�thode appel�e � la fin du timer pour d�sactiver l'attaque
    void stopAttaque() {
        // On d�sactive le collider d'attaque
        attaqueCollider.enabled = false;
    }
}