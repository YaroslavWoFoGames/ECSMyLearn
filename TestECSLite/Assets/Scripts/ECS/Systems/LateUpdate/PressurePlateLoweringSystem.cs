using Leopotam.EcsLite;
using UnityEngine;

public class PressurePlateLoweringSystem : IEcsRunSystem
{
    public void Run(EcsSystems ecsSystems)
    {
        var gameData = ecsSystems.GetShared<GameData>();
        var hitFilter = ecsSystems.GetWorld().Filter<HitComponent>().End();
        var hitPool = ecsSystems.GetWorld().GetPool<HitComponent>();

        var plateFilter = ecsSystems.GetWorld().Filter<PressurePlateComponent>().End();
        var platePool = ecsSystems.GetWorld().GetPool<PressurePlateComponent>();
  
        foreach (var hitEntity in hitFilter)
        {
           
            ref var hitComponent = ref hitPool.Get(hitEntity);

            foreach (var plateEntity in plateFilter)
            {
                ref var plateComponent = ref platePool.Get(plateEntity);
               
                    if (hitComponent.Collision.CompareTag(Constants.Tags.PlayerTag))//to do
                {
                        if (hitComponent.ThisGameobject.CompareTag(Constants.Tags.PlateTag1))
                            plateComponent.CurrentTransformPlateYellow.localPosition = Vector3.MoveTowards(plateComponent.CurrentTransformPlateYellow.localPosition,
                            new Vector3(plateComponent.CurrentTransformPlateYellow.localPosition.x, 0, plateComponent.CurrentTransformPlateYellow.localPosition.z), Time.deltaTime * plateComponent.SlabLoweringSpeed);
                        if (hitComponent.ThisGameobject.CompareTag(Constants.Tags.PlateTag2))
                            plateComponent.CurrentTransformPlateBlue.localPosition = Vector3.MoveTowards(plateComponent.CurrentTransformPlateBlue.localPosition,
                           new Vector3(plateComponent.CurrentTransformPlateBlue.localPosition.x, 0, plateComponent.CurrentTransformPlateBlue.localPosition.z), Time.deltaTime * plateComponent.SlabLoweringSpeed);

                    }
                
            }

        }
    }
}
