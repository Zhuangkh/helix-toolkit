/*
The MIT License (MIT)
Copyright (c) 2018 Helix Toolkit contributors
*/

using Vortice;

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
    namespace Model.Scene2D
    {
        using Core2D;

        public class RectangleNode2D : ShapeNode2D
        {
            protected override ShapeRenderCore2DBase CreateShapeRenderCore()
            {
                return new RectangleRenderCore2D();
            }

            protected override bool OnHitTest(ref Vector2 mousePoint, out HitTest2DResult hitResult)
            {
                hitResult = null;
                if (LayoutBoundWithTransform.Contains(mousePoint))
                {
                    hitResult = new HitTest2DResult(WrapperSource);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}