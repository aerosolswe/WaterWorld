using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Input;
using OpenTK;
using WaterWorld.Input;

namespace WaterWorld.Engine {
    class FreeMove : GameComponent {

        private float speed;

        Mapping forwardMap;
        Mapping backwardMap;
        Mapping leftMap;
        Mapping rightMap;
        Mapping upMap;
        Mapping downMap;

        private bool moveForward;
        private bool moveBackward;
        private bool moveLeft;
        private bool moveRight;
        private bool moveUp;
        private bool moveDown;

        public FreeMove(float speed) {
            this.speed = speed;

            CoreEngine.input.AddKeyMap("forward", Key.W);
            CoreEngine.input.AddKeyMap("backward", Key.S);
            CoreEngine.input.AddKeyMap("left", Key.A);
            CoreEngine.input.AddKeyMap("right", Key.D);
            CoreEngine.input.AddKeyMap("up", Key.Space);
            CoreEngine.input.AddKeyMap("down", Key.LControl);
            forwardMap = CoreEngine.input.Mapping("forward");
            backwardMap = CoreEngine.input.Mapping("backward");
            leftMap = CoreEngine.input.Mapping("left");
            rightMap = CoreEngine.input.Mapping("right");
            upMap = CoreEngine.input.Mapping("up");
            downMap = CoreEngine.input.Mapping("down");

        }


        public override void Input() {
            base.Input();

            if(forwardMap.Down) {
                moveForward = true;
            }
            if(forwardMap.Up) {
                moveForward = false;
            }
            if(backwardMap.Down) {
                moveBackward = true;
            }
            if(backwardMap.Up) {
                moveBackward = false;
            }
            if(leftMap.Down) {
                moveLeft = true;
            }
            if(leftMap.Up) {
                moveLeft = false;
            }
            if(rightMap.Down) {
                moveRight = true;
            }
            if(rightMap.Up) {
                moveRight = false;
            }
            if(upMap.Down) {
                moveUp = true;
            }
            if(upMap.Up) {
                moveUp = false;
            }
            if(downMap.Down) {
                moveDown = true;
            }
            if(downMap.Up) {
                moveDown = false;
            }

            if(moveForward)
                Move(Transform.Forward, speed);
            if(moveBackward)
                Move(Transform.Forward, -speed);
            if(moveLeft)
                Move(Transform.Right, -speed);
            if(moveRight)
                Move(Transform.Right, speed);
            if(moveUp)
                Move(new Vector3(0, 1, 0), speed);
            if(moveDown)
                Move(new Vector3(0, 1, 0), -speed);

            Console.WriteLine(Transform.Position);
        }

        private void Move(Vector3 dir, float amt) {
            Transform.Position = Vector3.Add(Transform.Position, dir * (amt * Time.DeltaTime));
        }

    }
}
