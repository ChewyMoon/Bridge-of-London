using System;
using System.Runtime.CompilerServices;
using BridgeOfLondon.Core.Wrappers;
using LeagueSharp;
using MoonSharp.Interpreter;
using SharpDX;
using Color = System.Drawing.Color;

namespace BridgeOfLondon.Core.API
{
    public class Drawings : ILuaApiProvider 
    {
        public void AddApi(Script script)
        {
            UserData.RegisterType<Color>(); //TODO: Does this work? 
            script.Globals["ARGB"] = (Func<int,int,int,Color>)Color.FromArgb;
            script.Globals["DrawText"] = (Action<string,int,float,float,Color>)this.DrawText;
            script.Globals["DrawLine"] = (Action<float,float,float,float,float,Color>)this.DrawLine;
            script.Globals["DrawRectangle"] = (Action<float,float,float,float,Color>)this.DrawRectangle;
            script.Globals["DrawCircle"] = (Action<float,float,float,float,int>)this.DrawCircle;
            script.Globals["WorldToScreen"] = (Func<LuaVector3, LuaVector2>) this.WorldToScreen;
            script.Globals["ScreenToWorld"] = (Func<LuaVector2, LuaVector3>) this.ScreenToWorld;
            script.Globals["D3DXVECTOR3"] = (Func<float, float, float, LuaVector3>) this.LuaVector3Wrapper;
            script.Globals["D3DXVECTOR2"] = (Func<float, float, LuaVector2>) this.LuaVector2Wrapper;
        }

        //TODO:
        //Handle OnReset
        public void HookEvents()
        {
        }

        public LuaVector2 WorldToScreen(LuaVector3 v)
        {
            return Drawing.WorldToScreen(v.ToVector3()).ToLuaVector2();
        }

        public LuaVector3 ScreenToWorld(LuaVector2 v)
        {
            return Drawing.ScreenToWorld(v.GetVector2()).ToLuaVector3();
        }

        public void DrawText(string text, int size, float x, float y, Color color)
        {
            Drawing.DrawText(x, y, color, text);
        }

        public void DrawLine(float startX, float startY, float endX, float endY, float size, Color color)
        {
            Drawing.DrawLine(startX, startY, endX, endY, size, color);
        }

        public void DrawRectangle(float x, float y, float width, float heigth, Color color)
        {
            DrawLine(x, y+heigth/2, x+width,y+heigth/2, heigth, color);
        }

        public void DrawCircle(float x, float y, float z, float size, int color)
        {
            Drawing.DrawCircle(new Vector3(x,z,y), size, Color.FromArgb(color) );
        }

        public LuaVector3 LuaVector3Wrapper(float x, float y, float z)
        {
            return new LuaVector3(x, y ,z);
        }

        public LuaVector2 LuaVector2Wrapper(float x, float y)
        {
            return new LuaVector2(x, y);
        }
    }
}
