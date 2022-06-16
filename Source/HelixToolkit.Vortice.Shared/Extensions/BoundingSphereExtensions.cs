/*
The MIT License (MIT)
Copyright (c) 2018 Helix Toolkit contributors
*/
using global::Vortice;
using System;
using System.Collections.Generic;
using System.Numerics;
using Matrix = System.Numerics.Matrix4x4;
#if !NETFX_CORE
namespace HelixToolkit.Wpf.Vortice
#else
#if CORE
namespace HelixToolkit.Vortice.Core
#else
namespace HelixToolkit.UWP
#endif
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public static class BoundingSphereExtensions
    {
        /// <summary>
        /// Froms the points.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="start">The start.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public static global::Vortice.Mathematics.BoundingSphere FromPoints(IList<Vector3> points, int start, int count)
        {
            if (points == null || start < 0 || start >= points.Count || count < 0 || (start + count) > points.Count)
            {
                return new global::Vortice.Mathematics.BoundingSphere();
            }

            var upperEnd = start + count;

            //Find the center of all points.
            var center = Vector3.Zero;
            for (var i = start; i < upperEnd; ++i)
            {
                var p = points[i];
                center = Vector3.Add(p, center);
            }

            //This is the center of our sphere.
            center /= (float)count;

            //Find the radius of the sphere
            var radius = 0f;
            for (var i = start; i < upperEnd; ++i)
            {
                //We are doing a relative distance comparison to find the maximum distance
                //from the center of our sphere.
                var p = points[i];
                var distance = Vector3.DistanceSquared(center, p);

                if (distance > radius)
                    radius = distance;
            }

            //Find the real distance from the DistanceSquared.
            radius = (float)Math.Sqrt(radius);

            //Construct the sphere.
            return new global::Vortice.Mathematics.BoundingSphere(center, radius);
        }

        /// <summary>
        /// Froms the points.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <returns></returns>
        public static global::Vortice.Mathematics.BoundingSphere FromPoints(IList<Vector3> points)
        {
            if (points == null)
            {
                return new global::Vortice.Mathematics.BoundingSphere();
            }

            return FromPoints(points, 0, points.Count);
        }

        /// <summary>
        /// Transforms the bounding sphere.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="m">The m.</param>
        /// <returns></returns>
        public static global::Vortice.Mathematics.BoundingSphere TransformBoundingSphere(this global::Vortice.Mathematics.BoundingSphere b, Matrix m)
        {
            var center = b.Center;
            var edge = b.Center + Vector3.UnitX * b.Radius;

            var worldCenter = Vector3.Transform(center, m);
            var worldEdge = Vector3.Transform(edge, m);

            return new global::Vortice.Mathematics.BoundingSphere(worldCenter, (worldEdge - worldCenter).Length());
        }
    }
}
