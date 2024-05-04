using Fusion;
using UnityEngine;

public class Ball : NetworkBehaviour
{
    [SerializeField] private float speed = 2;
    [Networked] private TickTimer LifeTime { get; set; }

    public override void Spawned()
    {
        base.Spawned();
        LifeTime = TickTimer.CreateFromSeconds(Runner, 3f);
    }


    public override void FixedUpdateNetwork()
    {
        if (LifeTime.Expired(Runner))
        {
            Runner.Despawn(Object);
        }
        else
        {
            transform.position += Vector3.forward * (speed * Runner.DeltaTime);
        }
    }
}