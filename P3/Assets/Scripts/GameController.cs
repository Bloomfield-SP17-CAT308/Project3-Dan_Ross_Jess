using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
	
	public GameObject player;
	public GameObject respawnPoint;

	public Transport teleport;

	public ParticleSystem winningParticles;

	public Text hud;
	public Canvas gameOverUI;

	//The amount of ellapsed time
	public float time = 0;

	//The amount of times player has died
	public int deaths = 0;

	//Flag for keys to win
	public int keyExp = 0;
	public int keyPlat = 0;
	private bool hasKeyExp = false;
	private bool hasKeyPlat = false;

	//The index of level currently loaded
	public int currentLevel;

	//string of level names
	private string lvlName;
	
	//Flag that control the state of the game
	//private bool isRunning = false;

	void Awake ()
	{
		if (PlayerPrefs.HasKey ("time")) {
			RestorePlayerValues ();
		} else {
			StartNewGame ();
		}
	}
    
	// Use this for initialization
	void Start ()
	{
		hud = GameObject.Find ("uiText").GetComponent<Text> ();
		currentLevel = SceneManager.GetActiveScene ().buildIndex;
		InitGame ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		string hudInfo = "";
		lvlName = "";

		time += Time.deltaTime;

		lvlName = "Level Hub";

		if (currentLevel == 2) {
			lvlName = "Platforming";
		}

		if (currentLevel == 3) {
			lvlName = "Exploring";
		} 
			

		hudInfo += "Location: " + (lvlName) + "\n";
		hudInfo += "Deaths: " + deaths + "\n";
		//hudInfo += "Time: " + time.ToString ("F2");

		hud.text = hudInfo;

		/*if (Input.GetAxis ("Restart") > 0) {
			RespawnPlayer ();
		}*/

		/*if (keyExp == 1)
			hasKeyExp = true;

		if (keyPlat == 1)
			hasKeyPlat = true;*/

		if (Input.GetKeyDown (KeyCode.P)) {
			GetKeyPlat ();
			Debug.Log ("Platform Key Get");
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			GetKeyExp ();
			Debug.Log ("Explore Key Get");
		}

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			currentLevel = 1;
			Debug.Log ("Loading Hub");
			LoadLevel ();
		}
	}

	public void StartNewGame ()
	{
		if (PlayerPrefs.HasKey ("time")) {
			DeletePlayerValues ();
		}
		time = 0;
		deaths = 0;
		currentLevel = 0;
		keyExp = 0;
		keyPlat = 0;
		StorePlayerValues ();
	}

	public void AddDeath ()
	{
		deaths++;
	}

	public void GetKeyExp ()
	{
		keyExp = 1;
		hasKeyExp = true;
	}

	public void GetKeyPlat ()
	{
		keyPlat = 1;
		hasKeyPlat = true;
	}

	public bool HasKeyExplore ()
	{
		return hasKeyExp;
	}

	public bool HasKeyPlatform ()
	{
		return hasKeyPlat;
	}

	public void RespawnPlayer ()
	{
		player.gameObject.transform.position = respawnPoint.transform.position;
	}

	public void InitGame ()
	{
		hasKeyExp = false;
		hasKeyPlat = false;
		//isRunning = true;
		//RespawnPlayer ();
	}

	public void ChangeLevel (int level)
	{
		Debug.Log ("Have level");
		currentLevel = level;
		LoadLevel ();
	}

	private void LoadLevel ()
	{
		Debug.Log ("Loading level");
		StorePlayerValues ();
		SceneManager.LoadScene (currentLevel);
		Debug.Log ("Level Loaded");
	}

	public void Win ()
	{
		DeletePlayerValues ();
		//isRunning = false;
		//SceneManager.LoadScene(3);
		//gameOverUI.enabled = true;
		//winningParticles.Play();
	}

	void StorePlayerValues ()
	{
		PlayerPrefs.SetInt ("deaths", deaths);
		PlayerPrefs.SetFloat ("time", time);
		PlayerPrefs.SetInt ("currentLevel", currentLevel);
		PlayerPrefs.SetInt ("keyExp", keyExp);
		PlayerPrefs.SetInt ("keyPlat", keyPlat);
	}

	void RestorePlayerValues ()
	{
		deaths = PlayerPrefs.GetInt ("deaths");
		time = PlayerPrefs.GetFloat ("time");
		currentLevel = PlayerPrefs.GetInt ("currentLevel");
		keyExp = PlayerPrefs.GetInt ("keyExp");
		keyPlat = PlayerPrefs.GetInt ("keyPlat");
	}

	static public void DeletePlayerValues ()
	{
		PlayerPrefs.DeleteKey ("deaths");
		PlayerPrefs.DeleteKey ("time");
		PlayerPrefs.DeleteKey ("currentLevel");
		PlayerPrefs.DeleteKey ("keyExp");
		PlayerPrefs.DeleteKey ("keyPlat");
	}
}
