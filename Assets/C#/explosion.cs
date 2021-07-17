using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {


	// Use this for initialization
	void Start () {
        StartCoroutine("enumerator");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(1f);

        Destroy(this.transform.gameObject);
    }
}
