using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform patrolPoint1;
    [SerializeField] private Transform patrolPoint2;
    [SerializeField] private Transform spawnPoint;
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
        transform.DOLocalMove(patrolPoint1.position, movementSpeed).SetEase(Ease.Linear).SetDelay(2.5f).onComplete = PatrolL;
    }
    private void PatrolL()
    {
        transform.DOLocalMove(patrolPoint2.position, movementSpeed).SetEase(Ease.Linear).SetDelay(2.5f).onComplete = PatrolR;
    }
    private void Attack(bool isLeft)
    {
        Bullet bullet = Instantiate(bulletPrefab, spawnPoint.position,Quaternion.identity);
        bullet.SetBulletSpeed(isLeft);
    }
}