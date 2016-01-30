using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public PlayerSpawnScript playerSpawn;

	// Use this for initialization
	void Start () {
	    gameObject.transform.rotation = Quaternion.identity;
        playerSpawn.SpawnPlayer();
    }
	
	public void RestartLevel()
    {
        Start();
    }
}
