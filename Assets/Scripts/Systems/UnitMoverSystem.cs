using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

partial struct UnitMoverSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach ( (RefRW<LocalTransform> localTransform, RefRO<MoveSpeed> moveSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<MoveSpeed>>())
        {
            localTransform.ValueRW.Position += new float3(moveSpeed.ValueRO.moveSpeed, 0, 0) * SystemAPI.Time.DeltaTime;
        }
    }
}
