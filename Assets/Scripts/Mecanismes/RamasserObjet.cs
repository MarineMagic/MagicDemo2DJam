using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamasserObjet : MonoBehaviour
{
    public string objetRamasse; // Nom de l'objet à ramasser
    public int quantitee;       // Quantité de l'objet à ajouter à l'inventaire

    private void OnCollisionEnter2D(Collision2D collision) {
        // Vérifie si le joueur entre en collision avec cet objet
        if (collision.transform.tag == "Player") {
            // Ajoute l'objet à l'inventaire du joueur
            Inventaire.AjouterAInventaire(objetRamasse, quantitee);

            // Détruit l'objet ramassé
            Destroy(this.gameObject);
        }
    }
}