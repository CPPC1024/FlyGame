using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene_game0 : MonoBehaviour {

    public GameObject Progress_back;
    public GameObject Progress_index;
    public GameObject Text_animation;
    public int count = 1;
	// Use this for initialization
	void Start () {
        StartCoroutine("enumerator");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator enumerator()
    {
        AsyncOperation asyncOperation =  SceneManager.LoadSceneAsync("game0");
        asyncOperation.allowSceneActivation = false;

        while (true)
        {
            Debug.Log("0:"+asyncOperation.progress);
            if (asyncOperation.progress < 0.9f)
            {
                Debug.Log("1:"+asyncOperation.progress);
                Progress_index.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(
                    asyncOperation.progress * 100*Screen.width, Progress_index.transform.GetComponent<RectTransform>().sizeDelta.y);
                Text_animation.transform.GetComponent<Text>().text = "正在加载";
                for (int i = 0; i < count; ++i)
                {
                    Text_animation.transform.GetComponent<Text>().text += ".";
                }
                count++;
                if (count > 3)
                {
                    count = 1;
                }
                yield return new WaitForSeconds(1f);
            }
            else
            {
                Debug.Log("2:"+asyncOperation.progress);
                Progress_index.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(
                   Screen.width, Progress_index.transform.GetComponent<RectTransform>().sizeDelta.y);
                Text_animation.transform.GetComponent<Text>().text = "正在加载...";
                asyncOperation.allowSceneActivation = true;
                break;
            }
        }

        yield return new WaitForEndOfFrame();


    }
}
