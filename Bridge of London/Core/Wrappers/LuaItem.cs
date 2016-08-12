namespace BridgeOfLondon.Core.Wrappers
{
    using LeagueSharp;

    using MoonSharp.Interpreter;

    /// <summary>
    /// Provides extensions for the <see cref="InventorySlot"/> class.
    /// </summary>
    internal static class InventorySlotExtension
    {
        #region Public Methods and Operators


        /// <summary>
        /// Converts the <see cref="InventorySlot"/> to a lua item.
        /// </summary>
        /// <param name="slot">The slot.</param>
        /// <returns></returns>
        public static LuaItem ToLuaItem(this InventorySlot slot)
        {
            return new LuaItem(slot);
        }

        #endregion
    }

    /// <summary>
    /// A Lua represenation of the <see cref="InventorySlot"/> class;
    /// </summary>
    [MoonSharpUserData]
    public class LuaItem
    {
        #region Fields

        /// <summary>
        /// The inventory slot
        /// </summary>
        private readonly InventorySlot inventorySlot;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LuaItem"/> class.
        /// </summary>
        /// <param name="slot">The slot.</param>
        public LuaItem(InventorySlot slot)
        {
            this.inventorySlot = slot;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int id => (int)this.inventorySlot.Id;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name => this.inventorySlot.IData.DisplayName;

        /// <summary>
        /// Gets the stacks.
        /// </summary>
        /// <value>
        /// The stacks.
        /// </value>
        public int stacks => this.inventorySlot.Stacks;

        #endregion
    }
}