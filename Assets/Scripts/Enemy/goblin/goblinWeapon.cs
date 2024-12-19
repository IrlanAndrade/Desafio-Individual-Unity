using System.Collections;
using UnityEngine;

public class goblinWeapon : MonoBehaviour
{
    [SerializeField]private float speed = 10f; // Velocidade do projétil
    [SerializeField]private Vector2 direction; // Direção do projétil
    [SerializeField]private float rotationSpeed = 120f;
    private float timetoDestroy = 3f;
    [SerializeField]private float time;
    private float initialRotation;  // Rotação inicial aleatória



    public void Initialize(Vector2 shootDirection)
    {
        direction = shootDirection.normalized; // Normaliza a direção para manter uma magnitude constante
        initialRotation = Random.Range(0f, 360f); // Rotação inicial aleatória
        transform.rotation = Quaternion.Euler(0f, 0f, initialRotation); // Define a rotação inicial
    }

    void Update()
    {
        time += Time.deltaTime;

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        if (time >= timetoDestroy){Destroy(gameObject);}
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.CompareTag("Enemy")){StartCoroutine(DestroyAfterDelay());}
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.01f); // Espera até o final do frame atual
        Destroy(gameObject);
    }
}
