using Unity.Entities;
using UnityEngine;

public class FindTargetAuthoring : MonoBehaviour
{
    public float findTargetRange;
    public Faction targetFaction;
    public float timerMax;
    private class Baker : Baker<FindTargetAuthoring>
    {
        public override void Bake(FindTargetAuthoring authoring)
        {
            Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
            AddComponent(entity, new FindTarget
            {
                findTargetRange = authoring.findTargetRange,
                targetFaction = authoring.targetFaction,    
                timerMax = authoring.timerMax,
            });
        }
    }
}

public struct FindTarget : IComponentData
{
    public float findTargetRange;
    public Faction targetFaction;
    public float timer;
    public float timerMax;
}
 