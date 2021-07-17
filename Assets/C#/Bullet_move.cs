using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bullet_move : MonoBehaviour {

    private GameObject user;
    float speed;

	// Use this for initialization
	void Start () {
        user = GameObject.Find("Body");

    }
	
	// Update is called once per frame
	void Update () {
        speed = user.transform.GetComponent<Player>().user.grade;
        this.transform.Translate(0, 10*speed, 0);
        
        if (this.transform.position.y > Screen.height)
        {
            
            Destroy(this.transform.gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("enemy"))
        {
            user.transform.GetComponent<Player>().user.erp += Random.Range(1,10);
            user.transform.GetComponent<Player>().user.score += Random.Range(1,4);

            //animation
            GameObject game1 = Instantiate((GameObject)Resources.Load("Prefab/explosions"));
            game1.transform.parent = GameObject.Find("Body").transform;
            game1.transform.position = collision.collider.transform.position;
            GameObject.Find("Main Camera").transform.GetComponent<AudioSource>().Play();
            int ccc = Random.Range(1, 20);
            if (ccc > 18)
            {
                GameObject game = Instantiate((GameObject)Resources.Load("Prefab/Life"));
                game.transform.parent = GameObject.Find("Body").transform;
                game.transform.position = collision.collider.transform.position;
            }


            Destroy(this.transform.gameObject);
            Destroy(collision.collider.transform.gameObject);
            
        }
        else if (collision.collider.tag.Equals("Boss"))
        {
            user.transform.GetComponent<Player>().user.erp += Random.Range(10,40);
            user.transform.GetComponent<Player>().user.score += Random.Range(3,10);

            //animation
            GameObject game1 = Instantiate((GameObject)Resources.Load("Prefab/explosions"));
            game1.transform.parent = GameObject.Find("Body").transform;
            game1.transform.position = collision.collider.transform.position;
            GameObject.Find("Main Camera").transform.GetComponent<AudioSource>().Play();
            GameObject game = Instantiate((GameObject)Resources.Load("Prefab/Life"));
            game.transform.parent = GameObject.Find("Body").transform;
            game.transform.position = collision.collider.transform.position;


            Destroy(this.transform.gameObject);

            collision.collider.transform.GetComponent<enemyBoss>().life -= Random.Range(1, 5);

            if (collision.collider.transform.GetComponent<enemyBoss>().life<0)
            {
                Destroy(collision.collider.transform.gameObject);
                GameObject.Find("Body").transform.GetComponent<Body>().isbool = true;
                GameObject.Find("Body").transform.GetComponent<Body>().Layer += 1;
            }
            
            
        }
        user.transform.GetComponent<Player>().ERP.transform.GetComponent<RectTransform>().sizeDelta
            = new Vector2(user.transform.GetComponent<Player>().user.erp,
            user.transform.GetComponent<Player>().ERP.transform.GetComponent<RectTransform>().sizeDelta.y);
        user.transform.GetComponent<Player>().SCORE.transform.GetComponent<Text>().text = 
            "Score:" + user.transform.GetComponent<Player>().user.score;

    }
}
