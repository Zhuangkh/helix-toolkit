using Vortice;
using System;
using System.Collections.Generic;
using System.Text;
using Media = System.Windows.Media;

namespace HelixToolkit.Wpf.Vortice
{
    namespace Elements2D
    {
        public interface ITransformable2D
        {
            Media.Transform Transform
            {
                set; get;
            }
        }

        public interface IBackground
        {
            Media.Brush Background
            {
                set; get;
            }
        }

        public interface ITextBlock : IBackground
        {
            Media.Brush Foreground
            {
                set; get;
            }
        }
    }
}
