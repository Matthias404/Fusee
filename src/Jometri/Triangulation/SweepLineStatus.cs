﻿using Fusee.Jometri.DCEL;

namespace Fusee.Jometri.Triangulation
{
    internal class SweepLineStatus : BinarySearchTree<float, StatusEdge>
    {
        //Updates the nodes (key and value) according to the sweep lines intersection point with a certain status edge.
        internal void UpdateNodes(Vertex eventPoint)
        {
            foreach (var node in PreorderTraverseTreeNodes())
            {
                node.Value.SetKey(eventPoint);
                node.Key = node.Value.IntersectionPointX;
            }
        }

        //Finds StatusEdge according to its Handle using preorder traversal.
        internal StatusEdge FindStatusEdgeWithHandle(int handle)
        {
            foreach (var n in PreorderTraverseTreeValues())
            {
                if (n.HalfEdgeHandle == handle)
                    return n;
            }
            return null;
        }
    }
}
