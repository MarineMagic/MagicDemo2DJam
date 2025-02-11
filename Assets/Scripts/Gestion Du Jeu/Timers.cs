using UnityEngine;
using System;
using System.Collections.Generic;

public class Timers : MonoBehaviour
{
    // Liste qui contient tous les timers actifs
    public static List<Timer> timers = new List<Timer>();

    private void Update() {
        // Boucle pour mettre à jour et retirer les timers terminés
        foreach (Timer timer in timers) {
            timer.Update(Time.deltaTime); // Met à jour le timer avec le temps écoulé
            if (timer.fini) {
                timers.Remove(timer); // Supprime le timer s'il est terminé
                break; // Sort de la boucle pour éviter des erreurs de modification de la liste
            }
        }
    }

    // Fonction pour démarrer un nouveau timer
    // Utilisation : Timers.StartTimer(TEMPS, FONCTION);
    public static void StartTimer(float duree, Action action) {
        timers.Add(new Timer(duree, action)); // Ajoute un nouveau timer à la liste
    }

    // Classe interne qui représente un timer individuel
    public class Timer
    {
        private float duree;         // Durée totale du timer
        private float tempsecoule;   // Temps écoulé depuis le démarrage du timer
        private Action action;       // Action à exécuter lorsque le timer se termine
        public bool fini;            // Indique si le timer est terminé

        // Constructeur : initialise le timer avec une durée et une action
        public Timer(float duration, Action callback) {
            this.duree = duration;
            this.action = callback;
            tempsecoule = 0f;
            fini = false;
        }

        // Met à jour le timer avec le temps écoulé
        public void Update(float deltaTime) {
            if (fini) return; // Si le timer est déjà terminé, ne rien faire

            tempsecoule += deltaTime; // Ajoute le temps écoulé

            // Si le temps écoulé dépasse la durée, exécute l'action et marque le timer comme terminé
            if (tempsecoule >= duree) {
                action?.Invoke(); // Exécute l'action si elle existe
                fini = true;      // Marque le timer comme terminé
            }
        }
    }
}