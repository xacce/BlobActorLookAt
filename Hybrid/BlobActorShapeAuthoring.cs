#if UNITY_EDITOR
using Unity.Entities;
using UnityEngine;
using Xacce.BlobActor.LookAt.Runtime;

namespace Xacce.BlobActor.LookAt.Hybrid
{
    public class BlobActorLookAtAuthoring : MonoBehaviour
    {
        class BlobActorShapeBaker : Baker<BlobActorLookAtAuthoring>
        {
            public override void Bake(BlobActorLookAtAuthoring authoring)
            {
                var e = GetEntity(authoring, TransformUsageFlags.WorldSpace);
                AddComponent(e, new BlobActorLookAt()
                {
                });
            }
        }
    }
}
#endif