using UnityEngine;

public class Orbite : MonoBehaviour
{
    public Transform pivot; // Objet autour duquel ce GameObject va tourner
    public float orbitSpeed = 10f; // Vitesse de rotation autour du pivot

    private void Update() {
        // Vérifie que le pivot est bien défini avant d'essayer de tourner autour
        if (pivot != null) {
            // Fait tourner cet objet autour du pivot
            // pivot.position : centre de rotation
            // Vector3.up : axe de rotation (Y, vers le haut)
            // orbitSpeed * Time.deltaTime : vitesse de rotation ajustée au temps réel
            transform.RotateAround(pivot.position, Vector3.up, orbitSpeed * Time.deltaTime);
        }
    }
}
