using System;

namespace Network
{   
    [Serializable]
    public struct Vector3String
    {
        public Vector3String(string x, string y, string z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public string x;
        public string y;
        public string z;
    }
}