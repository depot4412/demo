using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSmallStats : MonoBehaviour
{
    PlayerEntity player = Game.instance.player;
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<TextMeshProUGUI>();
        Debug.Log("this objects text " + text.text);
        StartCoroutine(UpdateStats());
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    IEnumerator UpdateStats()
    {
        text.SetText(player.Name + "\n" + "Level:" + player.Level + "\n" + "HP: " + player.CurrentLife + "/" + player.MaxLife);
        yield return new WaitForSeconds(0.25f);
    }
}
