using UnityEngine;

public class pangPlayer : MonoBehaviour
{
    public enum STATE
    {
        IDLE,
        MOVE,
        HITTED
    }
    [SerializeField]
    private Sprite[] IdleSprites;
    [SerializeField]
    private Sprite[] WalkSprites;
    int playerSpeed = 3;
    private STATE _currentState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentState = STATE.IDLE;
    }
    private void MoveInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * playerSpeed * Time.deltaTime;
            _currentState = STATE.MOVE;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
            _currentState = STATE.MOVE;
        }
    }
    private void Idle_Action()
    {
        //Debug.Log("IDLE");
        _currentState = STATE.IDLE;
        MoveInput();
    }
    private void Move_Action()
    {
        //Debug.Log("MOVE");
        _currentState = STATE.MOVE;
        MoveInput();
    }
    // Update is called once per frame
    void Update()
    {
        switch(_currentState)
        {
            case STATE.IDLE:
                Idle_Action();
                break;
            case STATE.MOVE:
                Move_Action();
                break;
            case STATE.HITTED:
                break;
        }
        if(Input.GetMouseButtonDown(0))
        {
            _currentState = STATE.MOVE;
        }
        if (Input.GetMouseButtonDown(1))
        {
            _currentState = STATE.HITTED;
        }

    }
}
