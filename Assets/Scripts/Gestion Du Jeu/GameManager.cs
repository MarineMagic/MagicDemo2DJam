using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour changer de scène

public class GameManager : MonoBehaviour
{
    private GameObject joueur; // Variable pour stocker le joueur
    public GameObject pauseMenu; // Référence au menu de pause (à assigner dans l'éditeur Unity)

    void Start()
    {
        // Désactive le menu de pause au début du jeu
        pauseMenu.SetActive(false);

        // Trouve le joueur dans la scène grâce à son tag "Player"
        joueur = GameObject.FindGameObjectWithTag("Player");

        // Si aucun joueur n'est trouvé, affiche un avertissement et arrête la fonction
        if (joueur == null) {
            Debug.LogWarning("Pas de joueur dans ce niveau");
            return; // Empêche les bugs si aucun joueur n'est présent (par exemple dans un menu)
        }
    }

    void Update()
    {
        // Vérifie si le joueur existe
        if (joueur != null) {
            // Si la santé du joueur est à 0 ou moins, charge la scène "GameOver"
            if (joueur.GetComponent<VIE>().SanteeEnCours <= 0) {
                SceneManager.LoadScene("GameOver");
            }
        }

        // Si la touche Échap est pressée et que le menu de pause existe, met le jeu en pause
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu != null) {
            PauserJeu();
        }
    }

    // Fonction pour retourner au menu principal
    public void RetourMenu() {
        // Charge la scène du menu principal (assure-toi d'avoir une scène nommée "Menu" dans les Build Settings)
        SceneManager.LoadScene("Menu");
    }

    // Fonction pour lancer le jeu
    public void LancerJeu() {
        // Charge la scène du jeu (assure-toi d'avoir une scène nommée "Niveau1" dans les Build Settings)
        SceneManager.LoadScene("Niveau1");
    }

    // Fonction pour quitter le jeu
    public void QuitterJeu() {
        // Quitte l'application (cela ne fonctionne que dans un build, pas dans l'éditeur Unity)
        Application.Quit();

        // Si tu es dans l'éditeur Unity, cette ligne permet de simuler la sortie
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // Fonction pour mettre le jeu en pause
    public void PauserJeu() {
        // Met le jeu en pause en mettant le timeScale à 0 (le temps s'arrête)
        Time.timeScale = 0f;

        // Active le menu de pause
        pauseMenu.SetActive(true);
    }

    // Fonction pour reprendre le jeu après une pause
    public void RetourJeu() {
        // Reprend le jeu en remettant le timeScale à 1 (le temps reprend normalement)
        Time.timeScale = 1f;

        // Désactive le menu de pause
        pauseMenu.SetActive(false);
    }
}