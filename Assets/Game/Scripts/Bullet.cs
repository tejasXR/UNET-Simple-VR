using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        // If a bullet hits a player, destroy the bullet
        var hit = collision.gameObject;
        var hitPlayer = hit.GetComponent<PlayerMove>();
        if(hitPlayer != null)
        {
            //if the colliding player object is not null, then lower the player's health
            var combat = hit.GetComponent<Combat>();
            combat.TakeDamage(10);
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
