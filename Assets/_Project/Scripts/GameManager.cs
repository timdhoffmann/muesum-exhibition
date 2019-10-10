using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< Updated upstream

public class GameManager : MonoBehaviour
{
=======
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image square;

>>>>>>> Stashed changes
    void Update()
    {

    }

<<<<<<< Updated upstream
=======
    public void ShowSquare()
    {
        square.gameObject.SetActive(true);
    }

    public void HideSquare()
    {
        square.gameObject.SetActive(false);
    }

>>>>>>> Stashed changes
    public void LoadExhibition()
    {
        SceneManager.LoadScene("Exhibition");
    }
}
