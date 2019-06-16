using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game : MonoBehaviour {

    public static Game instance = null;
    // public GameManager currentGameManager;
    public static PlayerSave playerSave;
    public static SceneTransitionManager sceneTransitionManager;
    public PlayerEntity player;
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        sceneTransitionManager = gameObject.AddComponent(typeof(SceneTransitionManager)) as SceneTransitionManager;
        playerSave = gameObject.GetComponentInChildren(typeof(PlayerSave)) as PlayerSave;

    }

        void Start()
    {
        
    }



}