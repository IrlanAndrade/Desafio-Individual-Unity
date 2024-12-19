using UnityEngine;

public class bossDeath : MonoBehaviour
{
    private minotaurStats ms;
    private minotaurAnimation ma;
    
    [SerializeField]private float deathTime;
    void Start()
    {       
    }

    void Update()
    {
        ms = GetComponent<minotaurStats>();
        ma = GetComponent<minotaurAnimation>();

        if (ms._lifePoints == 0){
            deathTime -= Time.deltaTime;
            ma.death();
            if (deathTime <= 0){
                Destroy(gameObject);
            }
        }
    }
}