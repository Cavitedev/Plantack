using UnityEngine;

namespace Plantack.Movement.Cavitedev.Dash
{
    [System.Serializable]
    public class PlayerDashMovement
    {
        [SerializeField] private AnimationCurve dashCurve;
        [SerializeField] private float dashSpeed = 5f;

        private Rigidbody2D _rb;

        public Rigidbody2D rb
        {
            get => _rb;
            set
            {
                _rb = value;
                _originalGravityScale = _rb.gravityScale;
            }
        }

        private float _originalGravityScale;
        private int _dashDir;


        public void StartDash()
        {
            rb.gravityScale = 0;
        }

        public void Move(float relativeTime, float xDir)
        {
            _dashDir = xDir < 0 ? -1 : 1;
            rb.velocity = new Vector2(dashSpeed * _dashDir * dashCurve.Evaluate(relativeTime),
                0);
        }

        public void Move(float relativeTime)
        {
            Move(relativeTime, _dashDir);
        }

        public void EndDash()
        {
            rb.gravityScale = _originalGravityScale;
        }
    }
}