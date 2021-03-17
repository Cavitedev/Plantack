using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pickPlayers;
    [SerializeField] private GameObject options;
    
    
    public void PlayGame()
    {
        mainMenu.SetActive(false);
        pickPlayers.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        pickPlayers.SetActive(false);
        options.SetActive(false);
    }
    
}
