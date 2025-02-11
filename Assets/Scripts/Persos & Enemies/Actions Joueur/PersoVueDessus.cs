using UnityEngine;

public class PersoVueDessus : MonoBehaviour
{
    [Header("Paramètres de déplacement")]
    public float vitesseNormale = 5f; // Vitesse de déplacement normale
    public float vitesseSprint = 8f;  // Vitesse de déplacement lorsque le joueur court

    private Rigidbody2D rb; // Gère la physique du personnage (gravité, mouvement, etc.)
    private Vector2 deplacement; // Contient les valeurs de mouvement horizontal et vertical
    public Animator animator; // Gère les animations du personnage
    private float flip; // Permet de retourner le personnage selon sa direction

    void Start() {
        // Récupère les composants nécessaires au début du jeu
        rb = GetComponent<Rigidbody2D>();
        // Réinitialise la gravité du personnage pour qu'il ne tombe pas
        rb.gravityScale = 0;
    }

    void Update() {
        // Récupère les entrées du clavier pour le mouvement horizontal et vertical
        deplacement.x = Input.GetAxisRaw("Horizontal"); // Mouvement gauche/droite
        deplacement.y = Input.GetAxisRaw("Vertical"); // Mouvement haut/bas

        // Normalise le vecteur de déplacement pour que le personnage se déplace à la même vitesse dans toutes les directions
        deplacement = deplacement.normalized;

        // Met à jour le paramètre "vitesse" de l'Animator pour jouer les animations appropriées
        animator.SetFloat("vitesse", rb.velocity.magnitude);

        // Joue l'animation pour tourner le personnage à droite ou à gauche en fonction de sa direction
        if (rb.velocity.x < 0) {
            flip = 0f; // Personnage tourné à gauche
        }
        else if (rb.velocity.x > 0) {
            flip = 180f; // Personnage tourné à droite
        }
        animator.transform.rotation = Quaternion.Euler(new Vector3(0f, flip, 0f)); // Applique la rotation
    }

    void FixedUpdate() {
        // Détermine si le joueur sprint ou non, en fonction de l'entrée du bouton "Fire3" (par exemple shift)
        float vitesseActuelle = Input.GetButton("Fire3") ? vitesseSprint : vitesseNormale;

        // Applique le déplacement au Rigidbody2D avec la vitesse actuelle
        rb.velocity = deplacement * vitesseActuelle;
    }
}
