using UnityEngine;

public class minotaurStats : MonoBehaviour
{
    [SerializeField]private float lifePoints;
    private SimpleFlash simpleFlash;

    public float _lifePoints{
        get {return lifePoints;}
        set {lifePoints = value;}
    }

    void Start()
    {
        _lifePoints = lifePoints; // Sim, redundância, outros scripts não acessavam o valor setado manualmente na unity quando vc mesmo coloca
        simpleFlash = GetComponent<SimpleFlash>();
    }
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Trap")){
            _lifePoints -= 0.5f; // uma das maiores gambiarras já vistas no planeta terra
            simpleFlash.Flash();
        }
    }
}