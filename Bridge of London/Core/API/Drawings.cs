namespace BridgeOfLondon.Core.API
{
    using System;

    using global::BridgeOfLondon.Core.Wrappers;

    using LeagueSharp;

    using MoonSharp.Interpreter;

    using SharpDX;

    using Color = System.Drawing.Color;

    /// <summary>
    ///     Adds the drawing API to the Lua script.
    /// </summary>
    /// <seealso cref="BridgeOfLondon.Core.API.ILuaApiProvider" />
    public class Drawings : ILuaApiProvider
    {
        #region Public Methods and Operators

        public void AddApi(Script script)
        {
            UserData.RegisterType<Color>(); //TODO: Does this work? 
            script.Globals["ARGB"] = (Func<int, int, int, Color>)Color.FromArgb;
            script.Globals["DrawText"] = (Action<string, int, float, float, Color>)this.DrawText;
            script.Globals["DrawLine"] = (Action<float, float, float, float, float, Color>)this.DrawLine;
            script.Globals["DrawRectangle"] = (Action<float, float, float, float, Color>)this.DrawRectangle;
            script.Globals["DrawCircle"] = (Action<float, float, float, float, int>)this.DrawCircle;
            script.Globals["WorldToScreen"] = (Func<LuaVector3, LuaVector2>)this.WorldToScreen;
            script.Globals["ScreenToWorld"] = (Func<LuaVector2, LuaVector3>)this.ScreenToWorld;
            script.Globals["D3DXVECTOR3"] = (Func<float, float, float, LuaVector3>)this.LuaVector3Wrapper;
            script.Globals["D3DXVECTOR2"] = (Func<float, float, LuaVector2>)this.LuaVector2Wrapper;
        }

        /// <summary>
        ///     Draws a circle.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <param name="size">The size.</param>
        /// <param name="color">The color.</param>
        public void DrawCircle(float x, float y, float z, float size, int color)
        {
            Drawing.DrawCircle(new Vector3(x, z, y), size, Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
        }

        /// <summary>
        ///     Draws a line.
        /// </summary>
        /// <param name="startX">The start x.</param>
        /// <param name="startY">The start y.</param>
        /// <param name="endX">The end x.</param>
        /// <param name="endY">The end y.</param>
        /// <param name="size">The size.</param>
        /// <param name="color">The color.</param>
        public void DrawLine(float startX, float startY, float endX, float endY, float size, Color color)
        {
            Drawing.DrawLine(startX, startY, endX, endY, size, color);
        }

        /// <summary>
        ///     Draws a rectangle.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="heigth">The heigth.</param>
        /// <param name="color">The color.</param>
        public void DrawRectangle(float x, float y, float width, float heigth, Color color)
        {
            this.DrawLine(x, y + heigth / 2, x + width, y + heigth / 2, heigth, color);
        }

        /// <summary>
        ///     Draws a text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="size">The size.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="color">The color.</param>
        public void DrawText(string text, int size, float x, float y, Color color)
        {
            Drawing.DrawText(x, y, color, text);
        }

        //TODO:
        //Handle OnReset
        /// <summary>
        ///     Hooks the events.
        /// </summary>
        public void HookEvents()
        {
        }

        /// <summary>
        ///     Creates a lua Vector2.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public LuaVector2 LuaVector2Wrapper(float x, float y)
        {
            return new LuaVector2(x, y);
        }

        /// <summary>
        ///     Creates a Lua Vector3.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <returns></returns>
        public LuaVector3 LuaVector3Wrapper(float x, float y, float z)
        {
            return new LuaVector3(x, y, z);
        }

        /// <summary>
        ///     Converts a position on the screen to the position in the world.
        /// </summary>
        /// <param name="v">The v.</param>
        /// <returns></returns>
        public LuaVector3 ScreenToWorld(LuaVector2 v)
        {
            return Drawing.ScreenToWorld(v.GetVector2()).ToLuaVector3();
        }

        /// <summary>
        ///     Converts a position in the world to the position of the screen.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns></returns>
        public LuaVector2 WorldToScreen(LuaVector3 v)
        {
            return Drawing.WorldToScreen(v.ToVector3()).ToLuaVector2();
        }

        #endregion
    }
}