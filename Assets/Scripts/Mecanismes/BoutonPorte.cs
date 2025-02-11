using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonPorte : MonoBehaviour
{
    // R�f�rence � l'objet porte que ce script va contr�ler
    public GameObject porte;

    // Fonction d�clench�e automatiquement lors d'une collision 2D
    void OnCollisionEnter2D(Collision2D objet) {
        // V�rifie si l'objet en collision porte le tag "Player"
        if (objet.transform.tag == "Player") {
            // Inverse l'�tat de la porte :
            // Si elle est active, elle sera d�sactiv�e, et vice-versa
            porte.SetActive(!porte.activeInHierarchy);
        }
    }
}
