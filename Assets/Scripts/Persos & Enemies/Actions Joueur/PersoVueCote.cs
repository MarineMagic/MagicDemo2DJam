using UnityEngine; 

public class PersoVueCote : MonoBehaviour
{
    [Header("Paramètres de déplacement")]
    public float vitesseNormale = 5f; // Vitesse de déplacement normale
    public float vitesseSprint = 8f; // Vitesse lorsque le joueur court
    public float forceSaut = 10f; // Force du saut

    [Header("Contrôle du saut")]
    public LayerMask coucheSol; // Ce qui compte comme un sol dans le jeu
    public Transform pointDeVerificationSol; // Position des pieds du personnage
    public float rayonVerification = 0.2f; // Taille de l'espace pour vérifier si on touche le sol

    private Rigidbody2D rb; // Gère la physique du personnage (gravité, mouvements)
    private bool estAuSol; // Vérifie si le personnage touche le sol
    public Animator animator; // Gère les animations du personnage
    private float flip; // Permet de retourner le personnage en fonction de la direction

    void Start() {
        // Récupère les composants nécessaires au début du jeu
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update() {
        // Vérifie si le personnage est au sol en utilisant un rayon autour des pieds
        estAuSol = Physics2D.OverlapCircle(pointDeVerificationSol.position, rayonVerification, coucheSol);
        animator.SetBool("AuSol", estAuSol); // Met à jour l'animation pour savoir si on est au sol

        // Récupère le mouvement horizontal du joueur (flèches ou touches A/D)
        float mouvementHorizontal = Input.GetAxis("Horizontal");

        // Si le joueur appuie sur la touche de sprint, on utilise la vitesse de sprint
        float vitesseActuelle = Input.GetButton("Fire3") ? vitesseSprint : vitesseNormale;

        // Met à jour la vitesse du personnage en fonction du mouvement horizontal et de la gravité
        rb.velocity = new Vector2(mouvementHorizontal * vitesseActuelle, rb.velocity.y);

        // Met à jour le paramètre "vitesse" de l'Animator en fonction de la vitesse horizontale
        animator.SetFloat("vitesse", Mathf.Abs(rb.velocity.x));

        // Retourne le personnage selon la direction de son mouvement
        if (rb.velocity.x < 0) {
            flip = 0f; // Personnage tourné à gauche
        }
        else if (rb.velocity.x > 0) {
            flip = 180f; // Personnage tourné à droite
        }
        animator.transform.rotation = Quaternion.Euler(new Vector3(0f, flip, 0f)); // Applique la rotation

        // Si le joueur appuie sur "Saut" et que le personnage est au sol, il saute
        if (Input.GetButtonDown("Jump") && estAuSol) {
            rb.velocity = new Vector2(rb.velocity.x, forceSaut); // Applique la force du saut
            animator.SetTrigger("Saut"); // Joue l'animation du saut
        }
    }

    void OnDrawGizmosSelected() {
        // Dessine un cercle dans l'éditeur pour visualiser où on vérifie si le personnage est au sol
        if (pointDeVerificationSol != null) {
            Gizmos.color = Color.red; // Change la couleur du cercle
            Gizmos.DrawWireSphere(pointDeVerificationSol.position, rayonVerification); // Dessine le cercle
        }
    }
}
