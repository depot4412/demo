using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoadSaveSelectionButton : MonoBehaviour
{
    public int saveGame;
    public string saveText;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponentInChildren<Text>().text = saveText;
    }

    public void OnClick()
    {
        if(saveText != "Empty\nEmpty")
        Game.playerSave.LoadData(saveGame);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
