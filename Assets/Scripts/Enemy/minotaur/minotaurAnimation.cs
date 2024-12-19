using UnityEngine;

public class minotaurAnimation : MonoBehaviour
{
    private minotaurMovement mm;
    private SpriteRenderer sr;
    private Animator animator;
    private minotaurStats ms;
    //private float baseMS;
    void Start()
    {
    }
    void Update()
    {
        ms = GetComponent<minotaurStats>();

        if (ms._lifePoints != 0){

            mm = GetComponent<minotaurMovement>();
            sr = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();

            flip();
            moving();

        }
    }

    private void flip(){
        sr.flipX = (mm.getPlayerDirection() > 0) ? true : false;
    }

    private void moving(){;
        if(!mm._canDash){
            animator.SetTrigger("isWalking");
            animator.ResetTrigger("isDashing");
        }else{
            animator.SetTrigger("isDashing");
            animator.ResetTrigger("isWalking");
        }
    }

    public void death(){
        animator.Play("minotaur death");
        animator.ResetTrigger("isWalking");
        animator.ResetTrigger("isDashing");
    }
}