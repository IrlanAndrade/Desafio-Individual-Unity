using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject levelLoader; 
    private levelLoader ll;
    public Animator textMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ll = levelLoader.GetComponent<levelLoader>(); 

        if (Input.GetKeyDown(KeyCode.R)){
            textMenu.SetTrigger("Start");
            ll.LoadMenu();
        }
    }
}
