using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 20;

    private List<GameObject> _pool;

    public static BulletPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        _pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            _pool.Add(bullet);
        }
    }

    public GameObject GetBullet()
    {
        foreach (var bullet in _pool)
        {
            if (!bullet.activeInHierarchy)
                return bullet;
        }

        // 풀에 여유가 없으면 확장도 가능 (선택)
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.SetActive(false);
        _pool.Add(newBullet);
        return newBullet;
    }
}
