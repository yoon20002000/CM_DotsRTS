using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

partial struct UnitMoverSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach ((RefRW<LocalTransform> localTransform, RefRO<UnitMover> unitMover, RefRW<PhysicsVelocity> physicsVelocity) 
                 in SystemAPI.Query<RefRW<LocalTransform>, RefRO<UnitMover>, RefRW<PhysicsVelocity>>())
        {
            float3 moveDirection = unitMover.ValueRO.targetPosition - localTransform.ValueRO.Position;
            if (moveDirection is { x: 0, y: 0, z: 0 })
            {
                return;
            }
            moveDirection = math.normalize(moveDirection);
            
            localTransform.ValueRW.Rotation = math.slerp(localTransform.ValueRO.Rotation,quaternion.LookRotation(moveDirection, math.up()), SystemAPI.Time.DeltaTime * unitMover.ValueRO.rotationSpeed);
            
            physicsVelocity.ValueRW.Linear = moveDirection * unitMover.ValueRO.moveSpeed;
            physicsVelocity.ValueRW.Angular = float3.zero;
            
            //localTransform.ValueRW.Position += moveDirection * moveSpeed.ValueRO.moveSpeed * SystemAPI.Time.DeltaTime;
        }
    }
}