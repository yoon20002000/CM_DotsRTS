using Unity.Entities;
using UnityEngine;

public class UnitAuthoring : MonoBehaviour
{
   public Faction faction;
   public class UnitBaker : Baker<UnitAuthoring>
   {
      public override void Bake(UnitAuthoring authoring)
      {
         Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
         AddComponent(entity, new Unit
         {
            faction = authoring.faction,
         });
      }
   }
}

public struct Unit : IComponentData
{
   public Faction faction;
}