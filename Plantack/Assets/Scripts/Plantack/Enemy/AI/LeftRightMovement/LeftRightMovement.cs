using System;
using UnityEngine;

namespace Plantack.Enemy.AI.LeftRightMovement
{
    public class LeftRightMovement : StateMachine
    {
        public float moveTime = 5;
        public float waitTime = 10;
        public float stopTime = 2;
        [SerializeField] private float speed = 5;
        [SerializeField] private bool moveLeftFirst = true;

        private Vector2 _startPos;
        public Vector2 currentDir;
        private const String MOVE = "Move";
        private const String STOPMOVE = "StopMove";

        private Animator _animator;
        private Rigidbody2D rb;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            _startPos = rb.position;
            currentDir = GetDefaultDir();
            SetState(new MovementState(this, moveTime));
        }


        public void Stop()
        {
            State.Stop();
        }

        public void FlipDir()
        {
            Vector3 localScale = transform.localScale;
            localScale =
                new Vector3(-localScale.x, localScale.y, localScale.z);
            transform.localScale = localScale;
            currentDir = -currentDir;
        }
        

        public void SetVelocity(Vector2 dir)
        {
            rb.velocity = dir.normalized * speed;
        }

        public void SetAnimatorMove()
        {
            _animator.SetTrigger(MOVE);
        }

        public void SetAnimatorStop()
        {
            _animator.SetTrigger(STOPMOVE);
        }



        private Vector2 GetDefaultDir()
        {
            return moveLeftFirst ? Vector2.left : Vector2.right;
        }
        
        public float GetTimeLeft()
        {
            return (CurrentTarget() - rb.position).magnitude / speed;
        }

        private Vector2 CurrentTarget()
        {
            if (currentDir == GetDefaultDir())
            {
                return TargetPos();
            }

            return _startPos;
        }

        private Vector2 TargetPos()
        {
            return _startPos + GetDefaultDir() * (speed * moveTime);
        }

        private void OnDrawGizmosSelected()
        {
            if (rb == null)
            {
                rb = GetComponent<Rigidbody2D>();
            }

            if (_startPos == Vector2.zero)
            {
                _startPos = rb.position;
            }
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(TargetPos(), 0.2f);
        }
    }
}