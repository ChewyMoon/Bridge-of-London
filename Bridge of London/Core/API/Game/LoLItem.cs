using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API.Game
{

    static class InventorySlotExtension
    {
        public static LoLItem ToBolLoLItem(this InventorySlot slot)
        {
            return  new LoLItem(slot);
        }
    }

    [MoonSharpUserData]
    public class LoLItem
    {
        private readonly InventorySlot _inventorySlot;

        #region BolApi members

        public string name => _inventorySlot.IData.DisplayName;
        public int id => (int) _inventorySlot.Id;
        public int stacks => _inventorySlot.Stacks;

        #endregion


        public LoLItem(InventorySlot slot)
        {
            _inventorySlot = slot;
        }
    }
}
