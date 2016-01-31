using UnityEngine;
using System.Collections;

public class PlayerSpawnScript : MonoBehaviour {

    public GameObject playerPrefab;

	public void SpawnPlayer()
    {
        if(playerPrefab == null || playerPrefab.tag != "Player")
        {
            Debug.Log("playerPrefab is not a player");
            return;
        }

		playerPrefab.transform.position = new Vector2(transform.position.x, transform.position.y);
        playerPrefab.transform.rotation = transform.rotation;
    }
}
