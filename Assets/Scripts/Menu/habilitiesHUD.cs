using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class habilitiesHUD : MonoBehaviour
{
    [SerializeField]private bool isCooldown;
    [SerializeField]private float cooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isCooldown){
            GetComponent<UnityEngine.UI.Image>().fillAmount += 1 / cooldown * Time.deltaTime;

            if(GetComponent<UnityEngine.UI.Image>().fillAmount >= 1){
                GetComponent<UnityEngine.UI.Image>().fillAmount = 1;
                isCooldown = false;
            }
        }
          
    }

    public void triggerTrap(float cd){
        Debug.Log("ativei");
        GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
        isCooldown = true;
        cooldown = cd;
    }
}
