using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoDimentionalMovement : MonoBehaviour {
    public float speed = 5f;
    public KeyCode upKey = KeyCode.UpArrow;
    public KeyCode downKey = KeyCode.DownArrow;
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    //bullet Varibles
    public KeyCode fireKey = KeyCode.Z;
    public GameObject muzzle;
    public float bulletVelocity = 10f;
    public GameObject bullet;
    public float fireCD = 0.1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Movement
        Move(Vector3.up, upKey);
        Move(Vector3.down, downKey);
        Move(Vector3.left, leftKey);
        Move(Vector3.right, rightKey);

        //Fire bullets
        fireCD -= Time.deltaTime;
        if (Input.GetKey(fireKey) && fireCD <= 0f)
        {
            GameObject firedBullet = Instantiate(bullet, muzzle.transform.position, Quaternion.identity);
            print(firedBullet.transform.position);
            firedBullet.GetComponent<Rigidbody2D>().velocity = muzzle.transform.up * speed;
            firedBullet.transform.position = new Vector3(firedBullet.transform.position.x, 0, firedBullet.transform.position.z);
            //firedBullet.transform.LookAt(mouse);
            fireCD = 0.1f;
        }
    }

    void Move(Vector3 dir, KeyCode key)
    {
        if (Input.GetKey(key))
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }
}
