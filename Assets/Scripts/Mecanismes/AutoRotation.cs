using UnityEngine;

public class AutoRotation : MonoBehaviour

{
    public Vector3 vitesse;
    private void Update() {
        transform.Rotate(vitesse * Time.deltaTime);
    }

}