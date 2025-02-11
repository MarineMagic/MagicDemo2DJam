using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIE : MonoBehaviour
{
    public SpriteRenderer remplissageVisuel; // Sprite du visuel de la barre de vie
    public float maxSantee = 10f; // Nombre maximum de PV
    public float SanteeEnCours; // PV actuels du personnage

    private Vector3 tailleInitiale; // Taille originale de l'indicateur de vie

    void Start() {
        // Au début du jeu, les PV sont égaux à la valeur maximale
        SanteeEnCours = maxSantee;
        // Sauvegarde la taille originale de l'indicateur de la barre de vie
        tailleInitiale = remplissageVisuel.transform.localScale;
    }

    void Update() {
        // Calcule la proportion des PV actuels par rapport aux PV maximum
        float healthRatio = SanteeEnCours / maxSantee;

        // Met à jour la taille de la barre de vie en fonction des PV
        remplissageVisuel.transform.localScale = new Vector3(tailleInitiale.x * healthRatio, tailleInitiale.y, tailleInitiale.z);
    }

    // Fonction pour appliquer des dégâts à la vie
    public void FaireDegats(float damage) {
        // Réduit la vie en fonction des dégâts reçus
        SanteeEnCours -= damage;
        // Assure que la vie ne soit pas inférieure à 0
        SanteeEnCours = Mathf.Clamp(SanteeEnCours, 0, maxSantee);
    }

    // Fonction pour soigner l'entité (augmenter sa vie)
    public void Soigne(float amount) {
        // Augmente la vie en fonction de la quantité de soins
        SanteeEnCours += amount;
        // Assure que la vie ne dépasse pas le maximum
        SanteeEnCours = Mathf.Clamp(SanteeEnCours, 0, maxSantee);
    }
}
