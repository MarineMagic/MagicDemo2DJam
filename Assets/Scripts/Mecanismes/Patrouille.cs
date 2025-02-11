using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrouille : MonoBehaviour
{
    // Variables publiques
    public float vitesse = 1f; // vitesse de déplacement
    public List<GameObject> destinations; // les destinations à suivre
    public bool boucle = true; // si true, le chemin est bouclé, sinon l’objet s’arrête une fois arrivé au bout du chemin
    public bool hasard = false; //si true, les points sont choisis au hasard, sinon c'est dans l'ordre de la liste
    public float attente = 0; //temps d'attente a chaque point

    // Variables privées
    private int indiceDestination = 0; // indice de la destination courante dans la liste
    private float tolerance = 0.1f; // la distance acceptable pour considérer que l’objet a atteint une destination
    private bool arrive;

    void Update() {
        // déplacer l’objet vers la destination suivante
        transform.position = Vector2.MoveTowards(transform.position, destinations[indiceDestination].transform.position, vitesse * Time.deltaTime);
        // si l’objet atteint la destination (il est donc plus près que la tolérance)
        if (Vector2.Distance(transform.position, destinations[indiceDestination].transform.position) < tolerance && !arrive) {
            arrive = true;
            Timers.StartTimer(attente, NouveauPoint);
        }
    }

    private void NouveauPoint() {
        if (hasard) {
            indiceDestination = Random.Range(0, destinations.Count); //on choisi une destination au pif dans la liste
        }
        else {
            indiceDestination++; // passer à la destination suivante dans la liste
        }
        if (indiceDestination >= destinations.Count) // si la dernière destination est atteinte
        {
            if (boucle) {
                indiceDestination = 0; // boucler sur la première destination
            }
            else {
                enabled = false; // désactiver le script
                return;
            }
        }
        arrive = false;
    }
}