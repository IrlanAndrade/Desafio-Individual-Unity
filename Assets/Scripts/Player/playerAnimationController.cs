using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sr;
    private Vector2 movement;
    [SerializeField]private ParticleSystem dustFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        sr       = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("isDead") == false){
            movement.x = Input.GetAxisRaw("Horizontal");
            movement   = movement.normalized;

            SpriteControl();
        }
    }

    void SpriteControl()
    {
        if (movement.x != 0){
            animator.SetBool("isWalking", true);
        }else{
            animator.SetBool("isWalking", false);
        }

        if (movement.x > 0){
            sr.flipX = false;
        }else if (movement.x < 0){
            sr.flipX = true;
        } 
    }
    

}
