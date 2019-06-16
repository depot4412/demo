using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelResumeGameplay : MonoBehaviour
{
    public GameObject panel;

    public void OnClick()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
