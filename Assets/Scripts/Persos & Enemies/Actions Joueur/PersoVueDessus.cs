using UnityEngine;

public class PersoVueDessus : MonoBehaviour
{
    [Header("Paramètres de déplacement")]
    public float vitesseNormale = 5f;
    public float vitesseSprint = 8f;

    private Rigidbody2D rb; //gestion de la physique du perso, gravité etc
    private Vector2 deplacement;
    public Animator animator; //gestion des animations
    private float flip;

    void Start() {
        //recuperer les components necessaires
        rb = GetComponent<Rigidbody2D>();
        //reset la gravité en début de jeu
        rb.gravityScale = 0;
    }

    void Update() {
        // Récupérer les entrées du clavier
        deplacement.x = Input.GetAxisRaw("Horizontal");
        deplacement.y = Input.GetAxisRaw("Vertical");

        // Normaliser le vecteur, un petit calcul de math automatique pour un déplacement constant
        deplacement = deplacement.normalized;

        // Mettre à jour le paramètre "vitesse" de l'Animator
        animator.SetFloat("vitesse", rb.velocity.magnitude);
        //Joue animation droite/gauche selon direction
        if (rb.velocity.x < 0) {
            flip = 0f;
        }
        else if (rb.velocity.x > 0) {
            flip = 180f;
        }
        animator.transform.rotation = Quaternion.Euler(new Vector3(0f, flip, 0f));
    }

    void FixedUpdate() {
        // Déterminer la vitesse (sprint ou normale)
        float vitesseActuelle = Input.GetButton("Fire3") ? vitesseSprint : vitesseNormale;

        // Appliquer le déplacement au Rigidbody2D
        rb.velocity = deplacement * vitesseActuelle;
    }
}