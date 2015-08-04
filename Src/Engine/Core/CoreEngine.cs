using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using WaterWorld.Game;
using WaterWorld.Input;


namespace WaterWorld.Engine {
    class CoreEngine {

        public static int Width;
        public static int Height;

        public static GameWindow window;
        public static GameScreen game;
        public static GameInput input;
        public static GraphicsEngine graphicsEngine;

        public CoreEngine(int width, int height, int samples, GameScreen gameScreen) {
            Width = width;
            Height = height;

            game = gameScreen;
            input = new GameInput();
            graphicsEngine = new GraphicsEngine();

            window = new GameWindow(
                 width, height,
                 new GraphicsMode(32, 0, 0, samples),
                 "WaterWorld alpha v0.1",
                 0,
                 DisplayDevice.Default, 3, 2,
                 GraphicsContextFlags.ForwardCompatible | GraphicsContextFlags.Debug
             );
            window.VSync = VSyncMode.Off;

            SetupWindow();
        }

        void Start(object sender, EventArgs e) {
            GraphicsUtil.InitGL();
            graphicsEngine.Init();
            game.Awake();
        }

        void Update(object sender, FrameEventArgs e) {
            // Calculates fixed delta time
            Time.FixedDeltaTime = (float)e.Time;
            game.FixedUpdate();
        }

        double timer;

        void Render(object sender, FrameEventArgs e) {
            // Calculates delta time
            Time.DeltaTime = (float)e.Time;

            // Simple calc & print fps
            if(timer > 1) {
                Console.WriteLine("FPS: " + (1.0 / e.Time));
                timer = 0;
            } else {
                timer += e.Time;
            }

            game.Input();
            game.Update();
            input.Update();

            game.Render(graphicsEngine);

            window.SwapBuffers();
        }

        void Resize(object sender, EventArgs e) {
            Width = window.Width;
            Height = window.Height;

            game.Resize();
        }

        void Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            game.Dispose();
        }

        private void SetupWindow() {
            window.Load += Start;
            window.UpdateFrame += Update;
            window.RenderFrame += Render;
            window.Resize += Resize;
            window.Closing += Closing;

            window.KeyDown += input.KeyDown;
            window.KeyPress += input.KeyPress;
            window.KeyUp += input.KeyUp;
            window.MouseDown += input.MouseDown;
            window.MouseUp += input.MouseUp;
            window.MouseMove += input.MouseMoved;

            window.Run(60);
        }


        public static void Exit() {
            window.Exit();
        }

    }
}
