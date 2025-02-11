using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonPorte : MonoBehaviour
{
    // Référence à l'objet porte que ce script va contrôler
    public GameObject porte;

    // Fonction déclenchée automatiquement lors d'une collision 2D
    void OnCollisionEnter2D(Collision2D objet) {
        // Vérifie si l'objet en collision porte le tag "Player"
        if (objet.transform.tag == "Player") {
            // Inverse l'état de la porte :
            // Si elle est active, elle sera désactivée, et vice-versa
            porte.SetActive(!porte.activeInHierarchy);
        }
    }
}
