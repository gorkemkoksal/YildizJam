using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform patrolPoint1;
    [SerializeField] private Transform patrolPoint2;

    [SerializeField] private Transform player;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float hitDistance = 3f;
    private bool isAttacking = false;

    private void Start()
    {
        PatrolR();
    }
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < hitDistance && !isAttacking)
        {
            isAttacking = true;
            DOTween.Kill(transform);
            Attack();
        }
        else if (isAttacking)
        {
            isAttacking = false;
            PatrolL();
        }
    }
    private void PatrolR()
    {
        transform.DOLocalMove(patrolPoint1.position, movementSpeed).SetDelay(2.5f).onComplete = PatrolL;
    }
    private void PatrolL()
    {
        transform.DOLocalMove(patrolPoint2.position, movementSpeed).SetDelay(2.5f).onComplete = PatrolR;
    }
    private void Attack()
    {
        print("Attack");
    }
}