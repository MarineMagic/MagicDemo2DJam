using UnityEngine;

public class CollerAObjet : MonoBehaviour
{
    public Transform joueur; //le truc à suivre

    private Vector3 offset; //la difference initial de position entre l'objet et le truc à suivre (offset)

    void Start() {
        // Calculer l'offset entre l'objet et le le truc à suivre
        offset = transform.position - joueur.position;
    }

    void LateUpdate() {
        // Mettre à jour la position de l'objet
        transform.position = joueur.position + offset;
    }
}
