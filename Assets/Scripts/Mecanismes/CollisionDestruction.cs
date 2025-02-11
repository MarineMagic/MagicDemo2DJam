using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestruction : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        Destroy(this.gameObject, 0.1f);
    }
 }
