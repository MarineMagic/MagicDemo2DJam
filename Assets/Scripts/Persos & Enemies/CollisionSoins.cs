using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoins : MonoBehaviour
{
    public float soinsMin = 10f; // soins minimum inflig�s
    public float soinsMax = 10f; // soins maximum inflig�s
    public string tagCible = ""; // Tag des objets qui peuvent recevoir des soins

    void OnCollisionEnter2D(Collision2D collision) {
        // V�rifie si l'objet touch� a le tag sp�cifi�
        if (collision.gameObject.CompareTag(tagCible)) {
            // R�cup�re le script VIE de l'objet touch�
            VIE vie = collision.gameObject.GetComponent<VIE>();

            // Si l'objet a un script VIE, on inflige des d�g�ts
            if (vie != null) {
                float soinsInfliges = Random.Range(soinsMin, soinsMax); // Calcule les d�g�ts inflig�s
                vie.Soigne(soinsInfliges); // Applique les d�g�ts
            }
        }
    }
}
