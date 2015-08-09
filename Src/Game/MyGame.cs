using OpenTK;
using OpenTK.Input;
using WaterWorld.Engine;
using WaterWorld.Input;
using System;

namespace WaterWorld.Game {
    class MyGame : GameScreen {
        Mapping quitMap;

        GameObject cameraObject;
        GameObject duckObject;

        public override void Awake() {
            base.Awake();

            CoreEngine.input.AddKeyMap("Quit", Key.Escape);
            quitMap = CoreEngine.input.Mapping("Quit");

            MeshRenderer mr = new MeshRenderer(ModelLoader.LoadModel("Content/Models/duck.dae"), new Material(TextureLoader.LoadTexture("Content/Models/duckCM.bmp")));

            duckObject = new GameObject();
            duckObject.AddComponent(new MeshRenderer(ModelLoader.LoadModel("Content/Models/duck.dae"), new Material(TextureLoader.LoadTexture("Content/Models/duckCM.bmp"))));
            duckObject.Transform.Scale = new Vector3(0.015f);
            duckObject.Transform.Position = new Vector3(0, 0, 0);

            Root.AddChild(duckObject);

            cameraObject = new GameObject();
            cameraObject.AddComponent(new Camera(Matrix4.CreatePerspectiveFieldOfView((float)MathHelper.DegreesToRadians(90), (float)CoreEngine.Width / (float)CoreEngine.Height, 0.3f, 1000f)));
            cameraObject.AddComponent(new FreeMove(10));
            cameraObject.AddComponent(new FreeLook(1));
            Root.AddChild(cameraObject);
            cameraObject.Transform.Position = new Vector3(0, 0, -15);

        }

        public override void Input() {
            base.Input();

            if(quitMap.Up) {
                CoreEngine.Exit();
            }

        }


        float temp = 0.0f;
        public override void Update() {
            base.Update();
            //cameraObject.Transform.LookAt(new Vector3(0, 0, 0));

            //duckObject.Transform.LookAt(cameraObject.Transform.Position);
            temp += Time.DeltaTime * 8;
            float distance = 10;
            //cameraObject.Transform.LookAt(new Vector3((float)(Math.Sin(temp * (Math.PI / 180)) * distance), distance / 3, (float)(Math.Cos(temp * (Math.PI / 180)) * distance)), new Vector3(0, 0, 0));
        }

    }
}
