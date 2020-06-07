using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void QuiteGame()
    {
        Debug.Log("game quit");
        Application.Quit();
    }
}
