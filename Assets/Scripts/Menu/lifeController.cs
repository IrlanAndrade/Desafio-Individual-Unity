using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class lifeController : MonoBehaviour
{
    private GameObject player;
    private playerStats ps;
    [SerializeField]private int life;
    [SerializeField]private Canvas canvas;
    [SerializeField]private float distance;
    private GameObject life2;
    private GameObject life3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        life2 = createImage(distance);
        life3 = createImage(distance * 2);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ps = player.GetComponent<playerStats>();
        life = ps.getLife();

        if (life == 2){Destroy(life3);}
        if (life == 1){Destroy(life2);}
        if (life == 0){Destroy(this.gameObject);}
    }
     private GameObject createImage(float distance)
    {
        GameObject imageObject = new GameObject("Life Hearth");
        imageObject.transform.SetParent(canvas.transform, false);
        Image image = imageObject.AddComponent<Image>();
        image.sprite = this.GetComponent<Image>().sprite;
        image.rectTransform.position = new Vector2(this.GetComponent<RectTransform>().position.x + distance, this.GetComponent<RectTransform>().position.y);

        return imageObject;
    }
}
