using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoins : MonoBehaviour
{
    public float soinsMin = 10f; // soins minimum infligés
    public float soinsMax = 10f; // soins maximum infligés
    public string tagCible = ""; // Tag des objets qui peuvent recevoir des soins

    void OnCollisionEnter2D(Collision2D collision) {
        // Vérifie si l'objet touché a le tag spécifié
        if (collision.gameObject.CompareTag(tagCible)) {
            // Récupère le script VIE de l'objet touché
            VIE vie = collision.gameObject.GetComponent<VIE>();

            // Si l'objet a un script VIE, on inflige des dégâts
            if (vie != null) {
                float soinsInfliges = Random.Range(soinsMin, soinsMax); // Calcule les dégâts infligés
                vie.Soigne(soinsInfliges); // Applique les dégâts
            }
        }
    }
}
