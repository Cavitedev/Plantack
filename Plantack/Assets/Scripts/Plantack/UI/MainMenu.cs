using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    
    
    public void PlayGame()
    {
        Debug.Log("PLAY");
        SceneManager.LoadScene("Level_0");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
