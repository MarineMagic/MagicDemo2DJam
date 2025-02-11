using UnityEngine;

public class AutoRotation : MonoBehaviour
{
    public Vector3 vitesse; // Vitesse de rotation sur les axes X, Y et Z

    private void Update() {
        // Fait tourner l'objet en fonction de la vitesse et du temps écoulé
        transform.Rotate(vitesse * Time.deltaTime);
    }
}