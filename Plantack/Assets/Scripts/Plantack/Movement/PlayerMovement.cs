using Plantack.PlayerController;
using UnityEngine;

[RequireComponent(typeof(GetInput), typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AnimationCurve dashCurve;
    [SerializeField] private float dashSpeed = 5;
    [SerializeField] private float dashTime = 1;


    [SerializeField] private float jumpForce = 10;

    [SerializeField] private float moveSpeed = 5;

    private float _dashCooldown;
    private float _lastVelocityY;
    private float _originalGravityScale;
    private int _dashDir;
    
    private GetInput _input;
    private Rigidbody2D rb;

    void Start()
    {
        _dashCooldown = 0;
        _input = GetComponent<GetInput>();
        rb = GetComponent<Rigidbody2D>();
        _originalGravityScale = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = _input.Basic;
        float velY = rb.velocity.y;
        if (_dashCooldown <= 0)
        {
            if (_input.Dash)
            {
                _lastVelocityY = velY;
                _dashDir = xMovement < 0 ? -1 : 1;
                rb.velocity = new Vector2(dashSpeed * _dashDir * dashCurve.Evaluate(1 - _dashCooldown / dashTime), 0);
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

        if (_input.Jump)
        {
            velY = jumpForce;
        }


        rb.velocity = new Vector2(xMovement * moveSpeed, velY);
    }
}