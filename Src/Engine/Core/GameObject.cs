using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterWorld.Engine {
    class GameObject {
        private List<GameObject> children;
        private List<GameComponent> components;
        private Transform transform;

        public GameObject() {
            children = new List<GameObject>();
            components = new List<GameComponent>();
            transform = new Transform();
        }

        public void AddChild(GameObject child) {
            children.Add(child);
            child.AddToEngine();
        }

        public void AddComponent(GameComponent component) {
            component.Parent = this;
            components.Add(component);
        }

        public virtual void Input() {
            foreach(GameComponent component in components)
                component.Input();

            foreach(GameObject child in children)
                child.Input();
        }

        public virtual void FixedUpdate() {
            foreach(GameComponent component in components)
                component.FixedUpdate();

            foreach(GameObject child in children)
                child.FixedUpdate();
        }

        public virtual void Update() {
            foreach(GameComponent component in components)
                component.Update();

            foreach(GameObject child in children)
                child.Update();
        }

        public virtual void Render(Shader shader) {
            foreach(GameComponent component in components)
                component.Render(shader);

            foreach(GameObject child in children)
                child.Render(shader);
        }

        public virtual void Resize() {
            foreach(GameComponent component in components)
                component.Resize();

            foreach(GameObject child in children)
                child.Resize();
        }

        public virtual void Dispose() {
            foreach(GameComponent component in components)
                component.Dispose();

            foreach(GameObject child in children)
                child.Dispose();
        }

        public Transform Transform {
            get { return transform; }
        }

        public virtual void AddToEngine() {
            foreach(GameComponent component in components)
                component.AddToEngine();

            foreach(GameObject child in children)
                child.AddToEngine();
        }
    }
}
