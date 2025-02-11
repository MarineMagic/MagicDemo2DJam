using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSon : MonoBehaviour
{
    // Liste des sons possibles à jouer lors d'une collision
    public List<AudioClip> mesSons;
    
    // Composant AudioSource utilisé pour jouer les sons
    public AudioSource lecteurSon;

    // Fonction appelée lorsqu'une collision 2D se produit
    void OnCollisionEnter2D(Collision2D objet) {
        // Vérifie si l'objet en collision a le tag "Player"
        if (objet.transform.tag == "Player") {
            // Arrête le son en cours pour éviter les superpositions
            lecteurSon.Stop();
            
            // Sélectionne aléatoirement un clip audio parmi les trois premiers de la liste
            if (mesSons.Count > 0) {
                lecteurSon.clip = mesSons[Random.Range(0, Mathf.Min(3, mesSons.Count))];
                
                // Joue le son sélectionné
                lecteurSon.Play();
            }
        }
    }
}
