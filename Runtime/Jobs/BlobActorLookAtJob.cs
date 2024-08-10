using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Xacce.BlobActor.Runtime;

namespace Xacce.BlobActor.LookAt.Runtime.Jobs
{
    [BurstCompile]
    public partial struct BlobActorLookAtJob : IJobEntity
    {
        public float deltaTime;
        public float angleRadThreshold;

        [BurstCompile]
        public void Execute(in BlobActorLookAt lookAt, ref LocalTransform transform, ref BlobActorFlags flags, in BlobActor.Runtime.BlobActor act)
        {
            if ((flags.flags & BlobActorFlags.Flag.LookAt) == 0) return;

            transform.Rotation = math.nlerp(transform.Rotation, lookAt.lookat, deltaTime * act.blob.Value.rotationSpeed);
            if (math.angle(transform.Rotation, lookAt.lookat) <= angleRadThreshold)
            {
                flags.Unset(BlobActorFlags.Flag.LookAt);
                flags.Set(BlobActorFlags.Flag.Oriented);
            }
        }
    }
}