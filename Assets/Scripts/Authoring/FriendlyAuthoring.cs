using Unity.Entities;
using UnityEngine;

public class FriendlyAuthoring : MonoBehaviour
{

    private class FriendlyBaker : Baker<FriendlyAuthoring>
    {
        public override void Bake(FriendlyAuthoring authoring)
        {
            Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
            AddComponent(entity, new Friendly
            {
            });
        }
    }
}

public struct Friendly : IComponentData
{
    
}