using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.EcsLite;

public class PlayerInitSystem : IEcsInitSystem
{
    public void Init(EcsSystems ecsSystems)
    {
        var ecsWorld = ecsSystems.GetWorld();
        var gameData = ecsSystems.GetShared<GameData>();

        var playerEntity = ecsWorld.NewEntity();
        var playerPool = ecsWorld.GetPool<PlayerComponent>();
        playerPool.Add(playerEntity);

        ref var playerComponent = ref playerPool.Get(playerEntity);

        var playerInputPool = ecsWorld.GetPool<PlayerInputComponent>();
        playerInputPool.Add(playerEntity);
        ref var playerInputComponent = ref playerInputPool.Get(playerEntity);


        var playerGO = GameObject.FindGameObjectWithTag(Constants.Tags.PlayerTag);

        playerComponent.CurrentTransform = playerGO.transform;
        playerComponent.MoveSpeed = gameData.configuration._speedPlayer;
        playerInputComponent.StartPoint = gameData.configuration._startPlayerPoint;
        playerInputComponent.TargetPoint = gameData.configuration._startPlayerPoint;

    }



}
