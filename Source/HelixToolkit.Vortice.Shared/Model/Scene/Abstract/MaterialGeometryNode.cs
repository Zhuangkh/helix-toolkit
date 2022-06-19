﻿/*
The MIT License(MIT)
Copyright(c) 2020 Helix Toolkit contributors
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
    namespace Model.Scene
    {
        using Core;

        public abstract class MaterialGeometryNode : GeometryNode
        {
            private bool isTransparent = false;
            /// <summary>
            /// Specifiy if model material is transparent.
            /// During rendering, transparent objects are rendered after opaque objects. Transparent objects' order in scene graph are preserved.
            /// </summary>
            public bool IsTransparent
            {
                get
                {
                    return isTransparent;
                }
                set
                {
                    if (Set(ref isTransparent, value))
                    {
                        if (RenderType == RenderType.Opaque || RenderType == RenderType.Transparent)
                        {
                            RenderType = value ? RenderType.Transparent : RenderType.Opaque;
                        }
                    }
                }
            }
            private MaterialVariable materialVariable;
            private MaterialCore material;
            /// <summary>
            ///
            /// </summary>
            public MaterialCore Material
            {
                get
                {
                    return material;
                }
                set
                {
                    if (Set(ref material, value))
                    {
                        if (RenderHost != null)
                        {
                            if (IsAttached)
                            {
                                AttachMaterial();
                                InvalidateRender();
                            }
                            else
                            {
                                Detach();
                                Attach(RenderHost);
                            }
                        }
                    }
                }
            }

            protected virtual void AttachMaterial()
            {
                var newVar = material != null && RenderCore is IMaterialRenderParams ?
                    EffectsManager.MaterialVariableManager.Register(material, EffectTechnique) : null;
                RemoveAndDispose(ref materialVariable);
                materialVariable = newVar;
                if (RenderCore is IMaterialRenderParams core)
                {
                    core.MaterialVariables = newVar;
                }
            }

            protected override OrderKey OnUpdateRenderOrderKey()
            {
                return OrderKey.Create(RenderOrder, materialVariable == null ? (ushort)0 : materialVariable.ID);
            }

            protected override bool CanRender(RenderContext context)
            {
                return base.CanRender(context) && materialVariable != null;
            }

            protected override bool OnAttach(IRenderHost host)
            {
                if (base.OnAttach(host))
                {
                    AttachMaterial();
                    return true;
                }
                else
                {
                    return false;
                }
            }

            protected override void OnDetach()
            {
                RemoveAndDispose(ref materialVariable);
                if (RenderCore is IMaterialRenderParams core)
                {
                    core.MaterialVariables = null;
                }
                base.OnDetach();
            }
        }
    }
}