using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        if (transform.position.y > 10f) // ȭ�� ��(�Ǵ� ���ϴ� ����) ������ ��Ȱ��ȭ
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