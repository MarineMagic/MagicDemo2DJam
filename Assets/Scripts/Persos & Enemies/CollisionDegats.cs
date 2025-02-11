using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDegats : MonoBehaviour
{
    public float degatsMin = 10f; // Dégâts minimum infligés
    public float degatsMax = 10f; // Dégâts maximum infligés
    public string tagCible = ""; // Tag des objets qui peuvent recevoir des dégâts

    void OnCollisionEnter2D(Collision2D collision) {
        // Vérifie si l'objet touché a le tag spécifié
        if (collision.transform.tag == tagCible) { 
            // Récupère le script VIE de l'objet touché
            VIE vie = collision.transform.GetComponent<VIE>();
            // Si l'objet a un script VIE, on inflige des dégâts
            if (vie != null) {
                float degatsInfliges = Random.Range(degatsMin, degatsMax); // Calcule les dégâts infligés
                vie.FaireDegats(degatsInfliges); // Applique les dégâts
                //si l'objet touché à pris assez de degat pour tomber à 0 pv, et n'est pas le joueur (le joueur meurt differement)
                if (vie.SanteeEnCours <= 0 && collision.transform.tag != "Player") {
                    Destroy(collision.gameObject,0.1f); //on le détruit avec un délai de 0.1 seconde
                }
            }
        }
    }
}