using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform patrolPoint1;
    [SerializeField] private Transform patrolPoint2;

    [SerializeField] private Transform player;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float hitDistance = 3f;
    [SerializeField] private Bullet bulletPrefab;
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

        if (Mathf.Abs(player.position.y - transform.position.y) <= 0.5f && Mathf.Abs(player.position.x - transform.position.x) < hitDistance && !isAttacking)
        {
            isAttacking = true;
            DOTween.Kill(transform);
            Attack(player.position.x>transform.position.x);
        }
        else if (isAttacking && timeSinceLastAttack > timeBetweenAttacks)
        {
            timeSinceLastAttack = 0f;
            isAttacking = false;
            Attack(player.position.x > transform.position.x);
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
        print("Attack");

        Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.SetBulletSpeed(isLeft);
    }
}