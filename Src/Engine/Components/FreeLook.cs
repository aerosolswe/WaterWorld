using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using WaterWorld.Input;

namespace WaterWorld.Engine {
    class FreeLook : GameComponent {

        /** Max and minimum angle you can look around */
        private static float MAX_LOOK_ANGLE = 89.99f;
        private static float MIN_LOOK_ANGLE = -89.99f;

        public float upAngle = 0;

        /** Mouse locked to screen */
        private bool mouseLocked = false;

        /** Sensitivity for the mouse */
        private float sensitivity;

        private Mapping unlockMapping;

        public FreeLook(float sensitivity) {
            this.sensitivity = sensitivity;

            CoreEngine.input.AddButtonMap("UnlockMouse", MouseButton.Middle);
            unlockMapping = CoreEngine.input.Mapping("UnlockMouse");
        }

        public override void Input() {
            base.Input();
            Vector2 center = new Vector2(CoreEngine.window.Bounds.Left + (CoreEngine.window.Bounds.Width / 2), CoreEngine.window.Bounds.Top + (CoreEngine.window.Bounds.Height / 2));

            if(unlockMapping.Up && mouseLocked) {
                //CoreEngine.window.CursorVisible = true;
                mouseLocked = false;
            } else if(unlockMapping.Up) {
                //CoreEngine.window.CursorVisible = false;
                mouseLocked = true;
            }

            if(mouseLocked) {
                Vector2 mousePos = new Vector2(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);
                Vector2 deltaPos = center - mousePos;

                bool rotY = deltaPos.X != 0;
                bool rotX = deltaPos.Y != 0;

                Vector3 right = Vector3.Transform(new Vector3(1, 0, 0), Transform.Transformation()).Normalized();

                if(rotY)
                    Transform.Rotate(new Vector3(0, 1, 0), (float)MathHelper.DegreesToRadians(-deltaPos.X * sensitivity));
                if(rotX)
                    Transform.Rotate(new Vector3(1, 0, 0), (float)MathHelper.DegreesToRadians(-deltaPos.Y * sensitivity));

                if(rotY || rotX)
                    System.Windows.Forms.Cursor.Position = new Point((int)center.X, (int)center.Y);
            }

        }
    }
}
