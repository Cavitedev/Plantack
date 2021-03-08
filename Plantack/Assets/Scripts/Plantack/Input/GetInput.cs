using UnityEngine;

namespace Plantack.Input
{
    public class GetInput : MonoBehaviour
    {
        #region Variables
        PlayerController Controller;

        #endregion

        #region Initialization
        private void OnEnable()
        {
            Controller.Enable();
        }
        private void OnDisable()
        {
            Controller.Disable();
        }
        private void Awake()
        {
            Controller = new PlayerController();
        }
        #endregion

        #region GetInput
        public float Basic
        {
            get => Controller.InputMap.Basic.ReadValue<float>();
        }
        public float Climb
        {
            get => Controller.InputMap.Climb.ReadValue<float>();
        }
        public bool Jump
        {
            get => Controller.InputMap.Jump.triggered;
        }
        public bool Fall
        {
            get => Controller.InputMap.Fall.triggered;
        }
        public bool Dash
        {
            get => Controller.InputMap.Dash.triggered;
        }
        public bool Run
        {
            get => Controller.InputMap.Run.triggered;
        }        
        public bool Enter
        {
            get => Controller.InputMap.Enter.triggered;
        }
        #endregion
    }
}