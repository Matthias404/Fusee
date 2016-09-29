﻿using System.Collections.Generic;
using System.Linq;

namespace Fusee.Math.Core
{
    /// <summary>
    /// Represents a curve, using a list of CurveParts.
    /// </summary>
    public class Curve
    {
        /// <summary>
        /// The parts making up the Curve.
        /// </summary>
        public IList<CurvePart> CurveParts;

        /// <summary>
        /// Combines two Curves by creating a new one.
        /// </summary>
        /// <param name="a">The first curve to combine</param>
        /// <param name="b">The second curve to combine</param>
        /// <returns></returns>
        public static Curve CombineCurve(Curve a, Curve b)
        {
            //Concat returns a new list, without modifying the original
            var combinedCurve = new Curve { CurveParts = (IList<CurvePart>)a.CurveParts.Concat(b.CurveParts) };
            return combinedCurve;
        }

        /// <summary>
        /// Combines a list of Curves by creating a new Curve out of the list.
        /// </summary>
        /// <param name="curves">The curves to combine</param>
        /// <returns></returns>
        public static Curve CombineCurve(IEnumerable<Curve> curves)
        {
            var combinedCurve = new Curve {CurveParts = new List<CurvePart>()};
            foreach (var curve in curves)
            {
                foreach (var part in curve.CurveParts)
                {
                    combinedCurve.CurveParts.Add(part);
                }
            }
            return combinedCurve;
        }
    }


    /// <summary>
    /// Represents a open or closed part of a curve, using a list of CurveSegments and its starting point.
    /// </summary>
    public class CurvePart
    {
        /// <summary>
        /// A CurvePart can be closed or open.
        /// </summary>
        public bool Closed;
        /// <summary>
        /// This is the starting point of the CurvePart.
        /// </summary>
        public float3 StartPoint;
        /// <summary>
        /// The segments making up the CurveParts.
        /// </summary>
        public IList<CurveSegment> CurveSegments;
    }

    /// <summary>
    /// The base class for CurveSegments.
    /// Represents a segment of a CurvePart, using a list of float3.
    /// </summary>
    public class CurveSegment
    {
        /// <summary>
        /// The Vertices, representet as float3, of a CurveSegment.
        /// </summary>
        public IList<float3> Vertices;
        
        public virtual IEnumerator<IList<float3>> CalculateOutline()
        {
            return null;
        }
    }

    /// <summary>
    /// Represents a linear segment of a CurvePart, using a list of float3.
    /// </summary>
    public class LinearSegment : CurveSegment
    {
        public override IEnumerator<IList<float3>> CalculateOutline()
        {
            return base.CalculateOutline();
        }
    }

    /// <summary>
    /// Represents a cubic segment of a CurvePart, using a list of float3.
    /// </summary>
    public class BezierCubicSegment : CurveSegment
    {
        public override IEnumerator<IList<float3>> CalculateOutline()
        {
            return base.CalculateOutline();
        }
    }

    /// <summary>
    /// Represents a conic segment of a CurvePart, using a list of float3.
    /// </summary>
    public class BezierConicSegment : CurveSegment
    {
        public override IEnumerator<IList<float3>> CalculateOutline()
        {
            return base.CalculateOutline();
        }
    }
}