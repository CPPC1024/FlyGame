using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(0, -5, 0);

        if (this.transform.position.y < 0)
        {
            Destroy(this.gameObject);
        }
	}
}
