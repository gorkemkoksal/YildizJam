using UnityEngine;
using UnityEngine.Pool;

public class Launcher : MonoBehaviour
{
    public IObjectPool<Bullet> bulletPool;
    [SerializeField] private Bullet[] bulletPrefabs;
    [SerializeField] private Transform spawnPoint;
    private Bullet bulletPrefab;
    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(CreateBullet, OnGet, OnRelease, OnBulletDestroy, maxSize: 10);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {                                                                      
         //   bulletPool.Get();                        //ates etmeleri buraya koy (Update icine)
        }
        //else if (Input.GetKeyDown(KeyCode.Mouse1))
        //{
        //    SetBullet(1);
        //    print(bulletPrefab);
        //    bulletPool.Get();
        //}
    }
    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab);
        bullet.SetPool(bulletPool);
        return bullet;
    }
    private void OnGet(Bullet bullet)
    {
        bullet.transform.position = spawnPoint.position;
        bullet.gameObject.SetActive(true);
    }
    private void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
    private void OnBulletDestroy(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
    //public void SetBullet(int index)
    //{
    //    bulletPrefab = bulletPrefabs[index];           //bunu player silah degisme yerinde cagirmamiz lazim(simdilik dengesiz biraz)
    //}

}
