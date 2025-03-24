using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

partial struct HealthDeadTestSystem : ISystem
{

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        
        EntityCommandBuffer entityCommandBuffer = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);//new EntityCommandBuffer(Allocator.Temp);
        
        foreach ((RefRO<Health> health, Entity entity) in SystemAPI.Query<RefRO<Health>>().WithEntityAccess())
        {
            if (health.ValueRO.healthAmount <= 0)
            {
                // 여기서 바로 지우는게 아니라 특정 큐에 명령이 들어가서 해당 큐에 따라 진행 됨
                entityCommandBuffer.DestroyEntity(entity);
                
            }
        }

        // 현 위치에서 큐 진행
        //entityCommandBuffer.Playback(state.EntityManager);
    }
}
