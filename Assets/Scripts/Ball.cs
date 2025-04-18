using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private AudioClip[] _popSFX;
    private AudioSource _audioSource;
    [SerializeField] private GameObject ballPrefab;

    private float _gravity = -9.81f; // 중력 가속도
    private float _velocity = 0f;
    private float _groundY = -3.83f;
    private float _bouncePower = 10f;
    private float _setSpeed = 2f;
    private bool _isLestMove = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
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
        if (collision.CompareTag("Bullet"))
        {
            _audioSource.PlayOneShot(_popSFX[0],1.2f);
            collision.gameObject.SetActive(false);
            SplitBall();
            gameObject.SetActive(false); // Ball 비활성화
        }
        else
            _audioSource.PlayOneShot(_popSFX[1]);
    }
    private void SplitBall()
    {
        float scaleFactor = 0.5f;
        Vector3 newScale = transform.localScale * scaleFactor;

        if (newScale.x < 0.2f) return; // 너무 작으면 분열하지 않음


        GameObject ballLeft = Instantiate(ballPrefab, transform.position + Vector3.left * 0.5f, Quaternion.identity);
        ballLeft.transform.localScale = newScale;
        ballLeft.GetComponent<Ball>()._isLestMove = true;


        GameObject ballRight = Instantiate(ballPrefab, transform.position + Vector3.right * 0.5f, Quaternion.identity);
        ballRight.transform.localScale = newScale;
        ballRight.GetComponent<Ball>()._isLestMove = false;
    }
}
