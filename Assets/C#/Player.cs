using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {

    public User user;

    public Sprite[] play0 = new Sprite[3];




    /// <summary>
    /// HP
    /// </summary>
    public GameObject HP;
    /// <summary>
    /// ERP
    /// </summary>
    public GameObject ERP;
    /// <summary>
    /// SCORE
    /// </summary>
    public GameObject SCORE;




	// Use this for initialization
	void Start () {
        user = new User();
        user.erp = 0;
        user.hp = 200;
        user.grade = 1;
        GameObject gameObject = Instantiate((GameObject)Resources.Load("Prefab/Player"));
        gameObject.transform.parent = GameObject.Find("Body").transform;
        gameObject.transform.position = new Vector3(Screen.width / 2, Screen.height / 2);
        user.player = gameObject;

        HP.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(user.hp, HP.transform.GetComponent<RectTransform>().sizeDelta.y);
        ERP.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(user.erp, ERP.transform.GetComponent<RectTransform>().sizeDelta.y);

    }

    // Update is called once per frame
    void Update () {
        Move();
        GradeUp();

    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            user.player.transform.Translate(-10, 0, 0);
        }else if (Input.GetKey(KeyCode.S))
        {
            user.player.transform.Translate(0, -10, 0);
        }else if (Input.GetKey(KeyCode.D))
        {
            user.player.transform.Translate(10, 0, 0);
        }else if (Input.GetKey(KeyCode.W))
        {
            user.player.transform.Translate(0, 10, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("bullet");
        }
    }

    IEnumerator bullet()
    {
        yield return new WaitForSeconds(1f);
        GameObject bullet = Instantiate((GameObject)Resources.Load("Prefab/bullet"));
        bullet.transform.parent = GameObject.Find("Body").transform;
        bullet.transform.position = user.player.transform.GetChild(0).transform.position;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag.Equals("enemy"))
        {
            Debug.Log("enemy");
            user.hp -= Random.Range(1,3);

            //animation
            GameObject game = (GameObject)Instantiate(Resources.Load("Prefab/explosions"));

            game.transform.parent = GameObject.Find("Body").transform;
            game.transform.position = collision.collider.transform.position;
            GameObject.Find("Main Camera").transform.GetComponent<AudioSource>().Play();


            Destroy(collision.collider.transform.gameObject);
            
        }else if (collision.collider.tag.Equals("Boss")) {
            user.hp -= Random.Range(5,30);

            //animation
            GameObject game = Instantiate((GameObject)Resources.Load("Prefab/explosions"));
            game.transform.parent = GameObject.Find("Body").transform;
            game.transform.position = collision.collider.transform.position;
            GameObject.Find("Main Camera").transform.GetComponent<AudioSource>().Play();
            Destroy(collision.collider.transform.gameObject);
            
            
        }
        else if (collision.collider.tag.Equals("enemybullet"))
        {
            user.hp -= Random.Range(5,30);

            //animation
            GameObject game = (GameObject)Instantiate(Resources.Load("Prefab/explosions"));
            game.transform.parent = GameObject.Find("Body").transform;
            game.transform.position = collision.collider.transform.position;
            GameObject.Find("Main Camera").transform.GetComponent<AudioSource>().Play();
            Destroy(collision.collider.transform.gameObject);
        }
        else if (collision.collider.tag.Equals("Bossbullet"))
        {
            user.hp -= Random.Range(5, 30);

            //animation
            GameObject game = Instantiate((GameObject)Resources.Load("Prefab/explosions"));
            game.transform.parent = GameObject.Find("Body").transform;
            game.transform.position = collision.collider.transform.position;
            GameObject.Find("Main Camera").transform.GetComponent<AudioSource>().Play();

            Destroy(collision.collider.transform.gameObject);
        }
        else if (collision.collider.tag.Equals("supply"))
        {
            user.hp = (200 - user.hp%200) < 20 ? 200 : user.hp+20;
            
            Destroy(collision.collider.transform.gameObject);
        }

        if (user.hp < 0)
        {
            SceneManager.LoadScene("result");
            DontDestroyOnLoad(GameObject.Find("Audio"));
        }


        HP.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(user.hp, HP.transform.GetComponent<RectTransform>().sizeDelta.y);
        ERP.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(user.erp, ERP.transform.GetComponent<RectTransform>().sizeDelta.y);
        SCORE.transform.GetComponent<Text>().text = "Score:" + user.score;

    }

    //升级
    void GradeUp()
    {
        if (user.erp/200>1)
        {
            user.erp = user.erp-200;
            user.grade++;
            if (user.grade==1)
            {
                user.player.transform.GetComponent<Image>().sprite = play0[0];
            }
            else if (user.grade == 2)
            {
                user.player.transform.GetComponent<Image>().sprite = play0[1];
            }
            else if (user.grade == 3)
            {
                user.player.transform.GetComponent<Image>().sprite = play0[2];
            }
            
            ERP.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(user.erp, ERP.transform.GetComponent<RectTransform>().sizeDelta.y);

        }
       
    }
}
