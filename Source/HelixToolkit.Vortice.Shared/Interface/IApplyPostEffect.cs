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
    public interface IApplyPostEffect
    {
        string PostEffects
        {
            set; get;
        }
    }
}
