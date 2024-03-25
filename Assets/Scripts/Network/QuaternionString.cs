using System;

namespace Network
{   
    [Serializable]
    public struct QuaternionString
    {   
        public QuaternionString(string x, string y, string z, string w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public string x;
        public string y;
        public string z;
        public string w;
    }
}