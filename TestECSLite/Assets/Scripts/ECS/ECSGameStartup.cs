using Leopotam.EcsLite;
using UnityEngine;

public class ECSGameStartup : MonoBehaviour
{
    public EcsWorld EcsWorld { get; private set; }
    private EcsSystems initSystems;
    private EcsSystems lateUpdateSystems;

    [SerializeField] private GameConfigSO configuration;

    private void Awake()
    {
        EcsWorld = new EcsWorld();
        var gameData = new GameData();

        gameData.configuration = configuration;

        initSystems = new EcsSystems(EcsWorld, gameData)
            .Add(new PlayerInitSystem())
            .Add(new DoorInitSystem())
            .Add(new PlateInitSystem());

        initSystems.Init();

        lateUpdateSystems = new EcsSystems(EcsWorld, gameData)
            .Add(new PlayerInputSystem())
            .Add(new PlayerMoveSystem())
            .Add(new PressurePlateLoweringSystem())
            .Add(new DoorLoweringSystem())
            ;

        lateUpdateSystems.Init();

    }

    private void LateUpdate()
    {
        lateUpdateSystems.Run();
    }

    private void OnDestroy()
    {
        initSystems.Destroy();
        lateUpdateSystems.Destroy();
        EcsWorld.Destroy();
    }

}
