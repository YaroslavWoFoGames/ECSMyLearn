using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.EcsLite;

public class DoorInitSystem : IEcsInitSystem
{
    public void Init(EcsSystems ecsSystems)
    {
        var ecsWorld = ecsSystems.GetWorld();
        var gameData = ecsSystems.GetShared<GameData>();

        var doorEntity = ecsWorld.NewEntity();
        var doorPool = ecsWorld.GetPool<DoorComponent>();
        doorPool.Add(doorEntity);

        ref var doorComponent = ref doorPool.Get(doorEntity);

        var doorGO1 = GameObject.FindGameObjectWithTag(Constants.Tags.DoorTag1);
        var doorGO2 = GameObject.FindGameObjectWithTag(Constants.Tags.DoorTag2);

        doorComponent.DoorLoweringSpeed = gameData.configuration._speedDoorDown;
        doorComponent.TargetPointDoorMovement = gameData.configuration._targetDownPointDoor;
        doorComponent.CurrentTransformDoorYellow = doorGO1.transform;
        doorComponent.CurrentTransformDoorBlue = doorGO2.transform;
    }
}
