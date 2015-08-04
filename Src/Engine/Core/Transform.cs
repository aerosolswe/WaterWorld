using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace WaterWorld.Engine {
    class Transform {
        private Matrix4 model;

        public Transform() {
            model = Matrix4.Identity;
        }

        public Matrix4 Model {
            get { return model; }
            set { model = value; }
        }

        public void LookAt(Vector3 position, Vector3 point) {
            model = Matrix4.Mult(model, Matrix4.LookAt(new Vector3(position.X, position.Y, -position.Z), new Vector3(point.X, point.Y, point.Z), Vector3.UnitY));
        }

        public void RotateX(float amt) {
            model = Matrix4.Mult(model, Matrix4.CreateRotationX(amt));
        }

        public void RotateY(float amt) {
            model = Matrix4.Mult(model, Matrix4.CreateRotationY(amt));
        }

        public void RotateZ(float amt) {
            model = Matrix4.Mult(model, Matrix4.CreateRotationZ(amt));
        }

        public void RotateAxisAngle(Vector3 axis, float angle) {
            model = Matrix4.Mult(model, Matrix4.CreateFromAxisAngle(axis, angle));
        }

        public void Scale(float x, float y, float z) {
            Scale(new Vector3(x, y, z));
        }

        public void Scale(Vector3 scale) {
            model = Matrix4.Mult(model,
                             Matrix4.CreateScale(scale));
        }

        public void Translate(float x, float y, float z) {
            Translate(new Vector3(x, y, z));
        }

        public void Translate(Vector3 translation) {
            model = Matrix4.Mult(model,
                             Matrix4.CreateTranslation(new Vector3(-translation.X, -translation.Y, translation.Z)));
        }
    }
}
