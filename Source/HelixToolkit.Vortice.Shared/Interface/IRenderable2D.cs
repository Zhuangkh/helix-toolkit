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
    public interface IHitable2D
    {
        bool HitTest(Vector2 mousePoint, out HitTest2DResult hitResult);
        bool IsHitTestVisible
        {
            set; get;
        }
    }
}
