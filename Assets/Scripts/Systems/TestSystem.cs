using Unity.Burst;
using Unity.Entities;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

partial struct TestSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        // int unitCount = 0;
        // foreach ((
        //              RefRW<LocalTransform> localTransform, 
        //              RefRO<Zombie> unitMover,
        //              RefRW<PhysicsVelocity> physicsVelocity)
        //          in SystemAPI.Query<RefRW<LocalTransform>, 
        //              RefRO<Zombie>, 
        //              RefRW<PhysicsVelocity>>())
        // {
        //     ++unitCount;
        // }
        //
        // Debug.Log("unitCount : " + unitCount);
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
