using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveMetaInfoManager
{
    [SerializeField]
    public List<SaveMetaInfo> saveMetaInfo;

    private JsonSerializer serializer = new JsonSerializer();

    public SaveMetaInfoManager()
    {
        saveMetaInfo = new List<SaveMetaInfo>();
    }
 

    public void SaveCurrentGame(int save)
    {
        GetSaveInfo();
        SaveMetaInfo currentSave = new SaveMetaInfo();
        currentSave.SaveCurrentGame();
        saveMetaInfo[save] = currentSave;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create(Application.persistentDataPath + "saves.binary");
        formatter.Serialize(saveFile, saveMetaInfo);
        saveFile.Close();

        foreach(SaveMetaInfo s in saveMetaInfo)
        {
            Debug.Log(s.name + " " + s.date);
        }

    }

    public void GetSaveInfo()
    {
        if(!File.Exists(Application.persistentDataPath + "saves.binary"))
        {
            CreateStarterFile();
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open(Application.persistentDataPath + "saves.binary", FileMode.Open);

        saveMetaInfo = (List<SaveMetaInfo>)formatter.Deserialize(saveFile);

        saveFile.Close();
    }

    private void CreateStarterFile()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open(Application.persistentDataPath + "saves.binary", FileMode.Create);
        saveMetaInfo.Add(new SaveMetaInfo());
        saveMetaInfo.Add(new SaveMetaInfo());
        saveMetaInfo.Add(new SaveMetaInfo());
        formatter.Serialize(saveFile, saveMetaInfo);
        saveFile.Close();
    }


}
