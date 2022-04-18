using Leopotam.EcsLite;
using UnityEngine;

public class DoorLoweringSystem : IEcsRunSystem
{
    public void Run(EcsSystems ecsSystems)
    {
        var gameData = ecsSystems.GetShared<GameData>();
        var hitFilter = ecsSystems.GetWorld().Filter<HitComponent>().End();
        var hitPool = ecsSystems.GetWorld().GetPool<HitComponent>();

        var doorFilter = ecsSystems.GetWorld().Filter<DoorComponent>().End();
        var doorPool = ecsSystems.GetWorld().GetPool<DoorComponent>();
       
        foreach (var hitEntity in hitFilter)
        {
            
            ref var hitComponent = ref hitPool.Get(hitEntity);

            foreach (var doorEntity in doorFilter)
            {
                ref var doorComponent = ref doorPool.Get(doorEntity);

                
                    if (hitComponent.Collision.CompareTag(Constants.Tags.PlayerTag))//to do
                    {
                        if (hitComponent.ThisGameobject.CompareTag(Constants.Tags.PlateTag1))
                            doorComponent.CurrentTransformDoorBlue.localPosition = Vector3.MoveTowards(doorComponent.CurrentTransformDoorBlue.localPosition,
                             new Vector3(doorComponent.CurrentTransformDoorBlue.localPosition.x, doorComponent.TargetPointDoorMovement, doorComponent.CurrentTransformDoorBlue.localPosition.z), Time.deltaTime * doorComponent.DoorLoweringSpeed);

                        if (hitComponent.ThisGameobject.CompareTag(Constants.Tags.PlateTag2))
                            doorComponent.CurrentTransformDoorYellow.localPosition = Vector3.MoveTowards(doorComponent.CurrentTransformDoorYellow.localPosition,
                             new Vector3(doorComponent.CurrentTransformDoorYellow.localPosition.x, doorComponent.TargetPointDoorMovement, doorComponent.CurrentTransformDoorYellow.localPosition.z), Time.deltaTime * doorComponent.DoorLoweringSpeed);
                    
                    }
                
            }

        }
    }
}
