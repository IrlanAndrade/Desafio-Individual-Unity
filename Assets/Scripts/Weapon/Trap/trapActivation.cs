using UnityEngine;
using System.Collections;

public class trapActivation : MonoBehaviour
{
    private Animator animator;
    public float animationTime = 3;
    private bool startanimation = false;
    [SerializeField]private GameObject check;
    private checkCollision cc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startanimation == true){
            animationTime -= Time.deltaTime;
            if (animationTime <= 0){
                Destroy(gameObject);
            }
        }

        cc = GetComponentInChildren<checkCollision>();
        if (cc.getCollide() == true){
            animator.SetBool("isActivated", true);
            startanimation = true;
        }
    }

    private void selfDestroy()
    {
        Destroy(gameObject);
    }
}
