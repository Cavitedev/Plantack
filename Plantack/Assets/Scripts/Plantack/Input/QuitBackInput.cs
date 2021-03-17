using Plantack.Input;
using UnityEngine;

public class QuitBackInput : MonoBehaviour
{


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


    void Update()
    {
        if (_controller.InputMap.Quit.triggered)
        {
            Application.Quit();
        }
    }
}