using UnityEngine;
public abstract class State
{
    public abstract void Enter();
    public abstract void Tick(float deltaTime);
    public abstract void FixedTick(float fixedDeltatime);
    public abstract void Exit();
    public abstract void OnTriggerEnter2D(Collider2D other);
}
