using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameSaveSaveSelectionButton save1;
    public GameSaveSaveSelectionButton save2;
    public GameSaveSaveSelectionButton save3;


    void Start()
    {
        Game.playerSave.metaInfo.GetSaveInfo();

        save1.saveText = Game.playerSave.metaInfo.saveMetaInfo[0].name + "\n" + Game.playerSave.metaInfo.saveMetaInfo[0].date;
        save2.saveText = Game.playerSave.metaInfo.saveMetaInfo[1].name + "\n" + Game.playerSave.metaInfo.saveMetaInfo[1].date;
        save3.saveText = Game.playerSave.metaInfo.saveMetaInfo[2].name + "\n" + Game.playerSave.metaInfo.saveMetaInfo[2].date;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
