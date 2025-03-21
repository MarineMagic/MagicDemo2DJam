using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDegats : MonoBehaviour
{
    public float degatsMin = 10f; // Dégéts minimum infligés
    public float degatsMax = 10f; // Dégéts maximum infligés
    public string tagCible = ""; // Tag des objets qui peuvent recevoir des dégats

    public GameObject drop; // si à 0 pv le perso/ennemi doit lacher quelque chose

    void OnCollisionEnter2D(Collision2D collision) {
        // Vérifie si l'objet touché a le tag spécifié
        if (collision.transform.tag == tagCible) { 
            // Récupére le script VIE de l'objet touché
            VIE vie = collision.transform.GetComponent<VIE>();
            // Si l'objet a un script VIE, on inflige des dégats
            if (vie != null) {
                float degatsInfliges = Random.Range(degatsMin, degatsMax); // Calcule les dégéts infligés
                vie.FaireDegats(degatsInfliges); // Applique les dégéts
                //si l'objet touché é pris assez de degat pour tomber à 0 pv, et n'est pas le joueur (le joueur meurt differement)
                if (vie.SanteeEnCours <= 0 && collision.transform.tag != "Player") {
                    Destroy(collision.gameObject,0.1f); //on le détruit avec un délai de 0.1 seconde
                }
            }
        }
    }
    void OnDestroy()
    {
        if(drop != null){ //si on doit drop un objet à la mort
            GameObject loot =  Instantiate(drop, transform.position, Quaternion.identity); // on le drop
            Physics2D.IgnoreCollision(loot.GetComponent<Collider2D>(), GetComponent<Collider2D>()); //on evite les collisions juste après le drop
        }
    }
}