using Plantack.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Plantack.UI
{
    public class Pause : MonoBehaviour
    {

        [SerializeField] private string backScene = "MainMenu";

        [SerializeField] private GameObject panel;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject optionsMenu;


        #region inputController

        PlayerController _controller;
        

        private void OnEnable()
        {
            _controller.Enable();
        }

        private void OnDisable()
        {
            _controller.Disable();
        }

        private void Awake()
        {
            _controller = new PlayerController();
        }

        #endregion
       

        public void Resume()
        {
            panel.SetActive(false);
            Time.timeScale = 1f;
        }

        public void Restart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Options()
        {
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }

        public void MenuBack()
        {
            pauseMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }

        public void Exit()
        {
            SceneManager.LoadScene(backScene);
        }

        private void ToggleMenuVisibility()
        {
            panel.SetActive(!panel.activeSelf);
            if (panel.activeSelf)
            {
                Time.timeScale = 0f;
                MenuBack();
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        void Update()
        {
            if (_controller.InputMap.Quit.triggered)
            {
                ToggleMenuVisibility();
            }
        }
    }
}