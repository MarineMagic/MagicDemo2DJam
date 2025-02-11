using UnityEngine;
using System;
using System.Collections.Generic;

public class Timers : MonoBehaviour
{
    // Liste qui contient tous les timers actifs
    public static List<Timer> timers = new List<Timer>();

    private void Update() {
        // Boucle pour retirer les timers termin�s
        foreach (Timer timer in timers) {
            timer.Update(Time.deltaTime);//met � jour les timers
            if (timer.fini)
                timers.Remove(timer);
                break; //pour eviter un message d'erreur dans la liste
        }
    }

    // fonction pour d�marrer un nouveau timer, peut etre utilis�e depuis n'importe quel script avec ce code:
    // Timers.StartTimer(TEMPS ICI, FONCTION ICI);
    public static void StartTimer(float duree, Action action) {
        timers.Add(new Timer(duree, action));
    }

    // Classe interne qui repr�sente un timer individuel
    public class Timer
    {
        private float duree;      // Dur�e totale du timer
        private float tempsecoule;   // Temps �coul� depuis le d�marrage du timer
        private Action action;     // Action � ex�cuter lorsque le timer se termine
        public bool fini;// Indique si le timer est termin�

        public Timer(float duration, Action callback) { //quand on g�n�re un timer, on copie les chiffres donn�s dans ses propres propri�t�s
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
            //si il est fini, il lance l'action qui � �t� attach�
            if (tempsecoule >= duree) {
                action?.Invoke();
                fini = true;
            }
        }
    }
}
