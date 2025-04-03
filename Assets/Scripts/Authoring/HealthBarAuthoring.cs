using Unity.Entities;
using UnityEngine;

public class HealthBarAuthoring : MonoBehaviour
{
    public GameObject barVisualGameObject;
    public GameObject healthGameObject;
    private class Baker : Baker<HealthBarAuthoring>
    {
        public override void Bake(HealthBarAuthoring authoring)
        {
            Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
            AddComponent(entity, new HealthBar
            {
                barVisualEntity = GetEntity(authoring.barVisualGameObject, TransformUsageFlags.NonUniformScale),
                healthEntity = GetEntity(authoring.healthGameObject, TransformUsageFlags.Dynamic),
            });
        }
    }
}

public struct HealthBar : IComponentData
{
    public Entity barVisualEntity;
    public Entity healthEntity;
}