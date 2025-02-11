using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruction : MonoBehaviour
{
    public float delaiDeDestruction; // Délai avant la destruction de l'objet

    void Start()
    {
        // Détruit l'objet après le délai spécifié
        Destroy(this.gameObject, delaiDeDestruction);
    }
}