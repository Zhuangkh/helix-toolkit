/*
The MIT License (MIT)
Copyright (c) 2018 Helix Toolkit contributors
*/
using Vortice.Direct3D11;
using System.Collections.Generic;
#if DX11_1
using Device = Vortice.Direct3D11.ID3D11Device1;
#else
using Device = Vortice.Direct3D11.ID3D11Device;
#endif
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
    using ShaderManager;
    using System;
    using Shaders;
    /// <summary>
    /// 
    /// </summary>
    public interface IRenderTechnique : IDisposable, IGUID
    {
        /// <summary>
        /// 
        /// </summary>
        TechniqueDescription Description
        {
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        bool IsNull
        {
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        string Name
        {
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        Device Device { get; }

        /// <summary>
        /// Input layout for all passes
        /// </summary>
        InputLayoutProxy Layout
        {
            get;
        }

        /// <summary>
        /// All shader pass names
        /// </summary>
        IEnumerable<string> ShaderPassNames
        {
            get;
        }

        IConstantBufferPool ConstantBufferPool
        {
            get;
        }
        /// <summary>
        /// Get pass by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ShaderPass GetPass(string name);
        /// <summary>
        /// Get pass by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        ShaderPass GetPass(int index);

        IEffectsManager EffectsManager
        {
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        ShaderPass this[int index] { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ShaderPass this[string name] { get; }
        /// <summary>
        /// Adds the pass.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        bool AddPass(ShaderPassDescription description);
        /// <summary>
        /// Removes the pass.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        bool RemovePass(string name);
    }
}
