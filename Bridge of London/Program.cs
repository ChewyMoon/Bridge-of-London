namespace BridgeOfLondon
{
    using BridgeOfLondon.Core;

    using LeagueSharp.Common;

    internal class Program
    {
        #region Methods

        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += BridgeOfLondon.Instance.OnLoad;
        }

        #endregion
    }
}