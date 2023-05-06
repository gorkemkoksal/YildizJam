using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] private bool isPooled;

    [SerializeField] private Vector3 defaultBulletSpeed = new Vector3(10, 0, 0);
    private Vector3 speed;
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
        if (isPooled)
        {
            pool.Release(this);
        }
        else
        {
            Destroy(this);
        }
    }
    public void SetBulletSpeed(bool isLookingRight)
    {
        if (!isLookingRight)
        {
            speed = -defaultBulletSpeed;
        }
        if (isLookingRight)
        {
            speed = defaultBulletSpeed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isPooled)
        {
            pool.Release(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
