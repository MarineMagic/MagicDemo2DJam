using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform arriver; // Point d'arrivée pour la téléportation
    public string quiPeut;    // Tag de l'objet qui peut déclencher la téléportation

    private void OnCollisionEnter2D(Collision2D collision) {
        // Vérifie si l'objet en collision a le bon tag
        if (collision.transform.tag == quiPeut) {
            // Téléporte l'objet à la position d'arrivée
            collision.transform.position = arriver.position;
        }
    }
}