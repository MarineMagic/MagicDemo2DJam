using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruction : MonoBehaviour
{
    public float delaiDeDestruction;
    void Start()
    {
        Destroy(this.gameObject, delaiDeDestruction);
    }

}
