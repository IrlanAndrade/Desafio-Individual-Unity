using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class minotaurMovement : MonoBehaviour
{
    [SerializeField]private float attackDistance, moveSpeed, dashSpeed, dashCooldown, dashDuration, duration, chanceDash;
    [SerializeField]private bool canAttack, canDash, isDash = false;
    private minotaurStats ms;

    public bool _canAttack{
        get {return canAttack;}
        set {canAttack = value;}
    }
    public bool _canDash{
        get {return canDash;}
        set {canDash = value;}
    }
    public float _moveSpeed{
        get {return moveSpeed;}
        set {moveSpeed = value;}
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        ms = GetComponent<minotaurStats>();

        if (ms._lifePoints != 0){

            float direction = getPlayerDirection();
            float distance = getPlayerDistance();
            _canAttack = distance <= attackDistance;

            if (_canAttack)
            {
                move(direction);
                dash(direction);  // Chama a função de dash
            }

        }
        
    }

    public void dash(float direction)
    {
        if (!isDash)  // Chama a corrotina apenas se ela não estiver em execução
        {
            StartCoroutine(randomChanceToDash(dashCooldown));
        }

        if (canDash)
        {
            duration += Time.deltaTime;
            canDash = (duration >= dashDuration) ? false : true;

            float directionModifier = (direction > 0) ? 1 : -1;
            transform.Translate(Vector2.right * directionModifier * dashSpeed * Time.deltaTime);
        }
        else
        {
            duration = 0;
        }
    }

    IEnumerator randomChanceToDash(float dashCooldown)
    {
        isDash = true;  // Marca a corrotina como em execução
        yield return new WaitForSeconds(dashCooldown);

        int randomInt = Random.Range(0, 9);
        Debug.Log(randomInt);
        canDash = (randomInt < chanceDash) ? true : false;  // Atualiza a condição de "poder dar dash"

        isDash = false;  // Marca a corrotina como finalizada
    }


    public void move(float direction){
        float directionModifier = (direction > 0) ? 1 : -1;
        transform.Translate(Vector2.right * directionModifier * moveSpeed * Time.deltaTime);

    }
    public float getPlayerDirection(){
        GameObject player = GameObject.Find("player");
        Vector2 playerDirection = (player.transform.position - transform.position).normalized;

        return playerDirection.x;
    }

    public float getPlayerDistance
    (){
        GameObject player = GameObject.Find("player");
        float distance = Vector2.Distance(player.transform.position, transform.position);

        return distance;
    }

    
}
