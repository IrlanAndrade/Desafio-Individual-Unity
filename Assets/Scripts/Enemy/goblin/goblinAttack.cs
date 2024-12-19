using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class goblinAttack : MonoBehaviour
{
    [SerializeField]private float attackDistance = 3;
    [SerializeField]private bool canAttack = false;
    [SerializeField]private Sprite attackSprite;
    [SerializeField]private GameObject rock;
    [SerializeField]private float cdToAttack;
    [SerializeField]private float cdAttack = 0;
    private SpriteRenderer sr;
    private Sprite originalSprite;
    public bool _canAttack{
        get {return canAttack;}
        set {canAttack = value;}
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        originalSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<death>()._isDying){
            float distance = getPlayerDistance();
            _canAttack = distance <= attackDistance;
            switchSprite();
            animateArm();

            if (_canAttack == true){
                GameObject player = GameObject.Find("player");
                Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                GetComponent<SpriteRenderer>().flipX = playerDirection.x < 0;
            }else{
                sr.flipX = GetComponent<goblinMovement>()._lastFlipX;
            }
        }
    }

    private void switchSprite(){
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = _canAttack ? attackSprite : originalSprite;
    }
    private void animateArm()
    {
        Transform child = transform.Find("arm");
        if (child != null)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = _canAttack; // Ativa ou desativa o SpriteRenderer
                spriteRenderer.flipX = GetComponent<SpriteRenderer>().flipX;
                attacking(child.transform);
            }
        }
    }
    private float getPlayerDistance
    (){
        GameObject player = GameObject.Find("player");
        float distance = Vector2.Distance(player.transform.position, transform.position);

        return distance;
    }
    private void attacking(Transform arm)
    {
        if(_canAttack)
        {
            cdAttack += Time.deltaTime;
            GameObject player = GameObject.Find("player");
            Vector2 direction = (player.transform.position - arm.position).normalized;
            float angle       = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arm.rotation      = Quaternion.Euler(0, 0, angle - 270);


            if (cdAttack >= cdToAttack ){
                GameObject instantiatedRock = Instantiate(rock, arm.transform.position, arm.rotation);
                instantiatedRock.GetComponent<goblinWeapon>().Initialize(direction);
                cdAttack = 0;
            }
        }else
        {
            cdAttack = 0;
        }
    }

}
