using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSon : MonoBehaviour
{
    // Liste des sons � jouer lors de la collision
    public List<AudioClip> mesSons;
    // Composant audio utilis� pour jouer les sons
    public AudioSource lecteurSon;

    // Fonction appel�e lors d'une collision 2D
    void OnCollisionEnter2D(Collision2D objet) {
        // V�rifie si l'objet en collision porte le tag "Player"
        if (objet.transform.tag == "Player") {
            // Arr�te tout son en cours de lecture
            lecteurSon.Stop();
            // S�lectionne al�atoirement un clip parmi les trois premiers de la liste
            lecteurSon.clip = mesSons[Random.Range(0, 3)];
            // Joue le clip s�lectionn�
            lecteurSon.Play();
        }
    }
}
