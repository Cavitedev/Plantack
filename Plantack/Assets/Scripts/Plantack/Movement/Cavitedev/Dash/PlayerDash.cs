using UnityEngine;

namespace Plantack.Movement.Cavitedev.Dash
{
    [System.Serializable]
    public class PlayerDash
    {
        [SerializeField] private float dashTime = 1f;
        [SerializeField] private PlayerDashMovement movement;


        public void setRb(Rigidbody2D rb) => movement.rb = rb;

        private float _dashCooldown;


        public bool Dash(bool dashInput, float xMovement)
        {
            if (_dashCooldown <= 0f)
            {
                if (dashInput)
                {
                    movement.StartDash();
                    movement.Move(1 - _dashCooldown / dashTime, xMovement);
                    _dashCooldown = dashTime - Time.deltaTime;
                    return true;
                }
            }
            else
            {
                movement.Move(1 - _dashCooldown / dashTime);
                _dashCooldown -= Time.deltaTime;
                if (_dashCooldown < 0)
                {
                    movement.EndDash();
                    return false;
                }
                return true;
            }

            return false;
        }
    }
}