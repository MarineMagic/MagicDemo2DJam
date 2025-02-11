using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestruction : MonoBehaviour
{
    // Cette fonction est appelée lorsqu'une collision se produit
    void OnCollisionEnter2D(Collision2D collision) {
        // Détruit cet objet 0.1 seconde après la collision
        Destroy(this.gameObject, 0.1f);
    }
}