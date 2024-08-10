using Unity.Entities;
using Unity.Mathematics;

namespace Xacce.BlobActor.LookAt.Runtime
{
    public partial struct BlobActorLookAt : IComponentData
    {
        public quaternion lookat;
    }
}