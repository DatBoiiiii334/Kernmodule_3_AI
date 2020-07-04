using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("BehaviourTree");
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
