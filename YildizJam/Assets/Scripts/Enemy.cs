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
   // private float 
    private bool isAttacking = false;
    private bool isFacingLeft;

    private void Start()
    {
        PatrolR();
    }
    void Update()
    {
        if (Mathf.Abs(player.position.y - transform.position.y) <= 0.5f && Mathf.Abs(player.position.x - transform.position.x) < hitDistance && !isAttacking)
        {
            isAttacking = true;
            DOTween.Kill(transform);
            Attack();
        }
        else if (isAttacking)
        {
            isAttacking = false;
            StartCoroutine(Attack());
        }
    }
    private void PatrolR()
    {
        isFacingLeft = false;
        transform.DOLocalMove(patrolPoint1.position, movementSpeed).SetEase(Ease.Linear).SetDelay(2.5f).onComplete = PatrolL;
    }
    private void PatrolL()
    {
        isFacingLeft = true;
        transform.DOLocalMove(patrolPoint2.position, movementSpeed).SetEase(Ease.Linear).SetDelay(2.5f).onComplete = PatrolR;
    }
    IEnumerator Attack()
    {
        print("Attack");

        Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.SetBulletSpeed(isFacingLeft);
        yield return new WaitForSeconds(1f);
    }
}