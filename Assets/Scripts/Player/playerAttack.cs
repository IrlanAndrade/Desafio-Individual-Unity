using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 2f, refreshcd = 3.0f, actualcd;
    [SerializeField]private GameObject trap;
    [SerializeField]private GameObject HUD;

    void Start()
    {
        HUD.GetComponentInChildren<habilitiesHUD>().triggerTrap(refreshcd);
        // actualcd = refreshcd;
    }
    void Update()
    {
        actualcd += Time.deltaTime;
        if (actualcd >= refreshcd){
            attack();
        }
    }

    private void attack(){
        if (Input.GetMouseButtonDown(1))
        {
            GameObject newTrap = Instantiate(trap, transform.position, Quaternion.identity);
            actualcd = 0.0f;
            HUD.GetComponentInChildren<habilitiesHUD>().triggerTrap(refreshcd);
        }
    }
}