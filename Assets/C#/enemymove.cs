using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour {

    public float speed = 5;
	// Use this for initialization
	void Start () {
        InvokeRepeating("bullets", 10, 10);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(0, -speed, 0);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void bullets()
    {
        if (Random.Range(0, 10) > 7)
        {
            GameObject gameObject = Instantiate((GameObject)Resources.Load("Prefab/enemybullet"));
            gameObject.transform.parent = GameObject.Find("Body").transform;
            gameObject.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 100);
        }
    }
}
