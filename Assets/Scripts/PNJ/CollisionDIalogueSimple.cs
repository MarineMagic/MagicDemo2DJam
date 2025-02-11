using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDIalogueSimple : MonoBehaviour
{
    // Liste des lignes de dialogue à afficher
    public List<string> mesLignes;
    // Référence au composant texte pour afficher le dialogue
    public TMPro.TMP_Text affichage;
    // Indice de la ligne de dialogue courante
    public int actuelle;

    // Fonction déclenchée lorsque le joueur entre dans la zone de collision
    void OnTriggerEnter2D(Collider2D objet) {
        // Vérifie si l'objet qui entre porte le tag "Player"
        if (objet.transform.tag == "Player") {
            // Affiche la ligne de dialogue correspondant à l'indice actuel
            affichage.text = mesLignes[actuelle];
            // Si l'indice actuel est 0, on le passe à 1 pour la prochaine interaction
            // on peut passer l'indice à n'importe quel chiffre selon la réplique, cela permet de faire des dialogues entiers
            //par exemple on peut verifier si le joueur possède un item, si oui mettre actuelle sur un certain chiffre, et si non, sur un autre.
            if (actuelle == 0) {
                actuelle = 1;
            }
        }
    }

    // Fonction déclenchée lorsque le joueur sort de la zone de collision
    void OnTriggerExit2D(Collider2D objet) {
        // Vérifie si l'objet qui sort porte le tag "Player"
        if (objet.transform.tag == "Player") {
            // Efface le texte du dialogue à la sortie
            affichage.text = "";
        }
    }
}
