using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Movement related
    public float moveSpeed = 5f;
    [Range(0, 1)] public float friction = 0.05f;
    private float _horizontalInput;
    private Rigidbody2D _rigidbody2D;
    
    // Animation related
    private Animator _animator;
    private static readonly int HorizontalMovement = Animator.StringToHash("HorizontalMovement");

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

        _animator.SetFloat(HorizontalMovement,Mathf.Abs(velocity.x));

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
    }

    private void FixedUpdate()
    {
        #region Applying fake friction to player

        if (Mathf.Abs(_rigidbody2D.velocity.x) > 0.005f)
        {
            _rigidbody2D.velocity *= Vector2.right * (1-friction); 
        }

        #endregion
    }
}
