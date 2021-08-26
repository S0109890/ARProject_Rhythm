using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KTH_GameManager : MonoBehaviour
{
    public static KTH_GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    //public GameObject Result;

    // Start is called before the first frame update
    void Start()
    {
        //Result.SetActive(false);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnShowResult()
    {
        KTH_Result.instance.ShowResult();
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }
}
