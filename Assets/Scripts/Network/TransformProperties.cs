using System;
using UnityEngine;

namespace Network
{
    public struct TransformProperties
    {
        public TransformProperties(Vector3 position, Quaternion rotation)
        {
            Position = new Vector3String(((float)Math.Round(position.x, 3)).ToString(),
                ((float)Math.Round(position.y, 3)).ToString(),
                ((float)Math.Round(position.z, 3)).ToString());
            
            Rotation = new QuaternionString(((float)Math.Round(rotation.x, 3)).ToString(), ((float)Math.Round(rotation.y, 3)).ToString(),
                ((float)Math.Round(rotation.z, 3)).ToString(),((float)Math.Round(rotation.w, 3)).ToString());
            Id = 0;
        }

        public Vector3String Position;
        public QuaternionString Rotation;
        public int Id;
    }
}