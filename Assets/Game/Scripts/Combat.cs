using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {

    public const int maxHealth = 100;
    public int health = maxHealth;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health < 0)
        {
            health = 0;
            Debug.Log("Dead!");
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
