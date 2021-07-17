using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBoss : MonoBehaviour {

    public float life = 100;

    private bool p = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x < 100)
        {
            p = true;
        }
        else if(this.transform.position.x+100>Screen.width)
        {
            p = false;
        }

        if (p)
        {
            this.transform.Translate(10, 0, 0);
        }
        else
        {
            this.transform.Translate(-10, 0, 0);
        }


        int cc = Random.Range(1, 10);
        if (cc > 8)
        {
            GameObject gameObject = Instantiate((GameObject)Resources.Load("Prefab/GameObject"));
            gameObject.transform.parent = GameObject.Find("Body").transform;
            gameObject.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 100);
        }
	}
}
