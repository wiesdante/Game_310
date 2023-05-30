using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Vector3[] patrolLocations;
    [SerializeField] float duration;
    private int _i;
    bool _facingLeft = true;

    void Start()
    {
        Move(_i);
    }

    void Move(int point)
    {
        transform.DOMove(patrolLocations[point], duration)
            .SetEase(Ease.InOutSine)
            .OnPlay(() => { Flip(patrolLocations[point]); })
            .OnComplete(() =>
            {
                if (_i < patrolLocations.Length - 1)
                    _i += 1;
                else
                    _i = 0;

                Move(_i);
            })
            ;


    }

    void Flip(Vector3 point)
    {
        if (this.transform.position.x < point.x && _facingLeft)
        {
            Flip();
        }
        else if (this.transform.position.x > point.x && !_facingLeft)
        {
            Flip();
        }
    }

    void Flip()
    {
        var transform1 = this.transform;
        Vector3 theScale = transform1.localScale;
        theScale.x *= -1;
        transform1.localScale = theScale;
        this._facingLeft = !this._facingLeft;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
