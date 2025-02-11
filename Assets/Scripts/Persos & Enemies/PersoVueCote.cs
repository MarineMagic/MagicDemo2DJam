using UnityEngine;

public class PersoVueCote : MonoBehaviour
{
    [Header("Paramètres de déplacement")]
    public float vitesseNormale = 5f;
    public float vitesseSprint = 8f;
    public float forceSaut = 10f;

    [Header("Contrôle du saut")]
    public LayerMask coucheSol; // Ce qui compte comme un sol dans le jeu
    public Transform pointDeVerificationSol; // Nos pieds
    public float rayonVerification = 0.2f; // La taille de nos pieds XD

    private Rigidbody2D rb; // Gestion de la physique du perso, gravité etc
    private bool estAuSol;
    public Animator animator; // Gestion des animations
    private float flip;

    void Start() {
        // Récupérer les components nécessaires
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // Vérifie si le personnage est au sol
        estAuSol = Physics2D.OverlapCircle(pointDeVerificationSol.position, rayonVerification, coucheSol);
        animator.SetBool("AuSol", estAuSol);

        // Déplacement horizontal
        float mouvementHorizontal = Input.GetAxis("Horizontal");
        // Sprint
        float vitesseActuelle = Input.GetButton("Fire3") ? vitesseSprint : vitesseNormale;
        // MAJ de la vitesse
        rb.velocity = new Vector2(mouvementHorizontal * vitesseActuelle, rb.velocity.y);

        // Mettre à jour le paramètre "vitesse" de l'Animator
        animator.SetFloat("vitesse", Mathf.Abs(rb.velocity.x));

        // Joue animation droite/gauche selon direction
        if (rb.velocity.x < 0) {
            flip = 0f;
        }
        else if (rb.velocity.x > 0) {
            flip = 180f;
        }
        animator.transform.rotation = Quaternion.Euler(new Vector3(0f, flip, 0f));

        // Saut
        if (Input.GetButtonDown("Jump") && estAuSol) {
            rb.velocity = new Vector2(rb.velocity.x, forceSaut);
            animator.SetTrigger("Saut");
        }
    }

    void OnDrawGizmosSelected() {
        // Dessine un cercle pour visualiser le point de vérification du sol
        if (pointDeVerificationSol != null) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(pointDeVerificationSol.position, rayonVerification);
        }
    }
}