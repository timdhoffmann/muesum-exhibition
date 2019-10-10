using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Image square;


    void Update()
    {

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
