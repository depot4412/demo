using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attaching this to a gameobject preserves it through scenes and it becomes a singleton.
/// </summary>
public class SingletonObject : MonoBehaviour {

    private static SingletonObject instance = null;

    public static SingletonObject Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
