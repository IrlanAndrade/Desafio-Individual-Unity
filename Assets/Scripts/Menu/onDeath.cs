using UnityEngine;

public class onDeath : MonoBehaviour
{
    public GameObject levelLoader;
    public GameObject playerStats;
    private levelLoader ll;
    private playerStats ps;

    // Start é chamado antes da primeira execução de Update
    void Start()
    {
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        ll = levelLoader.GetComponent<levelLoader>(); 
        ps = playerStats.GetComponent<playerStats>(); 
        
        if (ps != null)
        {
            if (ps.getLife() == 0)
            {
                ll.LoadMenu();
            }
        }
    }
}
