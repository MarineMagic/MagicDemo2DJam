using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamasserMunition : MonoBehaviour
{
    public int quantitee;       // Quantité de munitions ramassée

    private void OnCollisionEnter2D(Collision2D collision) {
        // Vérifie si le joueur entre en collision avec cet objet
        if (collision.transform.tag == "Player") {
            
            TirJoueur.munitions += quantitee; //ajouter la bonne quantitée de munitions au joueur

            // Détruit l'objet ramassé
            Destroy(this.gameObject);
        }
    }
}