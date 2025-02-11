using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIE : MonoBehaviour
{
    public SpriteRenderer remplissageVisuel; // Le sprite de la partie changeant de la barre de vie
    public float maxSantee = 10f; // PV max
    public float SanteeEnCours; // PV actuels

    private Vector3 tailleInitiale; // Taille initiale du sprite de l'indicateur

    void Start() {
        SanteeEnCours = maxSantee;
        tailleInitiale = remplissageVisuel.transform.localScale; // Sauvegarde la taille initiale
    }

    void Update() {
        // Calcule la proportion des PV actuels par rapport aux PV max
        float healthRatio = SanteeEnCours / maxSantee;

        // Met à jour l'échelle du sprite de l'indicateur
        remplissageVisuel.transform.localScale = new Vector3(tailleInitiale.x * healthRatio, tailleInitiale.y, tailleInitiale.z);
    }

    public void FaireDegats(float damage) {
        SanteeEnCours -= damage;
        SanteeEnCours = Mathf.Clamp(SanteeEnCours, 0, maxSantee); // Assure que les PV ne descendent pas en dessous de 0
    }

    public void Soigne(float amount) {
        SanteeEnCours += amount;
        SanteeEnCours = Mathf.Clamp(SanteeEnCours, 0, maxSantee); // Assure que les PV ne dépassent pas le max
    }
}
