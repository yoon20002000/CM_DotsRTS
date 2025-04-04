using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

[UpdateInGroup(typeof(LateSimulationSystemGroup))]
partial struct ShootLightSpawnerSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        EntitiesReferences entitiesReferences = SystemAPI.GetSingleton<EntitiesReferences>();

        foreach ((RefRO<ShootAttack> shootAttack,  RefRO<LocalTransform> localTransform) in SystemAPI.Query<RefRO<ShootAttack>, RefRO<LocalTransform>>())
        {
            if (shootAttack.ValueRO.onShoot.isTriggered)
            {
                Entity shootLightEntity = state.EntityManager.Instantiate(entitiesReferences.shootLightPrefabEntity);
                SystemAPI.SetComponent(shootLightEntity, LocalTransform.FromPosition(localTransform.ValueRO.Position));    
            }
        }
    }
}
