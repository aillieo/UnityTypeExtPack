using UnityEngine;

namespace AillieoUtils.UnityTypeExt
{

    public static class Vector3Ext
    {

        public static Vector3 SetX(this Vector3 v3, float x)
        {
            return new Vector3(x, v3.y, v3.z);
        }

        public static Vector3 SetY(this Vector3 v3, float y)
        {
            return new Vector3(v3.x, y, v3.z);
        }

        public static Vector3 SetZ(this Vector3 v3, float z)
        {
            return new Vector3(v3.x, v3.y, z);
        }
    }
}
