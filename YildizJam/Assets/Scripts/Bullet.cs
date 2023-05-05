using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector3 speed;
    private Vector3 bulletSpeed;
    private IObjectPool<Bullet> pool;
    private void Start()
    {
        bulletSpeed = speed;
    }
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
    public void SetBulletSpeed(bool isLookingLeft)
    {
        if (isLookingLeft)
        {
            speed = -bulletSpeed;
        }
        else
        {
            speed = bulletSpeed;
        }
    }
}
