using System;
using Managers;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Movement related
    [Header("Movement Related")]
    public float moveSpeed = 8f;
    [Range(0, 1)] public float friction = 0.05f;
    public float jumpForce = 4;
    private float _horizontalInput;
    private Rigidbody2D _rigidbody2D;
    public bool onGround;
    
    // Animation related
    private Animator _animator;
    private static readonly int HorizontalSpeed = Animator.StringToHash("HorizontalSpeed");
    private static readonly int VerticalSpeed = Animator.StringToHash("VerticalSpeed");
    private static readonly int OnGround = Animator.StringToHash("OnGround");
    
    // Questions related
    [Header("Questions Related")]
    public bool isOnAnswerBlock;
    public float currentAnswer;

    private void Start()
    {
        #region Introduce

        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();

        #endregion
    }

    private void Update()
    {
        #region Taking horizontal input and moving player accordingly

        _horizontalInput = Input.GetAxisRaw("Horizontal");
        var velocity = _rigidbody2D.velocity;
        velocity += Vector2.right * (moveSpeed * _horizontalInput * Time.deltaTime);
        _rigidbody2D.velocity = velocity;

        #endregion
        
        #region Setting animator parameters

        _animator.SetFloat(HorizontalSpeed,Mathf.Abs(velocity.x));
        _animator.SetFloat(VerticalSpeed,_rigidbody2D.velocity.y);
        _animator.SetBool(OnGround,onGround);


        #endregion

        #region Turning player sprite left/right according horizontal input

        if (Math.Abs(_horizontalInput - 1) < 0.05f)
        {
            var transform1 = transform;
            var localScale = transform1.localScale;
            localScale = new Vector3(1,localScale.y,localScale.z);
            transform1.localScale = localScale;
        }
        else if (Math.Abs(_horizontalInput - (-1)) < 0.05f)
        {
            var transform1 = transform;
            var localScale = transform1.localScale;
            localScale = new Vector3(-1,localScale.y,localScale.z);
            transform1.localScale = localScale;
        }

        #endregion

        #region Taking jump input and setting vertical velocity accordingly

        if (Input.GetButtonDown("Jump") && onGround)
        {
            onGround = false;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }

        #endregion

        #region Taking interact input and calling related functions

        if (Input.GetButtonDown("Interact") && isOnAnswerBlock)
        {
            GameManager.Instance.AttemptToAnswer(currentAnswer);
        }

        #endregion
    }

    private void FixedUpdate()
    {
        #region Applying fake horizontal friction to player

        if (Mathf.Abs(_rigidbody2D.velocity.x) > 0.005f)
        {
            var velocity = _rigidbody2D.velocity;
            velocity.x *= (1 - friction);
            _rigidbody2D.velocity = velocity;
        }

        #endregion
    }
}
