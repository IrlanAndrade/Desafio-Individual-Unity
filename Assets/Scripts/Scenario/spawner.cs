using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;
    public float timeToSpawn = 3;
    private float time, timeRandom;
    private bool chooseRandom = true;
    [SerializeField]private int waves;
    [SerializeField]private int totalWaves;
    [SerializeField]private int triggerDistance;
    private bool canActivateSpawn = false;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waves = 0;
        time = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        
        if (chooseRandom == true){
            timeRandom = setRandom();
            chooseRandom = false;
        }

        turnonSpawn();

        if (time <= timeRandom && waves < totalWaves && canActivateSpawn == true){
            spawnSlime();
            waves += 1;
        }

        turnoffAnimation();
    }

    public void spawnSlime(){
        Instantiate(enemy, transform.position, Quaternion.identity);
        time = timeToSpawn;
        chooseRandom = true;
    }

    public float setRandom(){
        int timeRandom = Random.Range(1, -4);

        return timeRandom;
    }

    private void turnoffAnimation(){
        if (waves == totalWaves){
            animator = GetComponent<Animator>();
            animator.SetTrigger("StopWave");
        }
    }

    private bool turnonSpawn(){
        GameObject player = GameObject.Find("player");
        float horizontalDistance = Mathf.Abs(player.transform.position.x - transform.position.x);


        if (horizontalDistance <= triggerDistance && waves < totalWaves){
            animator = GetComponent<Animator>();
            animator.SetTrigger("StartWave");
            canActivateSpawn = true;
            return true;
        }else{
            return false;
        }
    }
}
