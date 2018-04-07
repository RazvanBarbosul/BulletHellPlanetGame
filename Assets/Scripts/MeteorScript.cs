using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour {

    public GravityBody meteor;
    public PlayerMovementTest player;

	// Use this for initialization
	void Start () {
        SpawnMeteor();
	}
	
	// Update is called once per frame
	void Update () {
        // SpawnMeteor();
        int Chance = Random.Range(0, 51);

        if(Chance == 0)
        {
          //  SpawnMeteor();
        }
    }

    public void SpawnMeteor()
    {
       player.meteorPrefab = Instantiate(meteor,transform);
    }
}
