using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerSaveEditor
{
    public class InventoryComponent : ISaveFileComponent
    {
        int keyVal;
        public InventoryComponent(int keyVal)
        {
            this.keyVal = keyVal;
        }
        public bool IsEnabled(SaveSlot s) => s.itemsDict.ContainsKey(keyVal);
        public SaveSlot Enable(SaveSlot s)
        {
            s.itemsDict.TryAdd(keyVal, 1);
            return s;
        }
        public SaveSlot Disable(SaveSlot s)
        {
            s.itemsDict.Remove(keyVal);
            return s;
        }
    }

    public class TreeComponent : ISaveFileComponent
    {
        int saveNum;
        public TreeComponent(int saveNum)
        {
            this.saveNum = saveNum;
        }

        public bool IsEnabled(SaveSlot s) => Tree(s).Contains(saveNum);
        public SaveSlot Enable(SaveSlot s)
        {
            if (!Tree(s).Contains(saveNum)) Tree(s).Add(saveNum);
            return s;
        }
        public SaveSlot Disable(SaveSlot s)
        {
            Tree(s).Remove(saveNum);
            return s;
        }
        private List<int> Tree(SaveSlot s) => s.ShopUpgradesUnlocked;
    }

    interface ISaveFileComponent
    {
        public bool IsEnabled(SaveSlot slot);
        public SaveSlot Enable(SaveSlot slot);
        public SaveSlot Disable(SaveSlot slot);
    }
}
