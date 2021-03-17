using Plantack.Input;
using UnityEngine;

namespace Plantack.Player
{
    [RequireComponent(typeof(GetInput), typeof(Rigidbody2D))]
    public class PlayerMover : MonoBehaviour
    {
        #region Components

        Animator anim;
        Rigidbody2D rb;
        GetInput input;
        PlayerVariables Character;
        PlayerStats _playerStats;

        #endregion

        #region Variables

        #region GroundChecker

        public Transform feetPos;
        public float checkerRadius = 0.3f;
        public LayerMask jumpOnWhat;

        #endregion

        #region Interactable

        public bool ladder;
        public GameObject ClimbButton;

        #endregion

        [SerializeField]
        private float InputX, InputY, Saxel, maxSpeed, moveSpeed, speedError, Gaxel, FallForce, gravity;

        [SerializeField] private bool running, climbing, onGround;
        [SerializeField] private Vector2 XYdir;
        private Quaternion rot;

        #endregion

        #region Initialization

        private void Start()
        {
            #region Define Components

            feetPos = transform.Find("feetPos").transform;
            anim = transform.Find("Player").GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            input = GetComponent<GetInput>();
            Character = new PlayerVariables();
            _playerStats = GetComponent<PlayerStats>();
            if (_playerStats != null)
            {
                _playerStats.onDamage += OnDamage;
            }

            #endregion

            #region Define Variables

            Saxel = Character.SpeedAcceleration;
            Gaxel = Character.GravityAcceleration;
            speedError = Character.SpeedError;
            gravity = Character.Gravity;
            rot = new Quaternion(0, 0, 0, 1);

            #endregion

            SetRB();
        }

        void SetRB()
        {
            rb.gravityScale = 0f;
            rb.freezeRotation = true;
        }

        #endregion

        #region Mover

        private void FixedUpdate()
        {
            GetDir();
            Animate();

            rb.velocity = XYdir;
        }

        private void Update()
        {
            onGround = Physics2D.OverlapCircle(feetPos.position, checkerRadius, jumpOnWhat);
            ApplyInput();
            Climb();
            Jump();
            MaxSpeed();
            Gravity();
            SetSpeed();
        }

        #endregion

        #region ApplyInputs

        private void ApplyInput()
        {
            InputX = 0f;
            InputY = 0f;

            if (input.Run)
                running = !running;
            if (!climbing)
            {
                InputX = input.Basic;
                if (InputX < 0 && rot.y != 180)
                {
                    rot.y = 180f;
                    transform.rotation = rot;
                }
                else if (InputX > 0 && rot.y != 0)
                {
                    rot.y = 0f;
                    transform.rotation = rot;
                }
            }

            if (climbing)
            {
                InputY = input.Climb;
            }
            else
                InputY = 1f;
        }

        #endregion

        #region Manage Forces/Speed

        private void MaxSpeed()
        {
            if (running)
                maxSpeed = Character.RunSpeed;
            else
                maxSpeed = Character.WalkSpeed;
        }

        private void Gravity()
        {
            if (!climbing)
            {
                if (FallForce < gravity)
                    FallForce = gravity;
                else if (FallForce > gravity)
                    FallForce -= Gaxel * Time.deltaTime;
            }
            else
                FallForce = Character.ClimbSpeed;
        }

        private void SetSpeed()
        {
            if (moveSpeed < maxSpeed - speedError)
                moveSpeed += Saxel;
            else if (moveSpeed > maxSpeed + speedError)
                moveSpeed -= Saxel;
        }

        #endregion

        #region Direction

        private void GetDir()
        {
            XYdir.x = InputX * moveSpeed;
            XYdir.y = InputY * FallForce;
        }

        #endregion

        #region Vertical

        private void Climb()
        {
            if (ladder && !climbing && input.EnableClimb)
                climbing = true;
            else if (climbing && (!ladder || input.EnableClimb))
                climbing = false;
        }

        private void Jump()
        {
            if (!climbing && onGround && input.Jump)
            {
                FallForce = Character.JumpForce;
                anim.SetTrigger("Jump");
            }
        }

        #endregion

        #region Ladder

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Ladder"))
            {
                ladder = true;
                ClimbButton.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Ladder"))
            {
                ladder = false;
                ClimbButton.SetActive(false);
            }
        }

        #endregion

        #region Animate

        void Animate()
        {
            anim.SetFloat("Movement", Mathf.Abs(InputX));
            anim.SetBool("Running", running);
            anim.SetBool("Climbing", climbing);
            if (climbing)
                anim.SetFloat("Climb", InputY);
        }

        #endregion

        private void OnDamage()
        {
            anim.SetTrigger("Damage");
            //TODO move the player back a little bit and disable input for specific amount of time
        }
    }
}