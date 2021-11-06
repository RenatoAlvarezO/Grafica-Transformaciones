using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using OpenTK;

namespace Escenario
{
    public class Object3D
    {
        public Dictionary<string, Face> ListOfFaces { get; set; }

        public Vertex Center { get; set; }

        public Object3D(Dictionary<string, Face> listOfFaces, Vertex center)
        {
            ListOfFaces = listOfFaces;
            Center = center;
            SetCenter(center);
        }

        public void SetCenter(Vertex newCenter)
        {
            Center = newCenter;
            foreach (var face in ListOfFaces)
                face.Value.Center = Center;
        }

        public Vertex GetCenter()
        {
            return Center;
        }

        public Face GetFace(string key)
        {
            return ListOfFaces[key];
        }
        
        public void Draw(int TextureType)
        {
            foreach (var face in ListOfFaces)
                face.Value.Draw(TextureType);
        }

        public Dictionary<string, Face> getListOfFaces()
        {
            return ListOfFaces;
        }

        public void rotate(float angleX, float angleY, float angleZ)
        {
            foreach (var face in ListOfFaces)
            {
                face.Value.Rotate(angleX, angleY, angleZ);
            }
        }
    }
}