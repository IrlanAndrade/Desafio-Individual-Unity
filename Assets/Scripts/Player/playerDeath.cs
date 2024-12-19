using UnityEngine;

public class playerDeath : MonoBehaviour
{
    [SerializeField]private GameObject levelLoader;
    [SerializeField]private levelLoader ll;
    [SerializeField]private playerStats ps;
    void Start()
    {
        
    }

    void Update()
    {
        ll = levelLoader.GetComponent<levelLoader>(); 
        ps = gameObject.GetComponent<playerStats>(); 
        
        if (ps != null && ps.getLife() == 0)
        {
            ll.LoadMenu();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death Object")){
            ll.LoadMenu();
        }
    }
}
