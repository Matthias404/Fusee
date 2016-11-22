﻿using Fusee.Jometri.DCEL;
using Fusee.Math.Core;

namespace Fusee.Jometri.Extrusion
{
    /// <summary>
    /// Extrudes a trinagulated 2D geometry
    /// </summary>
    public static class ExtrudeTriangulated
    {
        //zOffset will be added to each vertex' z coordinate, if the front face is not parallel to the x-y plane we have to rotate it there first, extrude and rotate back
        /// <summary>
        /// Extrudes a trinagulated 2D geometry
        /// </summary>
        /// <param name="geometry">The geometry to be extruded.</param>
        /// <param name="zOffset">zOffset will be added to each vertex' z coordinate in order to create the back of the geometry </param>
        /// <returns></returns>
        public static Geometry ExtrudePolygon(this Geometry geometry, int zOffset)
        {
            CreateBackface(geometry, zOffset);
            //CreateSidefaces(geometry);

            return geometry;
        }

        private static void CreateBackface(Geometry geometry, int zOffset)
        {
            //Copy frontface
            var backface = new Geometry(geometry);

            //Add z value to each vertex coord
            foreach (var vHandle in backface.VertHandles)
            {
                var vert = backface.GetVertexByHandle(vHandle);
                var newCoord = new float3(vert.Coord.x, vert.Coord.y, vert.Coord.z + zOffset);
                backface.OverwriteVertexCoord(vert, newCoord);
            }

            geometry.JoinGeometries(backface);
        }


        private static void CreateSidefaces(Geometry geometry)
        {
            var vertCountFront = geometry.VertHandles.Count/2;

            for (var i = 1; i <= vertCountFront; i++)
            {
                var first = new VertHandle();
                var second = new VertHandle();
                var third = new VertHandle();

                foreach (var handle in geometry.VertHandles)
                {
                    if (handle.Id == i)
                        first = handle;
                    else if (handle.Id == i + vertCountFront)
                        second = handle;
                    else if (handle.Id == i + vertCountFront + 1)
                        third = handle;

                    if(first.Id != 0 && second.Id != 0 && third.Id != 0)
                        break;
                }
                
                //geometry.InsertFace(first,second);
                //geometry.InsertHalfEdge(first, third);
            }
        }
    }
}
