using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.EcsLite;

public class PlateInitSystem : IEcsInitSystem
{
    public void Init(EcsSystems ecsSystems)
    {
        var ecsWorld = ecsSystems.GetWorld();
        var gameData = ecsSystems.GetShared<GameData>();

        var plateEntity = ecsWorld.NewEntity();
        var platePool = ecsWorld.GetPool<PressurePlateComponent>();
        platePool.Add(plateEntity);

        ref var plateComponent = ref platePool.Get(plateEntity);

        var plateGO1 = GameObject.FindGameObjectWithTag(Constants.Tags.PlateTag1);
        var plateGO2 = GameObject.FindGameObjectWithTag(Constants.Tags.PlateTag2);

        plateComponent.SlabLoweringSpeed = gameData.configuration._speedPlateDown;
        plateComponent.TargetPointPlateMovement = gameData.configuration._targetDownPointPlate;
        plateComponent.CurrentTransformPlateYellow = plateGO1.transform;
        plateComponent.CurrentTransformPlateBlue = plateGO2.transform;
    }
}
