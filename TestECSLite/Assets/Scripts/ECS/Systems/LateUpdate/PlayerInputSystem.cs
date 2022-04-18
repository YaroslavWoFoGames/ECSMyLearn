using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSystem : IEcsRunSystem
{
    public void Run(EcsSystems ecsSystems)
    {
        var filter = ecsSystems.GetWorld().Filter<PlayerInputComponent>().End();
        var playerInputPool = ecsSystems.GetWorld().GetPool<PlayerInputComponent>();

        foreach (var entity in filter)
        {
            ref var playerInputComponent = ref playerInputPool.Get(entity);
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit;
                Physics.Raycast(ray, out raycastHit);
                playerInputComponent.TargetPoint = new Vector3(raycastHit.point.x, 1, raycastHit.point.z);
            }

        }
    }


}
