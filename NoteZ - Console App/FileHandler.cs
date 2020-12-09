using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace NoteZ___Console_App
{
    public class FileHandler
    {
        public Keystroke[] text;
        public string date;
        public FileHandler(Keystroke[] text)
        {
            this.text = text;
            date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public void Save()
        {
            var oldData = Load();

            bool oldFound = false;
            foreach(var data in oldData)
            {
                if(data.date == this.date)
                {
                    data.text = this.text;
                    oldFound = true;
                }
            }
            var newData = new List<FileHandler>(oldData);
            if (!oldFound)
            {
                newData.Add(this);
            }
            
            string jsonString = JsonConvert.SerializeObject(newData);
            File.WriteAllText(GetFileURI(), jsonString);
        }

        public static FileHandler[] Load()
        {
            if (File.Exists(GetFileURI()))
            {
                return JsonConvert.DeserializeObject<FileHandler[]>(File.ReadAllText(GetFileURI()));
            }
            else
            {
                return new FileHandler[] { };
            }
        }

        private static string GetFileURI()
        {
            return Directory.GetCurrentDirectory() + "/data.json";
        }
    }

    public class FileList
    {
        public FileHandler[] files;
        public FileList(FileHandler[] files)
        {
            this.files = files;
        }
    }
}
