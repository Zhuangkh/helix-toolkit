/*
The MIT License (MIT)
Copyright (c) 2018 Helix Toolkit contributors
*/
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
    namespace Cameras
    {
        using System.Numerics;
        using System.Runtime.InteropServices;

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct FrustumCameraParams
        {
            //
            // 摘要:
            //     Position of the camera.
            public Vector3 Position;

            //
            // 摘要:
            //     Looking at direction of the camera.
            public Vector3 LookAtDir;

            //
            // 摘要:
            //     Up direction.
            public Vector3 UpDir;

            //
            // 摘要:
            //     Field of view.
            public float FOV;

            //
            // 摘要:
            //     Z near distance.
            public float ZNear;

            //
            // 摘要:
            //     Z far distance.
            public float ZFar;

            //
            // 摘要:
            //     Aspect ratio.
            public float AspectRatio;
        }
    }
}
