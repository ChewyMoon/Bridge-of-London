using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;
using SharpDX;

namespace BridgeOfLondon.Core.API.Helpers
{
    public static class Vector3Extension
    {
        public static BolVector ToBolVector(this Vector3 vector)
        {
            return new BolVector(vector);
        }
    }
    /// <summary>
    /// Bol has Y and Z coordinates switched
    /// so to not break compat with many scripts we'll play along
    /// </summary>
    [MoonSharpUserData]
    public class BolVector
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public BolVector()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public BolVector(float x0, float y0, float z0)
        {
            x = x0;
            x = y0;
            z = z0;
        }

        public BolVector(Vector3 v) : this(v.X, v.Z, v.Y)
        {
            
        }

        public Vector3 ToVector3()
        {
            return new Vector3(x,z,y);
        }

    }
}
