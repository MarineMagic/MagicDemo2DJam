using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSiObjet : MonoBehaviour
{
	public string objetCheck;
	public int quantitee;
	public GameObject ObjetActiDesactivable;

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.transform.tag == "Player") {
			if (Inventaire.CompterInventaire(objetCheck) >= 1) {
				//inverse l'état de l'objet si on a le bon truc dans son inventaire
				ObjetActiDesactivable.SetActive(!ObjetActiDesactivable.activeInHierarchy);
				Inventaire.RetirerdInventaire(objetCheck, quantitee);
			}
		}
	}
}
