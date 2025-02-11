using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clignotte : MonoBehaviour
{
    public int dureeClignotementmin = 1;  // Durée minimale entre chaque clignotement
    public int dureeClignotementmax = 1;  // Durée maximale entre chaque clignotement
    private bool isActive = false;        // État actuel (activé ou désactivé)
    private int dureeClignotement;

    private void Start() {
        //lancer le 1er clignotement
        dureeClignotement = Random.Range(dureeClignotementmin, dureeClignotementmax);
        Timers.StartTimer(dureeClignotement, Toggle);
    }

    // Méthode appelée à la fin du timer pour inverser l'état et reprogrammer le timer
    private void Toggle() {
        // Inverse l'état de visibilité
        isActive = !isActive;
        this.gameObject.SetActive(isActive);

        // Redémarrer un nouveau timer pour le prochain clignotement
        dureeClignotement = Random.Range(dureeClignotementmin, dureeClignotementmax);
        Timers.StartTimer(dureeClignotement, Toggle);
    }
}