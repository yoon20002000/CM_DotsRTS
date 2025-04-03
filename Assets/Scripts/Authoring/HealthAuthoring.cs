using Unity.Entities;
using UnityEngine;

public class HealthAuthoring : MonoBehaviour
{
    public int healthAmount;
    public int healthAmountMax;
    private class Baker : Baker<HealthAuthoring>
    {
        public override void Bake(HealthAuthoring authoring)
        {
            Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
            AddComponent(entity, new Health
            {
                healthAmount = authoring.healthAmount,
                healthAmountMax = authoring.healthAmountMax,
                onHealthChanged = true,
            });
        }
    }
}

public struct Health : IComponentData
{
    public int healthAmount;
    public int healthAmountMax;

    public bool onHealthChanged;
}
