using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable()]
public class SaveMetaInfo
{ 

    public string name;
    public string date;

   public SaveMetaInfo()
    {
        name = "Empty";
        date = "Empty";
    }
    public void SaveCurrentGame()
    {
        name = Game.instance.player.Name;
        date = DateTime.Now.ToLongTimeString() +"\n" + DateTime.Now.ToLongDateString();
    }
}
