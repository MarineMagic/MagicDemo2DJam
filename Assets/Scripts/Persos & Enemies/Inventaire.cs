using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire: MonoBehaviour
{
    public static List<string> _inventaire = new List<string>();
    public List<string> vue_inventaire;

	private void Update() {
        vue_inventaire = _inventaire;
	}

	public static void AjouterAInventaire(string objet, int nombre) {
        for (int i = 0; i < nombre; i++) {
            _inventaire.Add(objet);
        }
    }
    public static void RetirerdInventaire(string objet, int nombre) {
        for (int i = 0; i < nombre; i++) {
            _inventaire.Remove(objet);
        }
    }
    public static int CompterInventaire(string objet) {
        int count = 0;
        foreach (string item in _inventaire) {
            if (item == objet) {
                count++;
            }
        }
        return count;
    }
}
