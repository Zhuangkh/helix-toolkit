// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Light3DCollection.cs" company="Helix Toolkit">
//   Copyright (c) 2014 Helix Toolkit contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Vortice;
#if COREWPF
using HelixToolkit.Vortice.Core;
#endif
namespace HelixToolkit.Wpf.Vortice
{
    public class Light3DCollection : GroupElement3D, ILight3D
    {
        public LightType LightType
        {
            get
            {
                return LightType.None;
            }
        }

        public override bool HitTest(HitTestContext context, ref List<HitTestResult> hits)
        {
            return false;
        }
    }
}