using Unity.Entities;
using UnityEngine;

public class ShootAttackAuthoring : MonoBehaviour
{
    public float timerMax;
    private class Baker : Baker<ShootAttackAuthoring>
    {
        public override void Bake(ShootAttackAuthoring authoring)
        {
            Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
            AddComponent(entity, new ShootAttack
            {
                timerMax = authoring.timerMax,
            });
        }
    }
}

public struct ShootAttack : IComponentData
{
    public float timer;
    public float timerMax;
    
}