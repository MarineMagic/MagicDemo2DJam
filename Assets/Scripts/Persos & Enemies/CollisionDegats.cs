using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDegats : MonoBehaviour
{
    public float degatsMin = 10f; // D�g�ts minimum inflig�s
    public float degatsMax = 10f; // D�g�ts maximum inflig�s
    public string tagCible = ""; // Tag des objets qui peuvent recevoir des d�g�ts

    void OnCollisionEnter2D(Collision2D collision) {
        // V�rifie si l'objet touch� a le tag sp�cifi�
        if (collision.transform.tag == tagCible) { 
            // R�cup�re le script VIE de l'objet touch�
            VIE vie = collision.transform.GetComponent<VIE>();
            // Si l'objet a un script VIE, on inflige des d�g�ts
            if (vie != null) {
                float degatsInfliges = Random.Range(degatsMin, degatsMax); // Calcule les d�g�ts inflig�s
                vie.FaireDegats(degatsInfliges); // Applique les d�g�ts
                //si l'objet touch� � pris assez de degat pour tomber � 0 pv, et n'est pas le joueur (le joueur meurt differement)
                if (vie.SanteeEnCours <= 0 && collision.transform.tag != "Player") {
                    Destroy(collision.gameObject,0.1f); //on le d�truit avec un d�lai de 0.1 seconde
                }
            }
        }
    }
}