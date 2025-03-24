using Unity.Entities;
using UnityEngine;

public class BulletAuthoring : MonoBehaviour
{
    public float speed;
    public int damageAmount;
    private class Baker : Baker<BulletAuthoring>
    {
        public override void Bake(BulletAuthoring authoring)
        {
            Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
            AddComponent(entity, new Bullet
            {
                speed = authoring.speed,
                damageAmount = authoring.damageAmount,
            });
        }
    }
}

public struct Bullet : IComponentData
{
    public float speed;
    public int damageAmount;
    

}
    
