using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace WaterWorld.Engine {
    class Transform {

        private Transform parent;
        private Matrix4 parentMatrix;

        private Vector3 position;
        private Quaternion rotation;
        private Vector3 scale;

        private Vector3 oldPosition;
        private Quaternion oldRotation;
        private Vector3 oldScale;

        public Transform() {
            position = Vector3.Zero;
            rotation = Quaternion.Identity;
            scale = Vector3.One;

            parentMatrix = Matrix4.Identity;
        }

        public Transform(Vector3 position, Quaternion rotation, Vector3 scale) {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;

            parentMatrix = Matrix4.Identity;
        }

        public void Update() {
            if(oldPosition != null) {
                oldPosition = position;
                oldRotation = rotation;
                oldScale = scale;
            } else {
                oldPosition = Vector3.Add(position, Vector3.One);
                oldRotation = rotation * 0.5f;
                oldScale = Vector3.Add(scale, Vector3.One);
            }
        }

        public void Rotate(Vector3 axis, float angle) {
            rotation = Quaternion.FromAxisAngle(axis, angle) * rotation;
        }

        public void Rotate(Quaternion rotationAmount) {
            rotation = rotationAmount * rotation;
        }

        public void Rotate(Vector3 euler) {
            rotation = MathUtil.CreateFromEuler(euler) * rotation;
        }

        public void LookAt(Vector3 point) {
            //rotation = Matrix4.LookAt(position, point, new Vector3(0, 1, 0));
        }
        
        public bool HasChanged() {
            if(parent != null && parent.HasChanged())
                return true;

            if(position != oldPosition)
                return true;

            if(rotation != oldRotation)
                return true;

            if(scale != oldScale)
                return true;

            return false;
        }

        public Matrix4 Transformation() {
            Matrix4 model = Matrix4.Identity;
            model *= Matrix4.CreateTranslation(new Vector3(-position.X, -position.Y, position.Z));
            model *= Matrix4.CreateFromQuaternion(rotation);
            model *= Matrix4.CreateScale(scale);

            return ParentMatrix() * model;
        }

        private Matrix4 ParentMatrix() {
            if(parent != null && parent.HasChanged())
                parentMatrix = parent.Transformation();

            return parentMatrix;
        }

        public void SetParent(Transform parent) {
            this.parent = parent;
        }

        public Vector3 TransformedPos() {
            return Vector3.Transform(position, parentMatrix);
        }

        public Quaternion TransformedRot() {
            Quaternion parentRotation = Quaternion.Identity;

            if(parent != null)
                parentRotation = parent.TransformedRot();

            return parentRotation * rotation;
        }

        public Vector3 Position {
            get { return  position; }
            set { position = value; }
        }

        public Quaternion Rotation {
            get { return  rotation; }
            set { rotation = value; }
        }

        public Vector3 Scale {
            get { return  scale; }
            set { scale = value; }
        }
        
        public Vector3 Forward {
            get { return Vector3.Transform(new Vector3(0, 0, 1), rotation); }
        }

        public Vector3 Right {
            get { return Vector3.Transform(new Vector3(1, 0, 0), rotation); }
        }

        public Vector3 Up {
            get { return Vector3.Transform(new Vector3(0, 1, 0), rotation); }
        }
    }
}
