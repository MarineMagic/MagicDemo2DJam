using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform arriver;
    public string quiPeut;

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.transform.tag == quiPeut) {

			collision.transform.position = arriver.position;

		}
	}

}
