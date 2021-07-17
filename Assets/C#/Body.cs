using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//设置背景移动和关数
public class Body : MonoBehaviour {

    public int Layer = 0;

    public GameObject back;
    Sprite texture2D;
    Texture2D texture2;

    int x, y;
    public int speed = 5;

    public GameObject player;

    public bool isbool = false;

    public bool pp = false;
	// Use this for initialization
	void Start () {
        texture2 = (Texture2D)Resources.Load("background1");
        
        x = Screen.width;y = texture2.height;

        player = GameObject.Find("Body");
	}
	
	// Update is called once per frame
	void Update () {

        if (isbool)
        {
            switch (Layer)
            {
                case 0:
                    {
                        texture2 = (Texture2D)Resources.Load("background1");
                        isbool = false;
                    }
                    break;
                case 1:
                    {
                        texture2 = (Texture2D)Resources.Load("background2");
                        isbool = false;
                    }
                    break;
                case 2:
                    {
                        texture2 = (Texture2D)Resources.Load("background3");
                        isbool = false;
                    }
                    break;
            }

        }

        if (!isbool)
        {
            Move();
            enemyPlaneRandom();
            Boss();
        }

    }

    //背景移动
    private void Move()
    {
        Texture2D texture = new Texture2D(texture2.width, texture2.height, TextureFormat.RGBA32, false);

        y -= speed;
        if (y <= 0)
        {
            y = texture2.height;
        }
        texture.SetPixels(0, 0, texture2.width, y,
            texture2.GetPixels(0, texture2.height - y, texture2.width,y));
        texture.SetPixels(0, y, texture2.width, texture2.height-y, texture2.GetPixels(0, 0, texture2.width, texture2.height - y));
        texture.Apply();

        Sprite sprite1 = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),new Vector2(0.5f,0.5f));
        
        back.transform.GetComponent<Image>().sprite = sprite1;

    }

    //Random produce enemy
    public void enemyPlaneRandom()
    {
        int sum = Random.Range(0, 50);
        //Debug.Log(sum);
        if (sum < 2)
        {
            for (int i = 0; i < sum; ++i)
            {
                int cc = Random.Range(1, 3);
                GameObject gameObject = Instantiate((GameObject)Resources.Load("Prefab/enemyPlane" + cc));
                gameObject.transform.parent = GameObject.Find("Body").transform;
                gameObject.transform.position = new Vector2(Random.Range(200, Screen.width - 200), Screen.height + 300);
            }
        }
           
       
       
    }

    //Boss
    public void Boss()
    {
        if (player.transform.GetComponent<Player>().user.score > 1000)
        {
            GameObject gameObject = Instantiate((GameObject)Resources.Load("Prefab/enemyPlane3"));
            gameObject.transform.parent = GameObject.Find("Body").transform;
            gameObject.transform.position = new Vector2(Random.Range(200,Screen.width-200), Screen.height-200);
            player.transform.GetComponent<Player>().user.score = 0;
        }
    }

    //supply
    //public void supply()
    //{

    //    GameObject gameObject = Instantiate((GameObject)Resources.Load(""));
    //    gameObject.transform.parent = GameObject.Find("Body").transform;
    //    gameObject.transform.position = new Vector2(Screen.width/2, Screen.height + 300);
    //}
}
