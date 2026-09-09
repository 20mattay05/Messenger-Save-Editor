using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MessengerSaveEditor
{
    internal class SaveFileHandler
    {
        string[]? oldSaveFile;
        public SaveFile GetSaveFile(string[] saveFile)
        {
            string[] decrypted = DecryptSaveFile(saveFile);
            oldSaveFile = decrypted;
            SaveFile sv = ParseSaveFile(decrypted);
            return sv;
        }

        public string[] MakeSaveFile(SaveFile saveFile)
        {
            if (oldSaveFile == null) throw new Exception("Decrypted save file null. GetSaveFile() must be run before MakeSaveFile()");
            return MakeSaveFile(saveFile, oldSaveFile);
        }

        public string[] MakeSaveFile(SaveFile saveFile, string[] oldDecryptedSave)
        {
            string[] newSave = UnparseSaveFile(saveFile, oldDecryptedSave);
            Console.WriteLine($"{newSave[0]}");
            string[] encrypted = EncryptSaveFile(newSave);
            return encrypted;
        }

        private string[] DecryptSaveFile(string[] saveFile)
        {
            List<string> newLines = new(saveFile.Length);
            foreach (string line in saveFile)
            {
                StringBuilder newLine = new StringBuilder();
                foreach (char c in line)
                {
                    int cVal = c;
                    bool isOdd = (cVal & 1) == 1;
                    int nudge = isOdd ? -1 : 1;

                    int newCVal = (cVal ^ 128) + nudge;

                    newLine.Append((char)newCVal);
                }
                newLines.Add(newLine.ToString());
            }

            return newLines.ToArray();
        }

        private string[] EncryptSaveFile(string[] saveFile) => DecryptSaveFile(saveFile);

        private SaveFile ParseSaveFile(string[] saveFile)
        {
            JsonSerializerOptions op = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };
            SaveFile sv = JsonSerializer.Deserialize<SaveFile>(saveFile[0], op);
            for (int i = 0; i < sv.SaveSlots.Length; i++)
            {
                SaveSlot slot = sv.SaveSlots[i];
                slot.itemsDict = new();
                List<int> ks = slot.Items.Keys;
                List<int> vs = slot.Items.Values;
                for (int j = 0; j < ks.Count; j++) slot.itemsDict[ks[j]] = vs[j];
            }
            return sv;
        }

        private string[] UnparseSaveFile(SaveFile sv, string[] oldJson)
        {
            if (oldJson.Length > 1) throw new NotImplementedException("Expected json with only one line");
            string onlyLine = oldJson[0];
            sv.UpdateItemsFormat();

            JsonNode node = JsonNode.Parse(onlyLine)!;
            JsonArray slots = node.AsArray();

            for (int i = 0; i < slots.Count; i++)
            {
                JsonNode jslot = slots[i]!;
                SaveSlot slot = sv.SaveSlots[i];
                jslot["items"]["keys"].ReplaceWith(slot.Items.Keys);
                jslot["items"]["values"].ReplaceWith(slot.Items.Values);
                jslot["shopUpgradesUnlocked"].ReplaceWith(slot.ShopUpgradesUnlocked);
            }
            return [node.ToJsonString()];
        }

        public void DebugDifference(string[] jsv1, string[] jsv2)
        {
            Debug.WriteLine("Parsing to find differences...");
            string[] d1 = DecryptSaveFile(jsv1);
            string[] d2 = DecryptSaveFile(jsv2);
            SaveFile sv1 = ParseSaveFile(d1);
            SaveFile sv2 = ParseSaveFile(d2);
            Debug.WriteLine("Finding differences...");
            for (int i = 0; i < sv1.SaveSlots.Length; i++)
            {
                SaveSlot sv1Slot = sv1.SaveSlots[i];
                SaveSlot sv2Slot = sv2.SaveSlots[i];
                (SaveSlot larger, SaveSlot smaller) = sv1Slot.Items.Keys.Count > sv2Slot.Items.Keys.Count ? (sv1Slot, sv2Slot) : (sv2Slot, sv1Slot);
                List<int> itemsDiff = larger.Items.Keys.Except(smaller.Items.Keys).ToList();
                if (itemsDiff.Count > 0) Debug.WriteLine($"Slot {i+1} has item difference(s): {string.Join(',', itemsDiff)}");

                (larger, smaller) = sv1Slot.ShopUpgradesUnlocked.Count > sv2Slot.ShopUpgradesUnlocked.Count ? (sv1Slot, sv2Slot) : (sv2Slot, sv1Slot);
                List<int> shopDiff = larger.ShopUpgradesUnlocked.Except(smaller.ShopUpgradesUnlocked).ToList();
                if (shopDiff.Count > 0) Debug.WriteLine($"Slot {i+1} has shop difference(s): {string.Join(',', shopDiff)}");

            }
            Debug.WriteLine("Done!");
        }
    }
}
