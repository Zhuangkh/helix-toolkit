#if COREWPF
using HelixToolkit.Vortice.Core.Model.Scene2D;
#endif
namespace HelixToolkit.Wpf.Vortice
{
#if !COREWPF
    using Model.Scene2D;
#endif
    namespace Elements2D
    {
        public class RectangleModel2D : ShapeModel2D
        {
            protected override SceneNode2D OnCreateSceneNode()
            {
                return new RectangleNode2D();
            }
        }
    }
}
