using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MessengerSaveEditor
{
    internal class SaveFileHandler
    {
        public SaveFile GetSaveFile(string[] saveFile)
        {
            string[] decrypted = DecryptSaveFile(saveFile);
            SaveFile sv = ParseSaveFile(decrypted);
            return sv;
        }

        public string[] MakeSaveFile(SaveFile saveFile)
        {
            throw new NotImplementedException();
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
    }
}
