//GET THE LISTS FROM EACH EQUIP AND INV AND ASSIGN THEM SEPARATELY



using Newtonsoft.Json;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerSave : MonoBehaviour {
	
	[SerializeField]
	public static PlayerSave Instance;

	public bool IsSceneBeingLoaded = false;

    public SaveMetaInfoManager metaInfo = new SaveMetaInfoManager();


	[System.Serializable]
	public struct PlayerInfo  {
		public string Name;
		public string Description;
		public int MaxLife;
		public int CurrentLife;
		public int ExperienceGiven;
		public int Level;
		public int MoveSpeed;
		public int Gold;
		public int Damage;
		public int OptimalRange;
		public int MaxRange;
		public float AttackSpeed;

		public List<Skill> skills;
		//public CharacterEquipment equipment;
		public string Inventory;

	}
	[SerializeField]
	public PlayerInfo playerInfo;

	[SerializeField]
	private string locationName;

	[SerializeField]
	public SkillManager skills;

	[SerializeField]
    public BaseInventory equip;
	[SerializeField]
    public BaseInventory inv;

	[SerializeField]
	public PlayerEntity player;


	private JsonSerializer serializer = new JsonSerializer();


	public string LocationName
	{
		get
		{
			return this.locationName;
		}
		set
		{
			this.locationName = value;
		}
	}
		


	public PlayerSave(){
		locationName = "Town";
		//skills = new SkillManager();

	}

	void Start()
	{

		playerInfo = new PlayerInfo();

		playerInfo.Name = "Ogre";
		playerInfo.Description = "Just a normal monster";
		playerInfo.MaxLife = 100;
		playerInfo.CurrentLife = 100;
		playerInfo.ExperienceGiven = 100;
		playerInfo.Level = 1;
		playerInfo.MoveSpeed = 10;
		playerInfo.Gold = 20;
		playerInfo.Damage = 15;
		playerInfo.OptimalRange = 1;
		playerInfo.MaxRange = 5;
		playerInfo.AttackSpeed = 1.5f;


		JsonConvert.DefaultSettings = () => new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.All,
		};
	}

	void Awake(){
        player = GameObject.Find("PlayerParty/Player1").GetComponent<PlayerEntity>();
        // player = this.player.GetComponent<PlayerEntity>();
        /*
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	

		//inv = GameObject.Find("GUI/CharacterInventory/InventoryPanel").GetComponent<CharacterInventory>();
		player = GameObject.Find("PlayerParty/Player1").GetComponent<PlayerEntity>();
		//equip = GameObject.Find("GUI/CharacterInventory/EquipmentPanel").GetComponent<CharacterEquipment>();

    */
    }
		
	void Update()

	{
		if(Input.GetKey(KeyCode.F5))
		{
			//if(IsSceneBeingLoaded == false)
			//{
			this.SaveData(1);
			//	IsSceneBeingLoaded = true;
			//}
		}
	
if(Input.GetKey(KeyCode.F5))
		{
			//if(IsSceneBeingLoaded == false)
			//{
			this.SaveData(1);
			//	IsSceneBeingLoaded = true;
			//}
		}
		
		if(Input.GetKey(KeyCode.F9))
		{
			//if(IsSceneBeingLoaded == true)
			//{
			this.LoadData(1);
			//IsSceneBeingLoaded = false;
			//}
		}

        if (Input.GetKey(KeyCode.F3))
        {
            //if(IsSceneBeingLoaded == true)
            //{
            player.inv.items.Clear();
            //IsSceneBeingLoaded = false;
            //}
        }

    }


		

	public void SaveData(int saveNumber)
	{
        metaInfo.SaveCurrentGame(saveNumber);

		BinaryFormatter formatter = new BinaryFormatter();

		FileStream saveFile = File.Create(Application.persistentDataPath + "save" + saveNumber + ".binary");

        Debug.Log("Saving to " + Application.persistentDataPath);



		playerInfo.Name = player.Name;
		playerInfo.Description = player.Description;
		playerInfo.MaxLife = player.MaxLife;
		playerInfo.CurrentLife = player.CurrentLife;
		playerInfo.ExperienceGiven = player.ExperienceGiven;
		playerInfo.Level = player.Level;
		playerInfo.MoveSpeed = player.MoveSpeed;
		playerInfo.Damage = player.Damage;
		playerInfo.OptimalRange = player.OptimalRange;
		playerInfo.MaxRange = player.MaxRange;
		playerInfo.AttackSpeed = player.AttackSpeed;



		JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead};

		playerInfo.Inventory = JsonConvert.SerializeObject(inv.items, settings);





		formatter.Serialize(saveFile, playerInfo);

		saveFile.Close();
	}



	public void LoadData(int saveNumber)
	{

		Debug.Log(Application.persistentDataPath);
		SceneManager.LoadScene("Town");


	


		BinaryFormatter formatter = new BinaryFormatter();
		FileStream saveFile = File.Open(Application.persistentDataPath + "save" + saveNumber + ".binary", FileMode.Open);

		playerInfo = (PlayerInfo)formatter.Deserialize(saveFile);



		player.Name = playerInfo.Name;
		player.Description = playerInfo.Description;
		player.MaxLife = playerInfo.MaxLife;
		player.CurrentLife = playerInfo.CurrentLife;
		player.ExperienceGiven = playerInfo.ExperienceGiven;
		player.Level = playerInfo.Level;
		player.MoveSpeed = playerInfo.MoveSpeed;
		player.Damage = playerInfo.Damage;
		player.OptimalRange = playerInfo.OptimalRange;
		player.MaxRange = playerInfo.MaxRange;
		player.AttackSpeed = playerInfo.AttackSpeed;
		player.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-50f, 48.89705f, 5f);



		var obj = JsonConvert.DeserializeObject<List<Slot>>(playerInfo.Inventory);

        foreach(Slot s in obj)
        {
            player.inv.items[s.pos].item = s.item;
        }
        player.inv.Updated.Invoke();


        //player.inv.ClearAllInventorySlots();


		


		saveFile.Close();
	}
		

}