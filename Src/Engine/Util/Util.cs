using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Assimp;

namespace WaterWorld.Engine {
    class Util {
        public static Vector3 ToVector3(Vector3D v) {
            return new Vector3(v.X, v.Y, v.Z);
        }

        public static Vector3[] ToVector3Array(Vector3D[] v) {
            Vector3[] result = new Vector3[v.Length];

            for(int i = 0; i < v.Length; i++) {
                result[i] = ToVector3(v[i]);
            }

            return result;
        }
    }
}
