using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Image square;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    public void ShowSquare()
    {
        square.gameObject.SetActive(true);
    }

    public void HideSquare()
    {
        square.gameObject.SetActive(false);
    }
    
    public void LoadExhibition()
    {
        SceneManager.LoadScene("Exhibition");
    }
}
