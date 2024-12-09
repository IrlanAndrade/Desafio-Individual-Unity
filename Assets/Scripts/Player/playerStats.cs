using UnityEngine;

public class playerStats : MonoBehaviour
{
    
    [SerializeField]private int life = 3;
    private float invenciblityTimeFlat = 1;
    [SerializeField]private float invencibilityTime;
    [SerializeField]private bool canBeHurted = true;
    private SimpleFlash simpleFlash;
    private Animator animator;

    void Start()
    {
        simpleFlash = GetComponent<SimpleFlash>();
        invencibilityTime = invenciblityTimeFlat;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Diminui a contagem do tempo de ivencibilidade
        if (canBeHurted == false){
            invencibilityTime -= Time.deltaTime;
        }

        // Quando acabar o tempo de invencibilidade, permite o jogador tomar dano novamente
        if (invencibilityTime <= 0){
            canBeHurted = true;
            invencibilityTime = invenciblityTimeFlat;
        }

        if (life == 0){
            animator.SetBool("isDead", true);  // Para a animação de pulo
            animator.Play("Player Death");
        }
    }

    // Sofre o dano ao enconstar em inimigos, inicia o tempo de invencibilidade
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canBeHurted == true && animator.GetBool("isDead") == false){
            if (collision.gameObject.CompareTag("Enemy"))
            {
                life -= 1;
                simpleFlash.Flash();
                canBeHurted = false;
            }
        }
    }

    public int getLife(){
        return life;
    }
}
