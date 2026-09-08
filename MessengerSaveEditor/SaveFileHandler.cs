using System;
using System.Collections.Generic;
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
    }
}
