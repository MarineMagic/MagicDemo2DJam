using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSiObjet : MonoBehaviour
{
    public string objetCheck; // Nom de l'objet à vérifier dans l'inventaire
    public int quantitee;     // Quantité requise de l'objet
    public GameObject ObjetActiDesactivable; // Objet à activer/désactiver

    private void OnCollisionEnter2D(Collision2D collision) {
        // Vérifie si le joueur entre en collision avec cet objet
        if (collision.transform.tag == "Player") {
            // Vérifie si le joueur a l'objet requis dans son inventaire
            if (Inventaire.CompterInventaire(objetCheck) >= quantitee) {
                // Inverse l'état de l'objet (actif/inactif)
                ObjetActiDesactivable.SetActive(!ObjetActiDesactivable.activeInHierarchy);

                // Retire la quantité requise de l'objet de l'inventaire
                Inventaire.RetirerdInventaire(objetCheck, quantitee);
            }
        }
    }
}