using System;
using System.Collections.Generic;
using System.Text;
using global::Vortice.Direct3D11;
using Device = Vortice.Direct3D11.ID3D11Device;
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
    namespace Shaders
    {
        public sealed class InputLayoutProxy : DisposeObject
        {
            private ID3D11InputLayout layout;
            public ID3D11InputLayout Layout => layout;

            public InputLayoutProxy(Device device, byte[] vertexShaderByteCode, InputElementDescription[] elements)
            {
                layout = device.CreateInputLayout(elements, vertexShaderByteCode);
            }

            protected override void OnDispose(bool disposeManagedResources)
            {
                RemoveAndDispose(ref layout);
                base.OnDispose(disposeManagedResources);
            }

            public static explicit operator ID3D11InputLayout(InputLayoutProxy proxy)
            {
                return proxy.layout;
            }
        }
    }
}
