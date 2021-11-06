using System;
using System.Collections.Generic;

namespace Escenario
{
    public class Scene
    {
        private Dictionary<string, Object3D> listOfObject3Ds;
        public Vertex Center;

        public Scene(Dictionary<string, Object3D> ListOfObject3Ds, Vertex center)
        {
            listOfObject3Ds = ListOfObject3Ds;
            Center = center;
            SetCenter(Center);
        }

        public void SetCenter(Vertex center)
        {
            Center = center;
            foreach (var object3D in listOfObject3Ds)
            {
                Vertex formerCenter = object3D.Value.GetCenter();
                object3D.Value.SetCenter(Center + formerCenter);
            }
        }

        public Vertex GetCenter()
        {
            return Center;
        }

        public Dictionary<string,Object3D> GetObjects()
        {
            return listOfObject3Ds;
        }

        public Object3D GetObject3D(string key)
        {
            return listOfObject3Ds[key];
        }
        public void Draw(int TextureType)
        {
            foreach (var object3D in listOfObject3Ds)
                object3D.Value.Draw(TextureType);
        }

        public void rotate(float angleX, float angleY, float angleZ)
        {
            foreach (var object3D in listOfObject3Ds)
            {
                object3D.Value.rotate(angleX, angleY, angleZ);
            }
        }
    }
}