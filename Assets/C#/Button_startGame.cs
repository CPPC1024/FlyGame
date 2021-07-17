using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button_startGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void click()
    {
        SceneManager.LoadScene("Progress_bar");
        DontDestroyOnLoad(GameObject.Find("Audio"));

    }
        
   
}
