using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MessengerSaveEditor
{
    public class SaveFile
    {
        public SaveSlot[] SaveSlots { get; set; } = [];
    }
    public class SaveSlot
    {
        public List<int> ShopUpgradesUnlocked { get; set; } = new();
        public Items Items { get; set; }

        [JsonIgnore]
        public Dictionary<int, int> itemsDict = new();
    }
    public struct Items
    {
        public List<int> Keys { get; set; }
        public List<int> Values { get; set; }
    }

    internal class SaveSlotEditor
    {
        SaveSlot slot;

        private List<int> ShopTree => slot.ShopUpgradesUnlocked;
        private int Balance 
        {
            get => slot.itemsDict[0];
            set => slot.itemsDict[0] = value;
        }

        public SaveSlotEditor(SaveSlot slot)
        {
            this.slot = slot;
        }

        public void ChangeBalance(int newVal)
        {
            Balance = newVal;
        }

        public List<TreeComponentName> EnabledTreeComponents()
        {
            List<TreeComponentName> list = new();
            foreach (int c in ShopTree)
            {
                list.Add((TreeComponentName)c);
            }
            return list;
        }

        public void EnableTreeComponent(TreeComponentName c)
        {
            int val = (int)c;
            if (!ShopTree.Contains(val)) ShopTree.Add(val);
        }

        public void DisableTreeComponent(TreeComponentName c)
        {
            int val = (int)c;
            ShopTree.Remove(val);
        }

    }

    // TODO: Sort this
    public enum TreeComponentName // Specifically sorted so that (int)name is the same number as in the games code
    {
        KarutaPlates,
        SerendipitousBodies,
        PathOfResilience,
        KusariJacket,
        EnergyShuriken,
        SerendipitousMinds,
        PreparedMind,
        StrikeOfTheNinja,
        SecondWind,
        CurrentsMaster,
        Meditation,
        RejuvenativeSpirit,
        CenteredMind,
        AerobaticsWarrior,
        DemonsBane,
        DevilsDue,
        TimeSense,
        PowerSense,
        FocusedPowerSense
    }

    public enum ItemComponentName
    {

    }
}
