using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrouille : MonoBehaviour
{
    // Variables publiques
    public float vitesse = 1f; // Vitesse de déplacement
    public List<GameObject> destinations; // Liste des destinations à suivre
    public bool boucle = true; // Si true, le chemin est bouclé, sinon l’objet s’arrête une fois arrivé au bout
    public bool hasard = false; // Si true, les points sont choisis au hasard, sinon c'est dans l'ordre de la liste
    public float attente = 0; // Temps d'attente à chaque point

    // Variables privées
    private int indiceDestination = 0; // Indice de la destination courante
    private float tolerance = 0.1f; // Distance minimale pour considérer qu’une destination est atteinte
    private bool arrive; // Indique si l'objet est arrivé à destination

    void Update() {
        // Déplace l’objet vers la destination actuelle
        transform.position = Vector2.MoveTowards(transform.position, destinations[indiceDestination].transform.position, vitesse * Time.deltaTime);
        
        // Vérifie si l’objet est suffisamment proche de la destination
        if (Vector2.Distance(transform.position, destinations[indiceDestination].transform.position) < tolerance && !arrive) {
            arrive = true; // Marque l'objet comme arrivé
            Timers.StartTimer(attente, NouveauPoint); // Démarre un timer avant de passer au prochain point
        }
    }

    private void NouveauPoint() {
        // Sélectionne le prochain point en fonction du mode choisi
        if (hasard) {
            indiceDestination = Random.Range(0, destinations.Count); // Choix aléatoire d'une destination
        }
        else {
            indiceDestination++; // Passage à la destination suivante dans la liste
        }
        
        // Vérifie si la dernière destination est atteinte
        if (indiceDestination >= destinations.Count) {
            if (boucle) {
                indiceDestination = 0; // Redémarre depuis la première destination
            }
            else {
                enabled = false; // Désactive le script pour arrêter le mouvement
                return;
            }
        }
        arrive = false; // Réinitialise l'état d'arrivée
    }
}
