using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour changer de scène

public class GameManager : MonoBehaviour
{
    private GameObject joueur;
    public GameObject pauseMenu;

    void Start()
    {
        // menu pause off en début de jeu
        pauseMenu.SetActive(false);
        joueur = GameObject.FindGameObjectWithTag("Player");
        if (joueur == null) {
            Debug.LogWarning("Pas de joueur dans ce niveau");
            return; //empèche les bugs si pas de joueur dans le niveau (menu etc)
        }
    }

    void Update()
    {
        if (joueur != null) {
            if (joueur.GetComponent<VIE>().SanteeEnCours <= 0) {
                SceneManager.LoadScene("GameOver");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu != null) {
            // Appelle la fonction pour mettre en pause ou reprendre le jeu
            PauserJeu();
        }
    }

    // Fonction pour retourner au menu principal
    public void RetourMenu() {
        // Charge la scène du menu principal (assure-toi d'avoir une scène nommée "Menu" dans ton build settings)
        SceneManager.LoadScene("Menu");
    }

    // Fonction pour lancer le jeu
    public void LancerJeu() {
        // Charge la scène du jeu (assure-toi d'avoir une scène nommée "Niveau1" dans ton build settings)
        SceneManager.LoadScene("Niveau1");
    }

    // Fonction pour quitter le jeu
    public void QuitterJeu() {
        // Quitte l'application (ne fonctionne que dans un build, pas dans l'éditeur)
        Application.Quit();
        // Si tu es dans l'éditeur, tu peux utiliser cette ligne pour simuler la sortie
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // Fonction pour mettre le jeu en pause
    public void PauserJeu() {
        // Met le jeu en pause en mettant le timeScale à 0
        Time.timeScale = 0f;

        // Tu peux aussi activer un menu de pause ici si tu en as un
        pauseMenu.SetActive(true);
    }

    // Fonction pour reprendre le jeu après une pause
    public void RetourJeu() {
        // Reprend le jeu en remettant le timeScale à 1
        Time.timeScale = 1f;

        // Tu peux aussi désactiver le menu de pause ici si tu en as un
        pauseMenu.SetActive(false);
    }
}
