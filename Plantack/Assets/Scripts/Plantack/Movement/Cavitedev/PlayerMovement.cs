using System.Collections.Generic;
using Plantack.Input;
using Plantack.Movement.Cavitedev.Dash;
using UnityEngine;

namespace Plantack.Movement.Cavitedev
{
    [RequireComponent(typeof(GetInput), typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private const float DISTANCEFLOORTHRESHOLD = 0.05f;

        [SerializeField] private PlayerDash playerDash;


        [SerializeField] private float jumpForce = 10f;

        [SerializeField] private float moveSpeed = 5f;

        [SerializeField] private Transform foot1;
        [SerializeField] private Transform foot2;

        [SerializeField] private LayerMask enviromentMask;


        private GetInput _input;
        private Rigidbody2D rb;

        void Start()
        {
            _input = GetComponent<GetInput>();
            rb = GetComponent<Rigidbody2D>();
            playerDash.setRb(rb);
        }

        void Update()
        {

            float xMovement = _input.Basic;
            float velY = rb.velocity.y;
            
            bool isDashing = playerDash.Dash(_input.Dash, xMovement);
            if (isDashing) return;
            
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