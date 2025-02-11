using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDIalogueSimple : MonoBehaviour
{
    // Liste des lignes de dialogue � afficher
    public List<string> mesLignes;
    // R�f�rence au composant texte pour afficher le dialogue
    public TMPro.TMP_Text affichage;
    // Indice de la ligne de dialogue courante
    public int actuelle;

    // Fonction d�clench�e lorsque le joueur entre dans la zone de collision
    void OnTriggerEnter2D(Collider2D objet) {
        // V�rifie si l'objet qui entre porte le tag "Player"
        if (objet.transform.tag == "Player") {
            // Affiche la ligne de dialogue correspondant � l'indice actuel
            affichage.text = mesLignes[actuelle];
            // Si l'indice actuel est 0, on le passe � 1 pour la prochaine interaction
            if (actuelle == 0) {
                actuelle = 1;
            }
        }
    }

    // Fonction d�clench�e lorsque le joueur sort de la zone de collision
    void OnTriggerExit2D(Collider2D objet) {
        // V�rifie si l'objet qui sort porte le tag "Player"
        if (objet.transform.tag == "Player") {
            // Efface le texte du dialogue � la sortie
            affichage.text = "";
        }
    }
}
