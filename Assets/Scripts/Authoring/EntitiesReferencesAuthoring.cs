using Unity.Entities;
using UnityEngine;

public class EntitiesReferencesAuthoring : MonoBehaviour
{
   public GameObject bulletPrefabGameObject;
   public GameObject ZombiePrefabGameObject;
   public GameObject ShootLightGameObject;
   private class Baker : Baker<EntitiesReferencesAuthoring>
   {
      public override void Bake(EntitiesReferencesAuthoring authoring)
      {
         Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
         AddComponent(entity, new EntitiesReferences
         {
            bulletPrefabEntity = GetEntity(authoring.bulletPrefabGameObject, TransformUsageFlags.Dynamic),
            zombiePrefabEntity = GetEntity(authoring.ZombiePrefabGameObject, TransformUsageFlags.Dynamic),
            shootLightPrefabEntity = GetEntity(authoring.ShootLightGameObject, TransformUsageFlags.Dynamic),
         });
      }
   }
   
}

public struct EntitiesReferences : IComponentData
{
   public Entity bulletPrefabEntity;
   public Entity zombiePrefabEntity;
   public Entity shootLightPrefabEntity;
}
