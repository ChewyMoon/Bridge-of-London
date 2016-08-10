using LeagueSharp;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API.Game
{

    public static class BuffInstanceExtensation
    {
        public static Buff ToBolBuff(this BuffInstance buffInstance)
        {
            return new Buff(buffInstance);
        }
    }

    [MoonSharpUserData]
    public class Buff
    {
        private readonly BuffInstance _buffInstance;

        public string name => _buffInstance.Name;
        public float startT => _buffInstance.StartTime;
        public float endT => _buffInstance.EndTime;
        public bool valid => _buffInstance.IsValid;

        public Buff(BuffInstance buffInstance)
        {
            _buffInstance = buffInstance;
        }
    }
}
