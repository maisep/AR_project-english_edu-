using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class button : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void study()
    {
        SceneManager.LoadScene("Ar_Study");
    }

    public void test()
    {
        SceneManager.LoadScene("Ar_Test");
    }

    public void exit()
    {
        Application.Quit();
    }

    public void menu()
    {
        SceneManager.LoadScene("Start");
    }



}
