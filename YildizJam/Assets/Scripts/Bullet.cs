using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector3 speed;
    private IObjectPool<Bullet> pool;
    void Update()
    {
        transform.position += speed * Time.deltaTime;
    }
    public void SetPool(IObjectPool<Bullet> pool)
    {
        this.pool = pool;
    }
    private void OnBecameInvisible()
    {
        pool.Release(this);
    }
}
