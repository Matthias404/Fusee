﻿using System;
using System.Collections.Generic;
using System.Linq;
using Fusee.Engine.Core;
using Fusee.Math.Core;
using Geometry = Fusee.Jometri.DCEL.Geometry;

namespace Fusee.Engine.Examples.ThreeDFont.Core
{
    public class HalfEdgeListToMesh : Mesh
    {
        public HalfEdgeListToMesh(Geometry geometry)
        {
            float3[] vertices;
            ushort[] triangles;
            List<float3> normals;
                
            ConvertToMesh(geometry, out vertices, out triangles, out normals);

            Vertices = vertices;
            Triangles = triangles;
            Normals = normals.ToArray();
        }

        //geometry has to be trinagulated
        private static void ConvertToMesh(Geometry geometry, out float3[] vertices, out ushort[] triangles, out List<float3> normals)
        {
            var triangleCount = geometry.FaceHandles.Count -1; //TODO: Delete!! if geometry is extruded there schouldn't be a unbounded face anymore
            var vertCount = triangleCount * 3;

            var verts = new List<float3>();

            vertices = new float3[vertCount];
            triangles = new ushort[vertCount];
            normals = new List<float3>();

            for (var i = 0; i < geometry.FaceHandles.Count; i++)
            {
                var face = geometry.FaceHandles[i];

                //TODO: delete, if geometry is extruded there schouldn't be a unbounded face anymore
                //first  Face is always the unbounded one - If face has no OuterHalfEdge it's unbounded and can be ignored
                if (i == 0) continue;

                var faceVerts = geometry.GetFaceVertices(face).ToList();

                if (faceVerts.Count > 3)
                    throw new ArgumentException("Invalid Triangle - face has more than 3 Vertices");

                foreach (var vert in faceVerts)
                {
                    verts.Add(vert.Coord);
                }
            }

            for (var i = 0; i < vertices.Length; i++)
            {
                vertices[i] = verts[i];
                triangles[i] = (ushort)i;
            }

            for (var i = 0; i < vertices.Length; i+=3)
            {
                var a = vertices[i + 1] - vertices[i];
                var b = vertices[i + 2] - vertices[i];

                var cross = float3.Cross(b, a);
                cross.Normalize();

                for (var j = 0; j < 3; j++)
                {
                    normals.Add(cross);
                }
            }
        }
    }
}
