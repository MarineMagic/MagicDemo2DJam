using UnityEngine;

public class CollerAObjet : MonoBehaviour
{
    public Transform joueur; // L'objet à suivre

    private Vector3 offset; // Différence initiale de position entre cet objet et le joueur

    void Start() {
        // Calculer l'offset entre cet objet et le joueur
        offset = transform.position - joueur.position;
    }

    void LateUpdate() {
        // Mettre à jour la position de cet objet pour qu'il suive le joueur avec l'offset
        transform.position = joueur.position + offset;
    }
}
