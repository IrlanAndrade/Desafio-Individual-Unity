using UnityEngine;

public class checkGround : MonoBehaviour
{
    [SerializeField]private bool collide;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se colidiu com o chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            collide = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        // Saiu do chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            collide = false;
        }
    }

    public bool getCollide(){
        return collide;
    }

}
