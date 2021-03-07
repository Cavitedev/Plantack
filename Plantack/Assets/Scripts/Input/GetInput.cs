using UnityEngine;
namespace Plantack.PlayerController
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
            get => Controller.Keys.BasicMovement.ReadValue<float>();
        }
        public float Climb
        {
            get => Controller.Keys.Climb.ReadValue<float>();
        }
        public bool Jump
        {
            get => Controller.Keys.Jump.triggered;
        }
        public bool Fall
        {
            get => Controller.Keys.Fall.triggered;
        }
        public bool Dash
        {
            get => Controller.Keys.Dash.triggered;
        }
        public bool Run
        {
            get => Controller.Keys.Run.triggered;
        }
        
        public bool Enter
        {
            get => Controller.Keys.Enter.triggered;
        }
        #endregion
    }
}