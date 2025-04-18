using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        if (transform.position.y > 10f) // 화면 밖(또는 원하는 높이) 나가면 비활성화
        {
            gameObject.SetActive(false);
        }
    }

    public void Fire(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }
}