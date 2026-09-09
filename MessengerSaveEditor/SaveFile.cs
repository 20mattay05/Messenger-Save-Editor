using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MessengerSaveEditor
{
    public class SaveFile
    {
        public SaveSlot[] SaveSlots { get; set; } = [];

        public void UpdateItemsFormat()
        {
            foreach (SaveSlot s in SaveSlots)
            {
                List<KeyValuePair<int, int>> l = s.itemsDict.ToList();
                Items newItems = new Items
                {
                    Keys = l.Select(kvp => kvp.Key).ToList(),
                    Values = l.Select(kvp => kvp.Value).ToList()
                };
                s.Items = newItems;
            }
        }

    }
    public class SaveSlot
    {
        public List<int> ShopUpgradesUnlocked { get; set; } = new();

        // Only used during json conversion. Instantly converted to the internal itemsDict dictionary for easier use
        public Items Items { get; set; }

        [JsonIgnore]
        public Dictionary<int, int> itemsDict = new();
    }
    public struct Items
    {
        public List<int> Keys { get; set; }
        public List<int> Values { get; set; }
    }
}
