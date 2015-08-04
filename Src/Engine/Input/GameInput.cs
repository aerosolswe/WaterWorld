using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;

namespace WaterWorld.Input {
    class GameInput {

        Dictionary<int, Mapping> mappings = new Dictionary<int, Mapping>();

        private int mouseX;
        private int mouseY;
        private int deltaX;
        private int deltaY;

        public void KeyDown(object sender, KeyboardKeyEventArgs e) {
            foreach(KeyValuePair<int, Mapping> entry in mappings) {
                Mapping mapping = entry.Value;

                foreach(Key key in mapping.Keys) {
                    if(key == e.Key) {
                        mapping.Down = true;
                        mapping.Repeated = e.IsRepeat;
                    }
                }
            }
        }

        // For text input
        public void KeyPress(object sender, KeyPressEventArgs e) {
        }

        public void KeyUp(object sender, KeyboardKeyEventArgs e) {
            foreach(KeyValuePair<int, Mapping> entry in mappings) {
                Mapping mapping = entry.Value;

                foreach(Key key in mapping.Keys) {
                    if(key == e.Key) {
                        mapping.Up = true;
                        mapping.Repeated = e.IsRepeat;
                    }
                }
            }
        }

        public void MouseDown(object sender, MouseButtonEventArgs e) {
            foreach(KeyValuePair<int, Mapping> entry in mappings) {
                Mapping mapping = entry.Value;

                foreach(MouseButton button in mapping.Buttons) {
                    if(button == e.Button) {
                        mapping.Down = true;
                    }
                }
            }
        }

        public void MouseUp(object sender, MouseButtonEventArgs e) {
            foreach(KeyValuePair<int, Mapping> entry in mappings) {
                Mapping mapping = entry.Value;

                foreach(MouseButton button in mapping.Buttons) {
                    if(button == e.Button) {
                        mapping.Up = true;
                    }
                }
            }
        }

        public void MouseMoved(object sender, MouseMoveEventArgs e) {
            mouseX = e.X;
            mouseY = e.Y;
            deltaX = e.XDelta;
            deltaY = e.YDelta;
        }

        public void Update() {
            foreach(KeyValuePair<int, Mapping> entry in mappings) {
                Mapping mapping = entry.Value;
                mapping.Up = false;
                mapping.Down = false;
                mapping.MWheelDown = false;
                mapping.MWheelUp = false;
            }
        }

        public void AddKeyMap(string name, Key key) {
            Mapping mapping = null;

            foreach(KeyValuePair<int, Mapping> entry in mappings) {
                mapping = entry.Value;

                if(mapping.Name.Equals(name)) {
                    mapping.AddKey(key);
                } else {
                    mapping = null;
                }

            }

            if(mapping == null) {
                mapping = new Mapping(name, key);
                mappings.Add((int)key, mapping);
            }
        }

        public void AddButtonMap(string name, MouseButton button) {
            Mapping mapping = null;

            foreach(KeyValuePair<int, Mapping> entry in mappings) {
                mapping = entry.Value;

                if(mapping.Name.Equals(name)) {
                    mapping.AddButton(button);
                } else {
                    mapping = null;
                }

            }

            if(mapping == null) {
                mapping = new Mapping(name, button);
                mappings.Add((int)button, mapping);
            }
        }

        public Mapping Mapping(string name) {
            foreach(KeyValuePair<int, Mapping> entry in mappings) {
                Mapping mapping = entry.Value;

                if(mapping.Name.Equals(name)) {
                    return mapping;
                }
            }

            Console.WriteLine("Error: Couldnt find input mapping with name: " + name);
            return new Mapping("Error");
        }

        public int MouseX {
            get { return mouseX; }
            set { mouseX = value; }
        }

        public int MouseY {
            get { return mouseY; }
            set { mouseY = value; }
        }

        public int DeltaX {
            get { return deltaX; }
            set { deltaX = value; }
        }

        public int DeltaY {
            get { return deltaY; }
            set { deltaY = value; }
        }

        public Vector2 MousePosition {
            get { return new Vector2(MouseX, MouseY); }
        }
    }


}
