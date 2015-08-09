using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace WaterWorld.Engine {
    class MathUtil {

        public static Quaternion CreateFromEuler(Vector3 euler) {
            Quaternion quat = Quaternion.Identity;

            float c1 = (float)Math.Cos(euler.X / 2);
            float s1 = (float)Math.Sin(euler.X / 2);
            float c2 = (float)Math.Cos(euler.Y / 2);
            float s2 = (float)Math.Sin(euler.Y / 2);
            float c3 = (float)Math.Cos(euler.Z / 2);
            float s3 = (float)Math.Sin(euler.Z / 2);
            float c1c2 = c1 * c2;
            float s1s2 = s1 * s2;
            quat.W = c1c2 * c3 - s1s2 * s3;
            quat.X = c1c2 * s3 + s1s2 * c3;
            quat.Y = s1 * c2 * c3 + c1 * s2 * s3;
            quat.Z = c1 * s2 * c3 - s1 * c2 * s3;

            return quat;
        }

        public static Vector3 EulerFromQuaternion(Quaternion quat) {
            Vector3 euler = Vector3.Zero;

            float sqw = quat.W * quat.W;
            float sqx = quat.X * quat.X;
            float sqy = quat.Y * quat.Y;
            float sqz = quat.Z * quat.Z;
            float unit = sqx + sqy + sqz + sqw; // if normalised is one, otherwise is correction factor
            float test = quat.X * quat.Y + quat.Z * quat.W;
            if(test > 0.499 * unit) { // singularity at north pole
                euler.X = 2 * (float)Math.Atan2(quat.X, quat.W);
                euler.Y = (float)Math.PI / 2;
                euler.Z = 0;
                return euler;
            }
            if(test < -0.499 * unit) { // singularity at south pole
                euler.X = -2 * (float)Math.Atan2(quat.X, quat.W);
                euler.Y = (float)-Math.PI / 2;
                euler.Z = 0;
                return euler;
            }

            euler.X = (float)Math.Atan2(2 * quat.Y * quat.W - 2 * quat.X * quat.Z, sqx - sqy - sqz + sqw);
            euler.Y = (float)Math.Asin(2 * test / unit);
            euler.Z = (float)Math.Atan2(2 * quat.X * quat.W - 2 * quat.Y * quat.Z, -sqx + sqy - sqz + sqw);

            return euler;
        }

        public static Quaternion CreateFromMatrix(ref Matrix4 m) {
            Quaternion q;

            float trace = 1 + m.M11 + m.M22 + m.M33;
            float S = 0;
            float X = 0;
            float Y = 0;
            float Z = 0;
            float W = 0;

            if(trace > 0.0000001) {
                S = (float)Math.Sqrt(trace) * 2;
                X = (m.M23 - m.M32) / S;
                Y = (m.M31 - m.M13) / S;
                Z = (m.M12 - m.M21) / S;
                W = 0.25f * S;
            } else {
                if(m.M11 > m.M22 && m.M11 > m.M33) {
                    // Column 0: 
                    S = (float)Math.Sqrt(1.0 + m.M11 - m.M22 - m.M33) * 2;
                    X = 0.25f * S;
                    Y = (m.M12 + m.M21) / S;
                    Z = (m.M31 + m.M13) / S;
                    W = (m.M23 - m.M32) / S;
                } else if(m.M22 > m.M33) {
                    // Column 1: 
                    S = (float)Math.Sqrt(1.0 + m.M22 - m.M11 - m.M33) * 2;
                    X = (m.M12 + m.M21) / S;
                    Y = 0.25f * S;
                    Z = (m.M23 + m.M32) / S;
                    W = (m.M31 - m.M13) / S;
                } else {
                    // Column 2:
                    S = (float)Math.Sqrt(1.0 + m.M33 - m.M11 - m.M22) * 2;
                    X = (m.M31 + m.M13) / S;
                    Y = (m.M23 + m.M32) / S;
                    Z = 0.25f * S;
                    W = (m.M12 - m.M21) / S;
                }
            }
            q = new Quaternion(X, Y, Z, W);
            return q;
        }
    }
}
