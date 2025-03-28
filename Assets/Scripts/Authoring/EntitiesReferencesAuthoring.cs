using Unity.Entities;
using UnityEngine;

public class EntitiesReferencesAuthoring : MonoBehaviour
{
   public GameObject bulletPrefabGameObject;
      
   private class Baker : Baker<EntitiesReferencesAuthoring>
   {
      public override void Bake(EntitiesReferencesAuthoring authoring)
      {
         Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
         AddComponent(entity, new EntitiesReferences
         {
            bulletPrefabEntity = GetEntity(authoring.bulletPrefabGameObject, TransformUsageFlags.Dynamic)
         });
      }
   }
   
}

public struct EntitiesReferences : IComponentData
{
   public Entity bulletPrefabEntity;
}
