using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameLoadSaveSelectionButton save1;
    public GameLoadSaveSelectionButton save2;
    public GameLoadSaveSelectionButton save3;


    void Start()
    {
        Game.playerSave.metaInfo.GetSaveInfo();
        //save1.saveText = "banana";
       save1.saveText = Game.playerSave.metaInfo.saveMetaInfo[0].name + "\n" + Game.playerSave.metaInfo.saveMetaInfo[0].date;
       save2.saveText = Game.playerSave.metaInfo.saveMetaInfo[1].name + "\n" + Game.playerSave.metaInfo.saveMetaInfo[1].date;
       save3.saveText = Game.playerSave.metaInfo.saveMetaInfo[2].name + "\n" + Game.playerSave.metaInfo.saveMetaInfo[2].date;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
