using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator anim;
    private Rigidbody rigid;
    private GameSceneController sceneCon;

    bool bEmoteTimer = false;
    float reload;

    public GameObject youLose;
    public EnemyController currentEnemy;
    public float forwardSpeed = 30.0f;
    public float rightSpeed = 20.0f;
    public float reloadTime = 2.0f;
    public int health = 7;

    public bool bIsPaused;

    public enum PlayerEmotes
    { None, Joy, Admire, Surprise, Fear,
        Anger, Intimidation, Sorrow, Pity};

    public PlayerEmotes currentEmote = PlayerEmotes.None;

    public enum Direction{ Left, Right, Up, Down };

    public Direction currentDirection = Direction.Right;
 
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        sceneCon = FindObjectOfType<GameSceneController>();
        youLose.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
        if (!bIsPaused)
        {
            float forward = Input.GetAxis("Horizontal");
            float right = Input.GetAxis("Vertical");

            Walking(forward, right);

            if (bEmoteTimer)
            {
                reload -= Time.deltaTime;
            }
            else
            {
                if (Input.GetButtonDown("Positive"))
                {
                    ChangeEmote(true, forward, right);
                }
                if (Input.GetButtonDown("Negative"))
                {
                    ChangeEmote(false, forward, right);
                }
            }

            if (reload <= 0)
            {
                reload = reloadTime;
                bEmoteTimer = false;
                ResetEmote();
            }

            if (health == 0)
            {
                youLose.SetActive(true);
                Destroy(gameObject);
            }
        }
        
    }

    void Walking(float forward, float right)
    {
        if (forward > 0)
        {
            currentDirection = Direction.Right;
        }
        else if (forward < 0)
        {
            currentDirection = Direction.Left;
        }
        else if (right > 0)
        {
            currentDirection = Direction.Up;
        }
        else if (right < 0)
        {
            currentDirection = Direction.Down;
        }

        Camera cam = Camera.main;
        Vector3 screenLeft = cam.ViewportToWorldPoint(new Vector3(0f, 0.5f, -cam.transform.position.z - 13));

        anim.SetFloat("WalkRight", right);
        anim.SetFloat("WalkForward", forward);            

        Vector3 newPos = transform.position + new Vector3(forward * forwardSpeed * Time.deltaTime, 0, right * rightSpeed * Time.deltaTime);
        if (newPos.z > 26) { newPos.z = 26; }
        if (newPos.z < -26) { newPos.z = -26; }
        if (newPos.x < screenLeft.x) { newPos.x = screenLeft.x; }     
        rigid.MovePosition(newPos);

      //  if (!sceneCon.spawner1.GetComponent<Renderer>().isVisible && !sceneCon.spawner2.GetComponent<Renderer>().isVisible 
       //     && !sceneCon.spawner3.GetComponent<Renderer>().isVisible && !sceneCon.spawner4.GetComponent<Renderer>().isVisible)
       // {
            Vector3 camToMove = cam.ViewportToWorldPoint(new Vector3(0.6f, 0.5f, -cam.transform.position.z - 13));
            if (newPos.x >= camToMove.x)
            {
                cam.transform.position = new Vector3(cam.transform.position.x + forward * forwardSpeed * Time.deltaTime, cam.transform.position.y, cam.transform.position.z);
            }
       // }


    }

    void ChangeEmote(bool isPositive, float forward, float right)
    {
        if (isPositive)
        {
            if (currentDirection == Direction.Right)
            {
                currentEmote = PlayerEmotes.Admire;                
                anim.SetTrigger("Admire");                
            }
            else if (currentDirection == Direction.Left)
            {
                currentEmote = PlayerEmotes.Surprise;
                anim.SetTrigger("Surprise");
            }
            else if (currentDirection == Direction.Up)
            {
                currentEmote = PlayerEmotes.Joy;
                anim.SetTrigger("Joy");
            }
            else if (currentDirection == Direction.Down)
            {
                currentEmote = PlayerEmotes.Fear;
                anim.SetTrigger("Fear");
            }
        }
        else
        {
            if (currentDirection == Direction.Right)
            {
                currentEmote = PlayerEmotes.Anger;
                anim.SetTrigger("Anger");
            }
            else if (currentDirection == Direction.Left)
            {
                currentEmote = PlayerEmotes.Intimidation;
                anim.SetTrigger("Intimidation");
            }
            else if (currentDirection == Direction.Up)
            {
                currentEmote = PlayerEmotes.Sorrow;
                anim.SetTrigger("Sorrow");
            }
            else if (currentDirection == Direction.Down)
            {
                currentEmote = PlayerEmotes.Pity;
                anim.SetTrigger("Pity");
            }
        }
        if (currentEnemy != null)
        {
            currentEnemy.EmoteHit(currentEmote);
        }
        bEmoteTimer = true;
    }

    void ResetEmote()
    {
        currentEmote = PlayerEmotes.None;
    }

    public PlayerEmotes GetCurrentEmote()
    {
        return currentEmote;
    }
       
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyController>() != null)
        {
            currentEnemy = other.GetComponent<EnemyController>();

            if(currentEmote != PlayerEmotes.None)
            {
                currentEnemy.EmoteHit(currentEmote);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EnemyController>() == currentEnemy)
        {
            currentEnemy = null;
        }
    }

    void PlayerDamageTaken()
    {
        anim.SetTrigger("GotHit");
        health--;
    }
}
