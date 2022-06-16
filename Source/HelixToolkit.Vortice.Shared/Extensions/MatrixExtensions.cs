/*
The MIT License (MIT)
Copyright (c) 2018 Helix Toolkit contributors
*/
using global::Vortice;
using System;
using System.Numerics;
using Matrix = System.Numerics.Matrix4x4;
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
    public static class MatrixExtensions
    {
        /// <summary>
        /// Pseudo inversion
        /// </summary>
        /// <param name="viewMatrix"></param>
        /// <returns></returns>
        public static Matrix PsudoInvert(ref Matrix viewMatrix)
        {
            //var v33Transpose = new Matrix3x3(
            //    viewMatrix.M11, viewMatrix.M21, viewMatrix.M31,
            //    viewMatrix.M12, viewMatrix.M22, viewMatrix.M32,
            //    viewMatrix.M13, viewMatrix.M23, viewMatrix.M33);

            //var vpos = viewMatrix.Row4.ToVector3();

            //     vpos = Vector3.Transform(vpos, v33Transpose) * -1;

            var x = viewMatrix.M41 * viewMatrix.M11 + viewMatrix.M42 * viewMatrix.M12 + viewMatrix.M43 * viewMatrix.M13;
            var y = viewMatrix.M41 * viewMatrix.M21 + viewMatrix.M42 * viewMatrix.M22 + viewMatrix.M43 * viewMatrix.M23;
            var z = viewMatrix.M41 * viewMatrix.M31 + viewMatrix.M42 * viewMatrix.M32 + viewMatrix.M43 * viewMatrix.M33;

            return new Matrix(
                viewMatrix.M11, viewMatrix.M21, viewMatrix.M31, 0,
                viewMatrix.M12, viewMatrix.M22, viewMatrix.M32, 0,
                viewMatrix.M13, viewMatrix.M23, viewMatrix.M33, 0, -x, -y, -z, 1);
        }
        /// <summary>
        /// Pseudo  inversion
        /// </summary>
        /// <param name="viewMatrix"></param>
        /// <returns></returns>
        public static Matrix PsudoInvert(this Matrix viewMatrix)
        {
            //var v33Transpose = new Matrix3x3(
            //    viewMatrix.M11, viewMatrix.M21, viewMatrix.M31,
            //    viewMatrix.M12, viewMatrix.M22, viewMatrix.M32,
            //    viewMatrix.M13, viewMatrix.M23, viewMatrix.M33);

            //var vpos = viewMatrix.Row4.ToVector3();

            //     vpos = Vector3.Transform(vpos, v33Transpose) * -1;

            var x = viewMatrix.M41 * viewMatrix.M11 + viewMatrix.M42 * viewMatrix.M12 + viewMatrix.M43 * viewMatrix.M13;
            var y = viewMatrix.M41 * viewMatrix.M21 + viewMatrix.M42 * viewMatrix.M22 + viewMatrix.M43 * viewMatrix.M23;
            var z = viewMatrix.M41 * viewMatrix.M31 + viewMatrix.M42 * viewMatrix.M32 + viewMatrix.M43 * viewMatrix.M33;

            return new Matrix(
                viewMatrix.M11, viewMatrix.M21, viewMatrix.M31, 0,
                viewMatrix.M12, viewMatrix.M22, viewMatrix.M32, 0,
                viewMatrix.M13, viewMatrix.M23, viewMatrix.M33, 0, -x, -y, -z, 1);
        }

        //
        // 摘要:
        //     Creates a left-handed, look-at matrix.
        //
        // 参数:
        //   eye:
        //     The position of the viewer's eye.
        //
        //   target:
        //     The camera look-at target.
        //
        //   up:
        //     The camera's up vector.
        //
        //   result:
        //     When the method completes, contains the created look-at matrix.
        public static void LookAtLH(ref Vector3 eye, ref Vector3 target, ref Vector3 up, out Matrix result)
        {
            var result2 = Vector3.Subtract(target, eye);
            result2 = result2.Normalize();
            var result3 = Vector3.Cross(up, result2);
            result3 = result3.Normalize();
            var result4 = Vector3.Cross(result2, result3);
            result = Matrix.Identity;
            result.M11 = result3.X;
            result.M21 = result3.Y;
            result.M31 = result3.Z;
            result.M12 = result4.X;
            result.M22 = result4.Y;
            result.M32 = result4.Z;
            result.M13 = result2.X;
            result.M23 = result2.Y;
            result.M33 = result2.Z;
            result.M41 = Vector3.Dot(result3, eye);
            result.M42 = Vector3.Dot(result4, eye);
            result.M43 = Vector3.Dot(result2, eye);
            result.M41 = 0f - result.M41;
            result.M42 = 0f - result.M42;
            result.M43 = 0f - result.M43;
        }

        //
        // 摘要:
        //     Creates a left-handed, look-at matrix.
        //
        // 参数:
        //   eye:
        //     The position of the viewer's eye.
        //
        //   target:
        //     The camera look-at target.
        //
        //   up:
        //     The camera's up vector.
        //
        // 返回结果:
        //     The created look-at matrix.
        public static Matrix LookAtLH(Vector3 eye, Vector3 target, Vector3 up)
        {
            LookAtLH(ref eye, ref target, ref up, out var result);
            return result;
        }

        //
        // 摘要:
        //     Creates a right-handed, look-at matrix.
        //
        // 参数:
        //   eye:
        //     The position of the viewer's eye.
        //
        //   target:
        //     The camera look-at target.
        //
        //   up:
        //     The camera's up vector.
        //
        //   result:
        //     When the method completes, contains the created look-at matrix.
        public static void LookAtRH(ref Vector3 eye, ref Vector3 target, ref Vector3 up, out Matrix result)
        {
            var result2 = Vector3.Subtract(eye, target);
            result2 = result2.Normalize();
            var result3 = Vector3.Cross(up, result2);
            result3 = result3.Normalize();
            var result4 = Vector3.Cross(result2, result3);
            result = Matrix.Identity;
            result.M11 = result3.X;
            result.M21 = result3.Y;
            result.M31 = result3.Z;
            result.M12 = result4.X;
            result.M22 = result4.Y;
            result.M32 = result4.Z;
            result.M13 = result2.X;
            result.M23 = result2.Y;
            result.M33 = result2.Z;
            result.M41 = Vector3.Dot(result3, eye);
            result.M42 = Vector3.Dot(result4, eye);
            result.M43 = Vector3.Dot(result2, eye);
            result.M41 = 0f - result.M41;
            result.M42 = 0f - result.M42;
            result.M43 = 0f - result.M43;
        }

        //
        // 摘要:
        //     Creates a right-handed, look-at matrix.
        //
        // 参数:
        //   eye:
        //     The position of the viewer's eye.
        //
        //   target:
        //     The camera look-at target.
        //
        //   up:
        //     The camera's up vector.
        //
        // 返回结果:
        //     The created look-at matrix.
        public static Matrix LookAtRH(Vector3 eye, Vector3 target, Vector3 up)
        {
            LookAtRH(ref eye, ref target, ref up, out var result);
            return result;
        }
        //
        // 摘要:
        //     Creates a left-handed, orthographic projection matrix.
        //
        // 参数:
        //   width:
        //     Width of the viewing volume.
        //
        //   height:
        //     Height of the viewing volume.
        //
        //   znear:
        //     Minimum z-value of the viewing volume.
        //
        //   zfar:
        //     Maximum z-value of the viewing volume.
        //
        //   result:
        //     When the method completes, contains the created projection matrix.
        public static void OrthoLH(float width, float height, float znear, float zfar, out Matrix result)
        {
            float num = width * 0.5f;
            float num2 = height * 0.5f;
            OrthoOffCenterLH(0f - num, num, 0f - num2, num2, znear, zfar, out result);
        }

        //
        // 摘要:
        //     Creates a left-handed, orthographic projection matrix.
        //
        // 参数:
        //   width:
        //     Width of the viewing volume.
        //
        //   height:
        //     Height of the viewing volume.
        //
        //   znear:
        //     Minimum z-value of the viewing volume.
        //
        //   zfar:
        //     Maximum z-value of the viewing volume.
        //
        // 返回结果:
        //     The created projection matrix.
        public static Matrix OrthoLH(float width, float height, float znear, float zfar)
        {
            OrthoLH(width, height, znear, zfar, out var result);
            return result;
        }

        //
        // 摘要:
        //     Creates a right-handed, orthographic projection matrix.
        //
        // 参数:
        //   width:
        //     Width of the viewing volume.
        //
        //   height:
        //     Height of the viewing volume.
        //
        //   znear:
        //     Minimum z-value of the viewing volume.
        //
        //   zfar:
        //     Maximum z-value of the viewing volume.
        //
        //   result:
        //     When the method completes, contains the created projection matrix.
        public static void OrthoRH(float width, float height, float znear, float zfar, out Matrix result)
        {
            float num = width * 0.5f;
            float num2 = height * 0.5f;
            OrthoOffCenterRH(0f - num, num, 0f - num2, num2, znear, zfar, out result);
        }

        //
        // 摘要:
        //     Creates a right-handed, orthographic projection matrix.
        //
        // 参数:
        //   width:
        //     Width of the viewing volume.
        //
        //   height:
        //     Height of the viewing volume.
        //
        //   znear:
        //     Minimum z-value of the viewing volume.
        //
        //   zfar:
        //     Maximum z-value of the viewing volume.
        //
        // 返回结果:
        //     The created projection matrix.
        public static Matrix OrthoRH(float width, float height, float znear, float zfar)
        {
            OrthoRH(width, height, znear, zfar, out var result);
            return result;
        }

        //
        // 摘要:
        //     Creates a left-handed, customized orthographic projection matrix.
        //
        // 参数:
        //   left:
        //     Minimum x-value of the viewing volume.
        //
        //   right:
        //     Maximum x-value of the viewing volume.
        //
        //   bottom:
        //     Minimum y-value of the viewing volume.
        //
        //   top:
        //     Maximum y-value of the viewing volume.
        //
        //   znear:
        //     Minimum z-value of the viewing volume.
        //
        //   zfar:
        //     Maximum z-value of the viewing volume.
        //
        //   result:
        //     When the method completes, contains the created projection matrix.
        public static void OrthoOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar, out Matrix result)
        {
            float num = 1f / (zfar - znear);
            result = Matrix.Identity;
            result.M11 = 2f / (right - left);
            result.M22 = 2f / (top - bottom);
            result.M33 = num;
            result.M41 = (left + right) / (left - right);
            result.M42 = (top + bottom) / (bottom - top);
            result.M43 = (0f - znear) * num;
        }

        //
        // 摘要:
        //     Creates a left-handed, customized orthographic projection matrix.
        //
        // 参数:
        //   left:
        //     Minimum x-value of the viewing volume.
        //
        //   right:
        //     Maximum x-value of the viewing volume.
        //
        //   bottom:
        //     Minimum y-value of the viewing volume.
        //
        //   top:
        //     Maximum y-value of the viewing volume.
        //
        //   znear:
        //     Minimum z-value of the viewing volume.
        //
        //   zfar:
        //     Maximum z-value of the viewing volume.
        //
        // 返回结果:
        //     The created projection matrix.
        public static Matrix OrthoOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar)
        {
            OrthoOffCenterLH(left, right, bottom, top, znear, zfar, out var result);
            return result;
        }

        //
        // 摘要:
        //     Creates a right-handed, customized orthographic projection matrix.
        //
        // 参数:
        //   left:
        //     Minimum x-value of the viewing volume.
        //
        //   right:
        //     Maximum x-value of the viewing volume.
        //
        //   bottom:
        //     Minimum y-value of the viewing volume.
        //
        //   top:
        //     Maximum y-value of the viewing volume.
        //
        //   znear:
        //     Minimum z-value of the viewing volume.
        //
        //   zfar:
        //     Maximum z-value of the viewing volume.
        //
        //   result:
        //     When the method completes, contains the created projection matrix.
        public static void OrthoOffCenterRH(float left, float right, float bottom, float top, float znear, float zfar, out Matrix result)
        {
            OrthoOffCenterLH(left, right, bottom, top, znear, zfar, out result);
            result.M33 *= -1f;
        }

        //
        // 摘要:
        //     Creates a right-handed, customized orthographic projection matrix.
        //
        // 参数:
        //   left:
        //     Minimum x-value of the viewing volume.
        //
        //   right:
        //     Maximum x-value of the viewing volume.
        //
        //   bottom:
        //     Minimum y-value of the viewing volume.
        //
        //   top:
        //     Maximum y-value of the viewing volume.
        //
        //   znear:
        //     Minimum z-value of the viewing volume.
        //
        //   zfar:
        //     Maximum z-value of the viewing volume.
        //
        // 返回结果:
        //     The created projection matrix.
        public static Matrix OrthoOffCenterRH(float left, float right, float bottom, float top, float znear, float zfar)
        {
            OrthoOffCenterRH(left, right, bottom, top, znear, zfar, out var result);
            return result;
        }

        //
        // 摘要:
        //     Creates a left-handed, perspective projection matrix based on a field of view.
        //
        // 参数:
        //   fov:
        //     Field of view in the y direction, in radians.
        //
        //   aspect:
        //     Aspect ratio, defined as view space width divided by height.
        //
        //   znear:
        //     Minimum z-value of the viewing volume.
        //
        //   zfar:
        //     Maximum z-value of the viewing volume.
        //
        //   result:
        //     When the method completes, contains the created projection matrix.
        public static void PerspectiveFovLH(float fov, float aspect, float znear, float zfar, out Matrix result)
        {
            float num = (float)(1.0 / Math.Tan(fov * 0.5f));
            float num2 = zfar / (zfar - znear);
            result = default(Matrix);
            result.M11 = num / aspect;
            result.M22 = num;
            result.M33 = num2;
            result.M34 = 1f;
            result.M43 = (0f - num2) * znear;
        }

        //
        // 摘要:
        //     Creates a left-handed, perspective projection matrix based on a field of view.
        //
        // 参数:
        //   fov:
        //     Field of view in the y direction, in radians.
        //
        //   aspect:
        //     Aspect ratio, defined as view space width divided by height.
        //
        //   znear:
        //     Minimum z-value of the viewing volume.
        //
        //   zfar:
        //     Maximum z-value of the viewing volume.
        //
        // 返回结果:
        //     The created projection matrix.
        public static Matrix PerspectiveFovLH(float fov, float aspect, float znear, float zfar)
        {
            PerspectiveFovLH(fov, aspect, znear, zfar, out var result);
            return result;
        }

        //
        // 摘要:
        //     Creates a right-handed, perspective projection matrix based on a field of view.
        //
        // 参数:
        //   fov:
        //     Field of view in the y direction, in radians.
        //
        //   aspect:
        //     Aspect ratio, defined as view space width divided by height.
        //
        //   znear:
        //     Minimum z-value of the viewing volume.
        //
        //   zfar:
        //     Maximum z-value of the viewing volume.
        //
        //   result:
        //     When the method completes, contains the created projection matrix.
        public static void PerspectiveFovRH(float fov, float aspect, float znear, float zfar, out Matrix result)
        {
            float num = (float)(1.0 / Math.Tan(fov * 0.5f));
            float num2 = zfar / (znear - zfar);
            result = default(Matrix);
            result.M11 = num / aspect;
            result.M22 = num;
            result.M33 = num2;
            result.M34 = -1f;
            result.M43 = num2 * znear;
        }

        //
        // 摘要:
        //     Creates a right-handed, perspective projection matrix based on a field of view.
        //
        // 参数:
        //   fov:
        //     Field of view in the y direction, in radians.
        //
        //   aspect:
        //     Aspect ratio, defined as view space width divided by height.
        //
        //   znear:
        //     Minimum z-value of the viewing volume.
        //
        //   zfar:
        //     Maximum z-value of the viewing volume.
        //
        // 返回结果:
        //     The created projection matrix.
        public static Matrix PerspectiveFovRH(float fov, float aspect, float znear, float zfar)
        {
            PerspectiveFovRH(fov, aspect, znear, zfar, out var result);
            return result;
        }


    }
}
