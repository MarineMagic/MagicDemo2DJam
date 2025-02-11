using UnityEngine;
using System;
using System.Collections.Generic;

public class Timers : MonoBehaviour
{
    // Liste qui contient tous les timers actifs
    public static List<Timer> timers = new List<Timer>();

    private void Update() {
        // Boucle pour retirer les timers terminés
        foreach (Timer timer in timers) {
            timer.Update(Time.deltaTime);//met à jour les timers
            if (timer.fini)
                timers.Remove(timer);
                break; //pour eviter un message d'erreur dans la liste
        }
    }

    // fonction pour démarrer un nouveau timer, peut etre utilisée depuis n'importe quel script avec ce code:
    // Timers.StartTimer(TEMPS ICI, FONCTION ICI);
    public static void StartTimer(float duree, Action action) {
        timers.Add(new Timer(duree, action));
    }

    // Classe interne qui représente un timer individuel
    public class Timer
    {
        private float duree;      // Durée totale du timer
        private float tempsecoule;   // Temps écoulé depuis le démarrage du timer
        private Action action;     // Action à exécuter lorsque le timer se termine
        public bool fini;// Indique si le timer est terminé

        public Timer(float duration, Action callback) { //quand on génère un timer, on copie les chiffres donnés dans ses propres propriétés
            this.duree = duration;
            this.action = callback;
            tempsecoule = 0f;
            fini = false;
        }
        //et on fait tourner le timer
        public void Update(float deltaTime) {
            if (fini)
                return;
            tempsecoule += deltaTime;
            //si il est fini, il lance l'action qui à été attaché
            if (tempsecoule >= duree) {
                action?.Invoke();
                fini = true;
            }
        }
    }
}
