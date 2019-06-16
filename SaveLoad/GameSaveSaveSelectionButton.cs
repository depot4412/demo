using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSaveSaveSelectionButton : MonoBehaviour
{
    public int loadGame;
    public string saveText;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        this.gameObject.GetComponentInChildren<Text>().text = saveText;
    }

    public void OnClick()
    {
            Game.playerSave.SaveData(loadGame);

        Game.playerSave.metaInfo.GetSaveInfo();
        saveText = Game.playerSave.metaInfo.saveMetaInfo[loadGame].name + "\n" + Game.playerSave.metaInfo.saveMetaInfo[loadGame].date;
    }
    // Update is called once per frame
    void Update()
    {
        //bad
        this.gameObject.GetComponentInChildren<Text>().text = saveText;
    }
}
