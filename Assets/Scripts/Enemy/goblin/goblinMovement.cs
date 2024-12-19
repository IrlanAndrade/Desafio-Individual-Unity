using UnityEngine;

public class goblinMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidade do NPC
    public float moveDistance = 3f; // Distância que o NPC percorre para cada lado

    private Vector3 startPos; // Posição inicial do NPC
    private bool movingRight = true; // Direção inicial do NPC
    private bool lastFlipX;
    private Animator animator;
    private SpriteRenderer sr;
    public bool _lastFlipX{
        get {return lastFlipX;}
        set {lastFlipX = value;}
    }

    void Start()
    {
        startPos = transform.position; // Armazena a posição inicial do NPC
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!GetComponent<death>()._isDying){
            if (stopMovement() == false){
                doMovement();
            }
        }
        
    }
    private bool stopMovement()
    {
        goblinAttack ga = GetComponent<goblinAttack>();
        if (ga._canAttack == true){
            animator.enabled = false;
            
            return true;
        }else{
            animator.enabled = true;
            return false;
        }

    }

    private void doMovement()
    {
        // Calcula o movimento do NPC
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            animator.SetBool("isWalking", true);
            if (transform.position.x >= startPos.x + moveDistance)
            {
                sr.flipX = true;
                lastFlipX = true;
                movingRight = false; // Muda a direção
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            animator.SetBool("isWalking", true);
            if (transform.position.x <= startPos.x - moveDistance)
            {
                sr.flipX = false;
                lastFlipX = false;
                movingRight = true; // Muda a direção
            }
        }
    }
}
