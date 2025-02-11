using UnityEngine;

public class CollerAObjet : MonoBehaviour
{
    public Transform joueur; //le truc � suivre

    private Vector3 offset; //la difference initial de position entre l'objet et le truc � suivre (offset)

    void Start() {
        // Calculer l'offset entre l'objet et le le truc � suivre
        offset = transform.position - joueur.position;
    }

    void LateUpdate() {
        // Mettre � jour la position de l'objet
        transform.position = joueur.position + offset;
    }
}
