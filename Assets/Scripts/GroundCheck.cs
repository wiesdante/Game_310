using System;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = gameObject.GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag($"Ground"))
        {
            _player.onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            _player.onGround = false;
        }
    }
}
