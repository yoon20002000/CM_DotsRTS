using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class RandomWalkingAuthoring : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 originPosition;
    public float distanceMin;
    public float distanceMax;
    public uint randomSeed;
    private class Baker : Baker<RandomWalkingAuthoring>
    {
        public override void Bake(RandomWalkingAuthoring authoring)
        {
            Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
            AddComponent(entity, new RandomWalking
            {
                targetPosition = authoring.transform.position,
                originPosition = authoring.transform.position, 
                distanceMin = authoring.distanceMin,
                distanceMax = authoring.distanceMax,
                random = new Random(authoring.randomSeed),
            });
        }
    }
}

public struct RandomWalking : IComponentData
{
    public float3 targetPosition;
    public float3 originPosition;
    public float distanceMin;
    public float distanceMax;
    public Random random;
}