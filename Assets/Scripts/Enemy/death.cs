using UnityEngine;
using System.Collections;

public class death : MonoBehaviour
{
    private Animator animator;
    public float animationTime = 3;
    private bool startanimation = false;
    private SimpleFlash simpleFlash;
    private bool isDying = false;
    public bool _isDying{
        get {return isDying;}
        set {isDying = value;}
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        simpleFlash = GetComponent<SimpleFlash>();
    }

    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();

        if (startanimation == true){
            animationTime -= Time.deltaTime;
            if (animationTime <= 0){
                Destroy(gameObject);
            }
        }

        if(_isDying == true){
            GetComponent<Rigidbody2D>().simulated = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            isDying = true;
            animator.enabled = true;
            animator.SetBool("isDead", true);
            simpleFlash.Flash();
            startanimation = true;
        }
    }
}
