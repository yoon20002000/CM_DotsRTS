using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
[UpdateInGroup(typeof(LateSimulationSystemGroup))]
[UpdateBefore(typeof(ResetEventSystem))]
partial struct SelectedVisualSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (RefRO<Selected> selected in SystemAPI.Query<RefRO<Selected>>().WithPresent<Selected>())
        {
            if (selected.ValueRO.onDeselected)
            {
                RefRW<LocalTransform> visualLocalTransform = SystemAPI.GetComponentRW<LocalTransform>(selected.ValueRO.visualEntity);
                visualLocalTransform.ValueRW.Scale = 0;    
            }
            
            if (selected.ValueRO.onSelected)
            {
                RefRW<LocalTransform> visualLocalTransform = SystemAPI.GetComponentRW<LocalTransform>(selected.ValueRO.visualEntity);
                visualLocalTransform.ValueRW.Scale = selected.ValueRO.showScale;
            }
        }
    }
}
