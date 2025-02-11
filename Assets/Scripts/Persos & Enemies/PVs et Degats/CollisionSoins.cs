using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoins : MonoBehaviour
{
    public float soinsMin = 10f; // Soins minimum qui peuvent être pris
    public float soinsMax = 10f; // Soins maximum qui peuvent être pris
    public string tagCible = ""; // Tag des objets qui peuvent recevoir des soins

    void OnCollisionEnter2D(Collision2D collision) {
        // Vérifie si l'objet touché a le tag spécifié
        if (collision.gameObject.CompareTag(tagCible)) {
            // Récupère le script VIE de l'objet touché
            VIE vie = collision.gameObject.GetComponent<VIE>();

            // Si l'objet a un script VIE, on applique les soins
            if (vie != null) {
                // Calcule un montant de soins aléatoire entre soinsMin et soinsMax
                float soinsInfliges = Random.Range(soinsMin, soinsMax);
                vie.Soigne(soinsInfliges); // Applique les soins
            }
        }
    }
}
