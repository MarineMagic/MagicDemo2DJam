using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clignotte : MonoBehaviour
{
    public int dureeClignotementmin = 1;  // Dur�e minimale entre chaque clignotement
    public int dureeClignotementmax = 1;  // Dur�e maximale entre chaque clignotement
    private bool isActive = false;        // �tat actuel (activ� ou d�sactiv�)
    private int dureeClignotement;

    private void Start() {
        //lancer le 1er clignotement
        dureeClignotement = Random.Range(dureeClignotementmin, dureeClignotementmax);
        Timers.StartTimer(dureeClignotement, Toggle);
    }

    // M�thode appel�e � la fin du timer pour inverser l'�tat et reprogrammer le timer
    private void Toggle() {
        // Inverse l'�tat de visibilit�
        isActive = !isActive;
        this.gameObject.SetActive(isActive);

        // Red�marrer un nouveau timer pour le prochain clignotement
        dureeClignotement = Random.Range(dureeClignotementmin, dureeClignotementmax);
        Timers.StartTimer(dureeClignotement, Toggle);
    }
}