using System.Collections.Generic;
using Plantack.PlayerController;
using UnityEngine;

namespace Plantack.Movement
{
    [RequireComponent(typeof(GetInput), typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private const float DISTANCEFLOORTHRESHOLD = 0.05f;

        [SerializeField] private AnimationCurve dashCurve;
        [SerializeField] private float dashSpeed = 5f;
        [SerializeField] private float dashTime = 1f;


        [SerializeField] private float jumpForce = 10f;

        [SerializeField] private float moveSpeed = 5f;

        [SerializeField] private Transform foot1;
        [SerializeField] private Transform foot2;

        [SerializeField] private LayerMask enviromentMask;


        private float _dashCooldown;
        private float _originalGravityScale;
        private int _dashDir;

        private GetInput _input;
        private Rigidbody2D rb;

        void Start()
        {
            _dashCooldown = 0f;
            _input = GetComponent<GetInput>();
            rb = GetComponent<Rigidbody2D>();
            _originalGravityScale = rb.gravityScale;
        }

        void Update()
        {

            float xMovement = _input.Basic;
            float velY = rb.velocity.y;
            if (_dashCooldown <= 0f)
            {
                if (_input.Dash)
                {
                    _dashDir = xMovement < 0 ? -1 : 1;
                    rb.velocity = new Vector2(dashSpeed * _dashDir * dashCurve.Evaluate(1 - _dashCooldown / dashTime),
                        0);
                    rb.gravityScale = 0;
                    _dashCooldown = dashTime - Time.deltaTime;
                    return;
                }
            }
            else
            {
                rb.velocity = new Vector2(dashSpeed * _dashDir * dashCurve.Evaluate(1 - _dashCooldown / dashTime), 0);
                _dashCooldown -= Time.deltaTime;
                if (_dashCooldown < 0)
                {
                    rb.gravityScale = _originalGravityScale;
                }

                return;
            }

            if (_input.Jump && IsGrounded())
            {
                velY = jumpForce;
            }


            rb.velocity = new Vector2(xMovement * moveSpeed, velY);
        }

        public bool IsGrounded()
        {
            ContactFilter2D filter2D = new ContactFilter2D();
            filter2D.SetLayerMask(enviromentMask.value);
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            RaycastHit2D hit1 = Physics2D.Raycast(foot1.position, Vector2.down,
                 DISTANCEFLOORTHRESHOLD,  enviromentMask.value);


            if (hit1.collider != null)
            {
                return true;
            }

            RaycastHit2D hit2 = Physics2D.Raycast(foot2.position, Vector2.down,
                DISTANCEFLOORTHRESHOLD,  enviromentMask.value);
            return hit2.collider != null;
        }
    }
}