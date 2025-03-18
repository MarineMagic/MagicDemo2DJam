using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour changer de scène

public class ChangeScene : MonoBehaviour
{
    public string NiveauSuivant; // Nom de la scène à charger
    public bool parScore; // Si vrai, le changement de scène est déclenché par un score
    public int combien; // Quantité requise pour déclencher le changement de scène
    public string quoi; // Nom de l'objet ou de la ressource à compter dans l'inventaire

    public bool parCollision; // Si vrai, le changement de scène est déclenché par une collision

    void Update()
    {
        // Vérifie si le changement de scène est déclenché par un score
        if (parScore && Inventaire.CompterInventaire(quoi) >= combien) {
            ChargerNiveauSuivant();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Vérifie si le changement de scène est déclenché par une collision avec un objet ayant le tag "Player"
        if (parCollision && collision.transform.tag == "Player") {
            ChargerNiveauSuivant();
        }
    }

    private void ChargerNiveauSuivant() {
        SceneManager.LoadScene(NiveauSuivant); // Charge la scène suivante
    }
}