using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public float moveSpeed = 2f, refreshcd = 3.0f;
    public GameObject trap;

    void Start()
    {
    }
    void Update()
    {
        refreshcd -= Time.deltaTime;
        if (refreshcd <= 0.0f){
            attack();
        }
    }

    private void attack(){
        if (Input.GetMouseButtonDown(1))
        {
            GameObject newTrap = Instantiate(trap, transform.position, Quaternion.identity);
            refreshcd = 3.0f;
        }
    }
}