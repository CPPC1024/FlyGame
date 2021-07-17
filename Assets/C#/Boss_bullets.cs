using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_bullets : MonoBehaviour {

    public float Speed = 13f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.RotateAround(this.transform.parent.transform.position, Vector3.up, 2f);
        this.transform.Translate(0, -Speed, 0);
	}


}
