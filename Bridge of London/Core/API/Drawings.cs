using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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
        }

        //TODO:
        //Handle OnReset
        public void HookEvents()
        {
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
               
    }
}
