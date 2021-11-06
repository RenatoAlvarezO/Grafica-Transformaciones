using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Escenario
{
    public class Game : GameWindow
    {
        private int TextureType = 2;

        private Scene _scene;
        private Scene _scene2;
        private int angleCounter = 0;

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState inputKey = Keyboard.GetState();
            _scene.rotate(0f, 1f, 2f);

            if (inputKey.IsKeyDown(Key.Number0)) TextureType = 0;
            else if (inputKey.IsKeyDown(Key.Number1)) TextureType = 1;
            else if (inputKey.IsKeyDown(Key.Number2)) TextureType = 2;
            else if (inputKey.IsKeyDown(Key.Number3)) TextureType = 3;
            else if (inputKey.IsKeyDown(Key.Number4)) TextureType = 4;
            else if (inputKey.IsKeyDown(Key.Number5)) TextureType = 5;
            else if (inputKey.IsKeyDown(Key.Number6)) TextureType = 6;
            else if (inputKey.IsKeyDown(Key.Number7)) TextureType = 7;
            else if (inputKey.IsKeyDown(Key.Number8)) TextureType = 8;
            else if (inputKey.IsKeyDown(Key.Number9)) TextureType = 9;
            else if (inputKey.IsKeyDown(Key.Q)) TextureType = 10;
            else if (inputKey.IsKeyDown(Key.W)) TextureType = 11;
            else if (inputKey.IsKeyDown(Key.E)) TextureType = 12;
            else if (inputKey.IsKeyDown(Key.R)) TextureType = 13;
            else if (inputKey.IsKeyDown(Key.T)) TextureType = 14;
            else if (inputKey.IsKeyDown(Key.Y)) TextureType = 15;
            else if (inputKey.IsKeyDown(Key.U)) TextureType = 16;

            base.OnUpdateFrame(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            Color backgroundColor = Color.FromArgb(255, 65, 87, 63);
            GL.ClearColor(backgroundColor);

            // Object3D cube = ObjLoader.loadObj("../../../Casa.obj", new Vector3(0f, 0f, 0f));
            // Object3D roof = ObjLoader.loadObj("../../../Techo.obj", new Vector3(0f, 1.5f, 0f));
            // Object3D cone = ObjLoader.loadObj("../../../Cono.obj", new Vertex(2.5f, 0f, 0f));

            // JSONLoader.SaveFile("../../../object/Casa.json", cube);
            // JSONLoader.SaveFile("../../../object/Techo.json", roof);
            // JSONLoader.SaveFile("../../../object/Cono.json", cone);

            Object3D cube = JSONLoader.LoadFile("../../../object/Casa.json");
            Object3D roof = JSONLoader.LoadFile("../../../object/Techo.json");
            Object3D cone = JSONLoader.LoadFile("../../../object/Cono.json");

            Dictionary<string, Object3D> objects = new Dictionary<string, Object3D>();
            objects.Add("cubo", cube);
            objects.Add("techo", roof);
            objects.Add("cono", cone);

            _scene = new Scene(objects, new Vertex(0f, 0f, 0f));

            Dictionary<string, Object3D> objects2 = new Dictionary<string, Object3D>();
            objects2.Add("cubo", JSONLoader.LoadFile("../../../object/Casa.json"));
            objects2.Add("techo", JSONLoader.LoadFile("../../../object/Techo.json"));
            objects2.Add("cono", JSONLoader.LoadFile("../../../object/Cono.json"));

            _scene.rotate(0f, -45f, 0f);
            // _scene2 = new Scene(objects2, new Vertex(0f, 3f, 0f));
            int orthoSize = 5;
            GL.Ortho(-orthoSize, orthoSize, -orthoSize, orthoSize, -orthoSize, orthoSize);
            // GL.Rotate(10, 0.2f, 0.1f, 0.1f);
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);

            _scene.Draw(TextureType);

            // _scene2.Draw(TextureType);

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
    }
}