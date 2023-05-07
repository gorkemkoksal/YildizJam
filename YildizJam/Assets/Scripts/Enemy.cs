using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private Transform patrolPoint1;
    //[SerializeField] private Transform patrolPoint2;
    [SerializeField] private float patrolRightOffset;
    [SerializeField] private float patrolLeftOffset;
    private Transform enemySpawnPoint;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Transform player;

    [SerializeField] private Bullet bulletPrefab;

    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float hitDistance = 3f;
    [SerializeField] private float timeBetweenAttacks = 1f;

    private float timeSinceLastAttack;
    private bool isAttacking = false;

    private void Start()
    {
        PatrolR();
    }
    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        if (Mathf.Abs(player.position.y - transform.position.y) <= 0.5f && Mathf.Abs(player.position.x - transform.position.x) < hitDistance && !isAttacking && timeSinceLastAttack > timeBetweenAttacks)
        {
            isAttacking = true;
            DOTween.Kill(transform);
            Attack(player.position.x>transform.position.x);
            timeSinceLastAttack = 0f;
        }
        else if (isAttacking)
        {
            isAttacking = false;
            PatrolL();
        }
    }
    private void PatrolR()
    {
        // transform.DOLocalMove(patrolPoint1.position, movementSpeed).SetEase(Ease.Linear).SetDelay(2.5f).onComplete = PatrolL;
        // transform.DOLocalMove(enemySpawnPoint.position+new Vector3(patrolRightOffset,0,0), movementSpeed).SetEase(Ease.Linear).SetDelay(2.5f).onComplete = PatrolL;
        transform.DOLocalMove(new Vector3(patrolRightOffset, 0, 0), movementSpeed).SetEase(Ease.Linear).SetDelay(2.5f).onComplete = PatrolL;
    }
    private void PatrolL()
    {
        //transform.DOLocalMove(patrolPoint2.position, movementSpeed).SetEase(Ease.Linear).SetDelay(2.5f).onComplete = PatrolR;
        //transform.DOLocalMove(enemySpawnPoint.position + new Vector3(patrolLeftOffset, 0, 0), movementSpeed).SetEase(Ease.Linear).SetDelay(2.5f).onComplete = PatrolR;
        transform.DOLocalMove(new Vector3(patrolLeftOffset, 0, 0), movementSpeed).SetEase(Ease.Linear).SetDelay(2.5f).onComplete = PatrolL;
    }
    private void Attack(bool isLeft)
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position,Quaternion.identity);
        bullet.SetBulletSpeed(isLeft);
    }
}