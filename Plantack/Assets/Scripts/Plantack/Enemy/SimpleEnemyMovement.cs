using System;
using System.Collections;
using UnityEngine;

namespace Plantack.Enemy
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
    public class SimpleEnemyMovement : MonoBehaviour
    {
        [SerializeField] private float moveTime = 5;
        [SerializeField] private float waitTime = 10;
        [SerializeField] private float stopTime = 2;
        [SerializeField] private float speed = 5;
        [SerializeField] private bool moveLeftFirst = true;

        private Vector2 _startPos;
        private Vector2 _currentDir;
        private const String _move = "Move";
        private const String _stopMove = "StopMove";

        private Animator _animator;
        private Rigidbody2D rb;


        private void Start()
        {
            _animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            _startPos = rb.position;
            StartCoroutine(Movement(moveLeftFirst));
        }

        public void Stop()
        {
            StopAllCoroutines();
            StartCoroutine(StopCoroutine());
        }
        
        private IEnumerator Movement(bool startLeft)
        {
            while (true)
            {
                if (startLeft)
                {
                    _currentDir = GetDefaultDir();
                    yield return Move(_currentDir, moveTime);
                    FlipCharacter();
                }
                _currentDir = -GetDefaultDir();
                yield return Move(_currentDir, moveTime);
                FlipCharacter();
            }
        }

        
        private IEnumerator StopCoroutine()
        {
            rb.velocity = Vector2.zero;
            _animator.SetTrigger(_stopMove);
            yield return new WaitForSeconds(stopTime);
            bool isMovingLeft = _currentDir == Vector2.left;
            float movementLeft = (CurrentTarget() - rb.position).magnitude;
            float totalMovement = speed * moveTime;
            yield return Move(_currentDir,   moveTime * movementLeft / totalMovement);
            FlipCharacter();
            StartCoroutine(Movement(!isMovingLeft));
        }

        private Vector2 GetDefaultDir()
        {
            return moveLeftFirst ? Vector2.left : Vector2.right;
        }

        private void FlipCharacter()
        {
            Vector3 localScale = transform.localScale;
            localScale =
                new Vector3(-localScale.x, localScale.y, localScale.z);
            transform.localScale = localScale;
        }

        private IEnumerator Move(Vector2 dir, float moveTime)
        {
            _animator.SetTrigger(_move);
            rb.velocity = dir.normalized * speed;
            yield return new WaitForSeconds(moveTime);
            _animator.SetTrigger(_stopMove);
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(waitTime);
        }

        private Vector2 CurrentTarget()
        {
            if (moveLeftFirst)
            {
                if (_currentDir == Vector2.left)
                {
                    return TargetPos();
                }

                return _startPos;
            }

            if (_currentDir == Vector2.left)
            {
                return _startPos;
            }

            return TargetPos();
        }

        private Vector2 TargetPos()
        {
            return rb.position + GetDefaultDir() * (speed * moveTime);
        }

        private void OnDrawGizmosSelected()
        {
            if (rb == null)
            {
                rb = GetComponent<Rigidbody2D>();
            }
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(TargetPos(), 0.2f);
        }
    }
}