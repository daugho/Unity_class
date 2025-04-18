using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    int _speed = 5; // Speed of the player
    private float _gravity = -9.81f; // Gravity acceleration
    private float _velocity = 0f; // Current velocity of the player
    public enum STATE
    {
        IDLE,
        MOVE,
        HITTED
    }
    private int _currentSpriteIndex;
    
    [SerializeField] private Sprite[] IdleSprites;
    [SerializeField] private Sprite[] WalkSprites;
    [SerializeField] private Transform firePoint;
    private SpriteRenderer _renderer;

    private STATE _currentState;
    private void Awake()
    {
        _currentState = STATE.IDLE;
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void MoveInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * _speed;
            _renderer.flipX = true;
            _currentState = STATE.MOVE;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * _speed;
            _renderer.flipX = false;
            _currentState = STATE.MOVE;
        }
        else
            _currentState = STATE.IDLE;
    }
    private float _accTime = 0;

    private void IDLE_Action()
    {
        MoveInput();
        _accTime += Time.deltaTime;
        if (_accTime >= 0.2f)
        {
            _currentSpriteIndex++;
            if (_currentSpriteIndex >= IdleSprites.Length)
            {
                _currentSpriteIndex = 0;
            }
        _renderer.sprite = IdleSprites[_currentSpriteIndex];
            _accTime = 0;
        }
    }
    private void MOVE_Action()
    {
        MoveInput();
        _accTime += Time.deltaTime;
        if (_accTime >= 0.2f)
        {
            _currentSpriteIndex++;
            if (_currentSpriteIndex >= WalkSprites.Length)
            {
                _currentSpriteIndex = 0;
            }
            _renderer.sprite = WalkSprites[_currentSpriteIndex];
            _accTime = 0;
        }
    }
    private void HITTED_Action()
    {

    }
    void Update()
    {
        switch (_currentState)
        {
            case STATE.IDLE:
                IDLE_Action();
                break;
            case STATE.MOVE:
                MOVE_Action();
                break;
            case STATE.HITTED:
                HITTED_Action();
                break;
        }
        if(Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            _currentState = STATE.HITTED;
        }
    }
    private void FireBullet()
    {
        GameObject bulletObj = BulletPool.Instance.GetBullet();
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.Fire(firePoint.position); // 발사 위치 설정
    }
}
