using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    public void OnStartPress()
    {
        SceneManager.LoadScene("main game");
    }

    public void OnHomePress()
    {
        SceneManager.LoadScene("title screen");
    }

    public void OnExitPress()
    {
        Application.Quit();
    }

    public void OnStorePress()
    {
        SceneManager.LoadScene("skins");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
