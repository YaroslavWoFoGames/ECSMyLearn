using Leopotam.EcsLite;
using UnityEngine;

public class PlayerMoveSystem : IEcsRunSystem
{
    public void Run(EcsSystems ecsSystems)
    {
        var filter = ecsSystems.GetWorld().Filter<PlayerComponent>().Inc<PlayerInputComponent>().End();
        var playerPool = ecsSystems.GetWorld().GetPool<PlayerComponent>();
        var playerInputPool = ecsSystems.GetWorld().GetPool<PlayerInputComponent>();

        foreach (var entity in filter)
        {
            ref var playerComponent = ref playerPool.Get(entity);
            ref var playerInputComponent = ref playerInputPool.Get(entity);

            playerComponent.CurrentTransform.localPosition = Vector3.MoveTowards(playerComponent.CurrentTransform.localPosition, playerInputComponent.TargetPoint, Time.deltaTime * playerComponent.MoveSpeed);
        }
    }
}
