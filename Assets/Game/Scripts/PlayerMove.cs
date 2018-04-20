using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour {

    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
		
	}

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    [Command]
    void CmdFire()
    {
        // This [Command] code runs on the server!

        //create the bullet object locally
        var bullet = (GameObject)Instantiate(bulletPrefab, transform.position - transform.forward, Quaternion.identity);

        //make the bullet move away in front of the player
        bullet.GetComponent<Rigidbody>().velocity = -transform.forward * 4.0f;

        //spawn the bullet on the clients
        NetworkServer.Spawn(bullet);

        //make the bullet disappear after 2 seconds
        Destroy(bullet, 2.0f);
    }

    // Update is called once per frame
    void Update ()
    {
        // see if player is local to device
        if (!isLocalPlayer)
            return;

        // Basic key movement based on arrow keys
        var x = Input.GetAxis("Horizontal") * 0.1f;
        var z = Input.GetAxis("Vertical") * 0.1f;

        transform.Translate(x, 0, z);

        // fire a bullet if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
	}

    // Fire function for non-network functionality
    /*public void Fire()
    {
        // create the bullet object from the bullet Prefab
        var bullet = (GameObject)Instantiate(bulletPrefab, transform.position - transform.forward, Quaternion.identity);

        //make the bullet move away in front of the player
        bullet.GetComponent<Rigidbody>().velocity = -transform.forward * 4.0f;

        //make the bullet disappear after 2 seconds
        Destroy(bullet, 2.0f);
    }*/
}
