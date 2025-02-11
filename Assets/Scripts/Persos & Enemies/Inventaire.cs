using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : MonoBehaviour
{
    // Liste statique qui contient tous les objets de l'inventaire
    public static List<string> _inventaire = new List<string>(); 
    public List<string> vue_inventaire; // Liste pour afficher l'inventaire à l'écran (peut être utilisée pour l'UI)

    private void Update() {
        // Met à jour la vue de l'inventaire pour qu'elle reflète toujours l'inventaire actuel
        vue_inventaire = _inventaire; 
    }

    // Fonction pour ajouter un certain nombre d'objets à l'inventaire
    public static void AjouterAInventaire(string objet, int nombre) {
        // Ajoute l'objet "nombre" fois à l'inventaire
        for (int i = 0; i < nombre; i++) {
            _inventaire.Add(objet); // Ajoute un objet à la liste de l'inventaire
        }
    }

    // Fonction pour retirer un certain nombre d'objets de l'inventaire
    public static void RetirerdInventaire(string objet, int nombre) {
        // Retire l'objet "nombre" fois de l'inventaire
        for (int i = 0; i < nombre; i++) {
            _inventaire.Remove(objet); // Retire un objet de la liste de l'inventaire
        }
    }

    // Fonction pour compter combien de fois un objet est présent dans l'inventaire
    public static int CompterInventaire(string objet) {
        int count = 0; // Variable pour compter le nombre d'objets trouvés
        // Parcours tous les objets dans l'inventaire
        foreach (string item in _inventaire) {
            // Si l'objet trouvé est celui qu'on cherche, on incrémente le compteur
            if (item == objet) {
                count++;
            }
        }
        // Retourne le nombre d'occurrences de l'objet dans l'inventaire
        return count;
    }
}
