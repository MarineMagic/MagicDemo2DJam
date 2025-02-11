using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrouille : MonoBehaviour
{
    // Variables publiques
    public float vitesse = 1f; // vitesse de d�placement
    public List<GameObject> destinations; // les destinations � suivre
    public bool boucle = true; // si true, le chemin est boucl�, sinon l�objet s�arr�te une fois arriv� au bout du chemin
    public bool hasard = false; //si true, les points sont choisis au hasard, sinon c'est dans l'ordre de la liste
    public float attente = 0; //temps d'attente a chaque point

    // Variables priv�es
    private int indiceDestination = 0; // indice de la destination courante dans la liste
    private float tolerance = 0.1f; // la distance acceptable pour consid�rer que l�objet a atteint une destination
    private bool arrive;

    void Update() {
        // d�placer l�objet vers la destination suivante
        transform.position = Vector2.MoveTowards(transform.position, destinations[indiceDestination].transform.position, vitesse * Time.deltaTime);
        // si l�objet atteint la destination (il est donc plus pr�s que la tol�rance)
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
            indiceDestination++; // passer � la destination suivante dans la liste
        }
        if (indiceDestination >= destinations.Count) // si la derni�re destination est atteinte
        {
            if (boucle) {
                indiceDestination = 0; // boucler sur la premi�re destination
            }
            else {
                enabled = false; // d�sactiver le script
                return;
            }
        }
        arrive = false;
    }
}