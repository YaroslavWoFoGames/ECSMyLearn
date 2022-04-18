using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    private EcsWorld EcsWorld;

    private void Start()
    {
        EcsWorld = GameObject.FindGameObjectWithTag("Startup").GetComponent<ECSGameStartup>().EcsWorld;
    }
    private void OnCollisionStay(Collision collision)
    {
        var hit = EcsWorld.NewEntity();
        var hitPool = EcsWorld.GetPool<HitComponent>();
        hitPool.Add(hit);
        ref var hitComponent = ref hitPool.Get(hit);

        hitComponent.ThisGameobject = gameObject;
        hitComponent.Collision = collision.gameObject;

    }
}
