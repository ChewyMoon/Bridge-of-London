using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp.Common;
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
        #region properties

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        #endregion

        #region Bol Api

        public BolVector clone()
        {
            return new BolVector(x,y,z);
        }

        //TODO see what this actually does
        public void unpack()
        {
            
        }

        public double len2()
        {
            return x*x + y*y + z*z;
        }

        public double len()
        {
            return Math.Sqrt(len2());
        }

        public double dist(BolVector v)
        {
            var dx = x - v.x;
            var dy = y - v.y;
            var dz = z - v.z;
            return Math.Sqrt(dx*dx + dy*dy + dz*dz);
        }

        public void normalize()
        {
            var v = this.ToVector3().Normalized();
            x = v.X;
            y = v.Y;
            z = v.Z;
        }

        public BolVector normalized()
        {
            return this.ToVector3().Normalized().ToBolVector();
        }

        #endregion

        #region Constructors
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
        #endregion

        [MoonSharpHidden]
        public Vector3 ToVector3()
        {
            return new Vector3(x,z,y);
        }

    }
}
