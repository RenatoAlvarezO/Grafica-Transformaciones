using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Escenario
{
    public class Face
    {
        public Dictionary<string, Vertex> ListOfVertices { get; set; }
        public int FaceColor { get; set; }
        public Vertex Center { get; set; }


        public Face(Dictionary<string, Vertex> listOfVertices, int faceColor, Vertex center)
        {
            ListOfVertices = listOfVertices;
            FaceColor = faceColor;
            Center = center;
        }

        public void Draw(int TextureType)
        {
            Color drawingColor = Color.FromArgb(FaceColor);
            GL.Color4(drawingColor);
            GL.Begin((PrimitiveType) TextureType);
            foreach (var vertex in ListOfVertices)
            {
                GL.Vertex3(vertex.Value.X + Center.X, vertex.Value.Y + Center.Y, vertex.Value.Z + Center.Z);
            }

            GL.End();
            GL.Flush();
        }

  
        public void Rotate(float angleX, float angleY, float angleZ)
        {
            angleX = MathHelper.DegreesToRadians(angleX);
            foreach (var vertex in ListOfVertices)
                vertex.Value.Set(RotateX(vertex.Value, angleX));

            angleY = MathHelper.DegreesToRadians(angleY);
            foreach (var vertex in ListOfVertices)
                vertex.Value.Set(RotateY(vertex.Value, angleY));

            angleZ = MathHelper.DegreesToRadians(angleZ);
            foreach (var vertex in ListOfVertices)
                vertex.Value.Set(RotateZ(vertex.Value, angleZ));
        }

        private Vertex RotateX(Vertex vertexToRotate, float angle)
        {
            
            Matrix3 angledMatrix = Matrix3.CreateRotationY(angle);
            return vertexToRotate * angledMatrix;
        }

        private Vertex RotateY(Vertex vertexToRotate, float angle)
        {
            Matrix3 angledMatrix = Matrix3.CreateRotationY(angle);
            return vertexToRotate * angledMatrix;
        }

        private Vertex RotateZ(Vertex vertexToRotate, float angle)
        {
            Matrix3 angledMatrix = Matrix3.CreateRotationZ(angle);
            return vertexToRotate * angledMatrix;
        }
    }
}