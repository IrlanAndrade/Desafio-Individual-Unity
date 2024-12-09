using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1;
    [SerializeField] private string scene;
    // [SerializeField] private bool isMenuField;
    void Update()
    {
    //    ifInMenu();
    }
    // private void ifInMenu(){
    //     if (isMenuField == true && Input.GetKeyDown(KeyCode.R)){
    //         LoadMenu();
    //     }
    // }

    public void LoadMenu(){
        StartCoroutine(LoadLevel(scene));
    }

    IEnumerator LoadLevel(string scenename){

        yield return new WaitForSeconds(transitionTime);

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }
}
