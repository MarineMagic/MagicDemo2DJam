using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamasserObjet : MonoBehaviour
{
	public string objetRamasse;
	public int quantitee;

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.transform.tag == "Player") {
			Inventaire.AjouterAInventaire(objetRamasse, quantitee);
			Destroy(this.gameObject);
		}
	}
}
