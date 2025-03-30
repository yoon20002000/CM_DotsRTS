using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

partial struct RandomWalkingSystem : ISystem
{

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach ((RefRW<LocalTransform> localTransform, RefRW<RandomWalking> randomWalking, RefRW<UnitMover> unitMover) in SystemAPI.Query<RefRW<LocalTransform>,RefRW<RandomWalking>, RefRW<UnitMover>>())
        {
            // Target에 도착
            if (math.distancesq(localTransform.ValueRO.Position, randomWalking.ValueRO.targetPosition) <
                UnitMoverSystem.REACHED_TARGET_POSITION_DISTANCE_SQ)
            {
                Random random = randomWalking.ValueRO.random;
                float3 randomDirection = new float3(random.NextFloat(-1, 1), 0, random.NextFloat(-1, 1));
                randomDirection = math.normalize(randomDirection);

                randomWalking.ValueRW.targetPosition = randomWalking.ValueRO.originPosition + randomDirection * random.NextFloat(randomWalking.ValueRO.distanceMin, randomWalking.ValueRO.distanceMax);
                randomWalking.ValueRW.random = random;
                UnityEngine.Debug.Log(randomWalking.ValueRO.targetPosition);
            }
            else
            {
                unitMover.ValueRW.targetPosition = randomWalking.ValueRO.targetPosition;
            }
        }
    }
}
