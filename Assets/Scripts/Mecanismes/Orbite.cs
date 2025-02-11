using UnityEngine;

public class Orbite : MonoBehaviour

{
    public Transform pivot; // Le point pivot autour duquel on veut orbiter
    public float orbitSpeed = 10f; // La vitesse de l�orbite

    private void Update() {
        // Fait tourner le GameObject autour du point pivot en utilisant l�axe vertical (Y) comme axe de rotation
        // Le deuxi�me argument, Vector3.up, correspond � l�axe de rotation
        // Le troisi�me argument, orbitSpeed * Time.deltaTime, correspond � la vitesse de rotation
        transform.RotateAround(pivot.position, Vector3.forward, orbitSpeed * Time.deltaTime);

    }

}