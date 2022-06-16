/*
The MIT License (MIT)
Copyright (c) 2018 Helix Toolkit contributors
*/
using Vortice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Vortice.Mathematics;
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
    public static class BoundingBoxExtensions
    {
        /// <summary>
        /// Froms the points.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <returns></returns>
        public static BoundingBox FromPoints(IList<Vector3> points)
        {
            if (points == null || points.Count == 0)
            {
                return new BoundingBox();
            }
            var min = new Vector3(float.MaxValue);
            var max = new Vector3(float.MinValue);

            foreach (var p in points)
            {
                var point = p;
                min = Vector3.Min(min, point);
                max = Vector3.Max(max, point);
            }
            var diff = max - min;
            if (diff.AnySmallerOrEqual(0.0001f)) // Avoid bound too small on one dimension.
            {
                return new BoundingBox(min - new Vector3(0.1f), max + new Vector3(0.1f));
            }
            else
            {
                return new BoundingBox(min, max);
            }
        }

        /// <summary>
        /// Transform AABB with Affine Transformation matrix
        /// </summary>
        /// <param name="box"></param>
        /// <param name="transform"></param>
        /// <returns></returns>
        public static BoundingBox Transform(this BoundingBox box, Matrix transform)
        {
            /////////////////Row 4/////////////////
            var min = transform.Translation;
            var max = transform.Translation;
            /////////////////Row 1/////////////////
            if (transform.M11 > 0f)
            {
                min.X += transform.M11 * box.Min.X;
                max.X += transform.M11 * box.Max.X;
            }
            else
            {
                min.X += transform.M11 * box.Max.X;
                max.X += transform.M11 * box.Min.X;
            }

            if (transform.M12 > 0f)
            {
                min.Y += transform.M12 * box.Min.X;
                max.Y += transform.M12 * box.Max.X;
            }
            else
            {
                min.Y += transform.M12 * box.Max.X;
                max.Y += transform.M12 * box.Min.X;
            }

            if (transform.M13 > 0f)
            {
                min.Z += transform.M13 * box.Min.X;
                max.Z += transform.M13 * box.Max.X;
            }
            else
            {
                min.Z += transform.M13 * box.Max.X;
                max.Z += transform.M13 * box.Min.X;
            }
            /////////////////Row 2/////////////////
            if (transform.M21 > 0f)
            {
                min.X += transform.M21 * box.Min.Y;
                max.X += transform.M21 * box.Max.Y;
            }
            else
            {
                min.X += transform.M21 * box.Max.Y;
                max.X += transform.M21 * box.Min.Y;
            }

            if (transform.M22 > 0f)
            {
                min.Y += transform.M22 * box.Min.Y;
                max.Y += transform.M22 * box.Max.Y;
            }
            else
            {
                min.Y += transform.M22 * box.Max.Y;
                max.Y += transform.M22 * box.Min.Y;
            }

            if (transform.M23 > 0f)
            {
                min.Z += transform.M23 * box.Min.Y;
                max.Z += transform.M23 * box.Max.Y;
            }
            else
            {
                min.Z += transform.M23 * box.Max.Y;
                max.Z += transform.M23 * box.Min.Y;
            }
            ///////////////Row 3///////////////////////
            if (transform.M31 > 0f)
            {
                min.X += transform.M31 * box.Min.Z;
                max.X += transform.M31 * box.Max.Z;
            }
            else
            {
                min.X += transform.M31 * box.Max.Z;
                max.X += transform.M31 * box.Min.Z;
            }

            if (transform.M32 > 0f)
            {
                min.Y += transform.M32 * box.Min.Z;
                max.Y += transform.M32 * box.Max.Z;
            }
            else
            {
                min.Y += transform.M32 * box.Max.Z;
                max.Y += transform.M32 * box.Min.Z;
            }

            if (transform.M33 > 0f)
            {
                min.Z += transform.M33 * box.Min.Z;
                max.Z += transform.M33 * box.Max.Z;
            }
            else
            {
                min.Z += transform.M33 * box.Max.Z;
                max.Z += transform.M33 * box.Min.Z;
            }

            return new BoundingBox(min, max);
        }

        public static RawRectF Translate(this RawRectF rect, Vector2 translation)
        {
            return new RawRectF(rect.Left + translation.X, rect.Top + translation.Y, rect.GetWidth(), rect.GetHeight());
        }

        public static Vector3 Center(this BoundingBox box)
        {
            return (box.Min + box.Max) * 0.5f;
        }
    }
}
