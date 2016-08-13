namespace BridgeOfLondon.Core.Wrappers
{
    using System;

    using LeagueSharp.Common;

    using MoonSharp.Interpreter;

    using SharpDX;

    /// <summary>
    /// Provides extensions fo the <see cref="Vector3"/> class.
    /// </summary>
    public static class Vector3Extension
    {
        #region Public Methods and Operators

        /// <summary>
        /// Converts the <see cref="Vector3"/> into a <see cref="LuaVector3"/>.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns></returns>
        public static LuaVector3 ToLuaVector3(this Vector3 vector)
        {
            return new LuaVector3(vector);
        }

        #endregion
    }

    /// <summary>
    /// Provides extensions fo the <see cref="Vector1"/> class.
    /// </summary>
    public static class Vector2Extension
    {
        #region Public Methods and Operators

        /// <summary>
        /// Converts the <see cref="Vector2"/> into a <see cref="LuaVector2"/>.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns></returns>
        public static LuaVector2 ToLuaVector2(this Vector2 vector)
        {
            return new LuaVector2(vector);
        }

        #endregion
    }

    /// <summary>
    /// A Lua implemenation of a <see cref="Vector3"/>. Y and Z is switched.
    /// </summary>
    [MoonSharpUserData]
    public class LuaVector3
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LuaVector3"/> class.
        /// </summary>
        public LuaVector3()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LuaVector3"/> class.
        /// </summary>
        /// <param name="x0">The x0.</param>
        /// <param name="y0">The y0.</param>
        /// <param name="z0">The z0.</param>
        public LuaVector3(float x0, float y0, float z0)
        {
            this.x = x0;
            this.x = y0;
            this.z = z0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LuaVector3"/> class.
        /// </summary>
        /// <param name="v">The v.</param>
        public LuaVector3(Vector3 v)
            : this(v.X, v.Z, v.Y)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public float x { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public float y { get; set; }

        /// <summary>
        /// </summary>
        /// <value>
        /// The z.
        /// </value>
        public float z { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public LuaVector3 clone()
        {
            return new LuaVector3(this.x, this.y, this.z);
        }

        /// <summary>
        /// Gets the distance between the two vectors.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns></returns>
        public double dist(LuaVector3 v)
        {
            var dx = this.x - v.x;
            var dy = this.y - v.y;
            var dz = this.z - v.z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        /// <summary>
        /// Gets the length square rooted.
        /// </summary>
        /// <returns></returns>
        public double len()
        {
            return Math.Sqrt(this.len2());
        }

        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <returns></returns>
        public double len2()
        {
            return this.x * this.x + this.y * this.y + this.z * this.z;
        }

        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        public void normalize()
        {
            var v = this.ToVector3().Normalized();
            this.x = v.X;
            this.y = v.Y;
            this.z = v.Z;
        }

        /// <summary>
        /// Creates a clone of this instance, normalizes it, then returns it.
        /// </summary>
        /// <returns></returns>
        public LuaVector3 normalized()
        {
            return this.ToVector3().Normalized().ToLuaVector3();
        }

        /// <summary>
        /// Converts this instance into a <see cref="Vector3"/>.
        /// </summary>
        /// <returns></returns>
        [MoonSharpHidden]
        public Vector3 ToVector3()
        {
            return new Vector3(this.x, this.z, this.y);
        }

        // TODO see what this actually does
        /// <summary>
        /// Unpacks this instance.
        /// </summary>
        public void unpack()
        {
        }

        #endregion
    }

    public class LuaVector2
    {
        private Vector2 vector;

        #region Constructors and Destructors

        public LuaVector2()
        {
            vector = new Vector2();
        }

        public LuaVector2(float x, float y)
        {
            vector = new Vector2(x, y);
        }

        public LuaVector2(Vector2 v) : this(v.X, v.Y) //Copy instead of refering it
        {
        }

        #endregion


        [MoonSharpHidden]
        public Vector2 GetVector2()
        {
            return vector;
        }

        [MoonSharpHidden]
        public void SetVector2(Vector2 v)
        {
            vector = v;
        }
    }
}