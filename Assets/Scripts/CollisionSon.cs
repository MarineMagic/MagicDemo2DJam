using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSon : MonoBehaviour
{
    // Liste des sons à jouer lors de la collision
    public List<AudioClip> mesSons;
    // Composant audio utilisé pour jouer les sons
    public AudioSource lecteurSon;

    // Fonction appelée lors d'une collision 2D
    void OnCollisionEnter2D(Collision2D objet) {
        // Vérifie si l'objet en collision porte le tag "Player"
        if (objet.transform.tag == "Player") {
            // Arrête tout son en cours de lecture
            lecteurSon.Stop();
            // Sélectionne aléatoirement un clip parmi les trois premiers de la liste
            lecteurSon.clip = mesSons[Random.Range(0, 3)];
            // Joue le clip sélectionné
            lecteurSon.Play();
        }
    }
}
