using Unity.Entities;
using UnityEngine;

public struct MoveSpeed : IComponentData
{
    public float moveSpeed;
}

public class MoveSpeedAuthoring : MonoBehaviour
{
    public float moveSpeed;
    class Baker : Baker<MoveSpeedAuthoring>
    {
        public override void Bake(MoveSpeedAuthoring authoring)
        {
            Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);

            AddComponent(entity, new MoveSpeed { moveSpeed = authoring.moveSpeed });
        }
    }
}
