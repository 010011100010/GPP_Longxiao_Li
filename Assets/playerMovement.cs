using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    public float speed = 1f;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    //bullet Varibles
    public KeyCode fireKey = KeyCode.Mouse0;
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
        Move(Vector3.back, upKey);
        Move(Vector3.forward, downKey);
        Move(Vector3.left, leftKey);
        Move(Vector3.right, rightKey);

        //Mouse look
        Vector3 mouse = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, transform.position.y));
        Vector3 forward = mouseWorld - transform.position;
        transform.rotation = Quaternion.LookRotation(-forward, Vector3.up);

        //Fire bullets
        fireCD -= Time.deltaTime;
        if (Input.GetKey(fireKey) && fireCD<=0f)
        {
            GameObject firedBullet = Instantiate(bullet, muzzle.transform.position, Quaternion.identity);
            print(firedBullet.transform.position);
            firedBullet.GetComponent<Rigidbody>().velocity = -muzzle.transform.forward * speed;
            firedBullet.transform.position = new Vector3(firedBullet.transform.position.x, 0, firedBullet.transform.position.z);
            //firedBullet.transform.LookAt(mouse);
            fireCD = 0.5f;
        }
        print("muzzle position: " + muzzle.transform.position + "player position: " + transform.position);
    }

    protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    void Move(Vector3 dir, KeyCode key)
    {
        if (Input.GetKey(key))
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }
}
