using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MessengerSaveEditor
{    
    internal class SaveFileEditor
    {
        SaveFile sv;
        int activeSlot;

        SaveSlot Slot => sv.SaveSlots[activeSlot];

        private List<int> ShopTree => Slot.ShopUpgradesUnlocked;
        public int SlotBalance 
        {
            get => Slot.itemsDict[0];
            set => Slot.itemsDict[0] = value;
        }

        public SaveFileEditor(SaveFile saveFile, int activeSlot = 0)
        {
            sv = saveFile;
            this.activeSlot = activeSlot;
        }

        public void ChangeSlot(int newSlot)
        {
            activeSlot = newSlot;
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


}
