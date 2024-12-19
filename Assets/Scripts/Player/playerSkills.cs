using UnityEngine;
using UnityEngine.InputSystem;

public class playerSkills : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashForce;
    private int position = 1;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Dash();
    }

    void Dash(){
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            position = getDirection();

            rb.linearVelocity = new Vector2(dashForce * position, rb.linearVelocity.y);
        }
    }

    private int getDirection(){
        position = sr.GetComponent<SpriteRenderer>().flipX ? 1 : -1;

        return position;
    }
}
