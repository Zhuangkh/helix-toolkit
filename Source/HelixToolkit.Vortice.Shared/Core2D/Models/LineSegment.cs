/*
The MIT License (MIT)
Copyright (c) 2018 Helix Toolkit contributors
*/
using D2D = Vortice.Direct2D1;
using Vortice.DirectWrite;
using Vortice;
using System.Numerics;

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
    namespace Core2D
    {
        /// <summary>
        /// <see href="https://jeremiahmorrill.wordpress.com/2013/02/06/direct2d-gui-librarygraphucks/"/>
        /// </summary>
        public class LineSegment : Segment
        {
            public readonly Vector2 Point;
            public LineSegment(Vector2 point)
            {
                Point = point;
            }

            public override void Create(D2D.GeometrySink sink)
            {
                sink.AddLine(Point);
            }
        }
    }
}
