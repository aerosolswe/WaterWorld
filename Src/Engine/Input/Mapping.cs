using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using OpenTK;
using OpenTK.Input;

namespace WaterWorld.Input {
    class Mapping {
        private ArrayList keys = new ArrayList();
        private ArrayList buttons = new ArrayList();

        private string name;

        private bool down;
        private bool pressed;
        private bool up;
        private bool repeated;
        private bool mwheeldown;
        private bool mwheelup;

        public bool checkMouseWheelDown = false;
        public bool checkMouseWheelUp = false;

        public Mapping(string name) {
            this.name = name;
        }

        public Mapping(string name, Key value) {
            this.name = name;

            keys.Add(value);
        }

        public Mapping(string name, MouseButton value) {
            this.name = name;

            buttons.Add(value);
        }

        public string Name {
            get { return name; }
        }

        public void AddKey(Key key) {
            keys.Add(key);
        }

        public int Key(int i) {
            object key = keys[i];

            return (int)key;
        }

        public ArrayList Keys {
            get { return keys; }
        }

        public void AddButton(MouseButton button) {
            buttons.Add(button);
        }

        public int Button(int i) {
            object button = buttons[i];

            return (int)button;
        }

        public ArrayList Buttons {
            get { return buttons; }
        }

        public bool Pressed {
            get { return pressed; }
            set { pressed = value; }
        }

        public bool Down {
            get { return down; }
            set { down = value; }
        }

        public bool Up {
            get { return up; }
            set { up = value; }
        }

        public bool Repeated {
            get { return repeated; }
            set { repeated = value; }
        }

        public bool MWheelDown {
            get { return mwheeldown; }
            set { mwheeldown = value; }
        }

        public bool MWheelUp {
            get { return mwheelup; }
            set { mwheelup = value; }
        }
    }
}
