using UnityEngine;

public class Ball : MonoBehaviour
{
    private float _gravity = -9.81f; // 중력 가속도
    private float _velocity = 0f;
    private float _groundY = -3.83f;
    private float _bouncePower = 10f;
    private float _setSpeed = 2f;
    private bool _isLestMove = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Update()
    {
        _velocity += _gravity * Time.deltaTime;
        transform.position += new Vector3(0, _velocity * Time.deltaTime, 0);


        if (transform.position.y <= _groundY)
        {
            transform.position = new Vector3(transform.position.x, _groundY, transform.position.z);
            _velocity = _bouncePower;
        }

        if (_isLestMove)
        {
            LeftMove();
        }
        else
        {
            RightMove();
        }
        if (transform.position.x<=-9.61f|| transform.position.x >= 9.61f)
        {
            _isLestMove = !_isLestMove;
        }

    }
    private void LeftMove()
    {
        transform.position += Vector3.left * Time.deltaTime * _setSpeed;
    }
    private void RightMove()
    {
        transform.position += Vector3.right * Time.deltaTime * _setSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
    }
}
