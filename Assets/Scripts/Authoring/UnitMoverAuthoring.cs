﻿using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct UnitMover : IComponentData
{
    public float moveSpeed;
    public float rotationSpeed;
    public float3 targetPosition; 
}

public class UnitMoverAuthoring : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    class Baker : Baker<UnitMoverAuthoring>
    {
        public override void Bake(UnitMoverAuthoring authoring)
        {
            Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);

            AddComponent(entity, new UnitMover
            {
                moveSpeed = authoring.moveSpeed,
                rotationSpeed =  authoring.rotationSpeed,
            });
        }
    }
}
