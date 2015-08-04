using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterWorld.Engine;
using WaterWorld.Game;

namespace WaterWorld {
    class Program {
        static void Main(string[] args) {
            MyGame game = new MyGame();
            new CoreEngine(1280, 720, 4, game);
        }
    }
}
