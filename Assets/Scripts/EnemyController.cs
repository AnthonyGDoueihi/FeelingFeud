using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Animator anim;
    private Rigidbody rigid;
    PlayerController player;

    public int health;
    public float walkReloadTime;
    public float attackReload;
    public float moveSpeed;
    float deathTimer = 2.0f;
    float animReaload = 5.0f; 
    float walkCount;
    float attackCount = 4.0f;
    float animCount;
    Vector3 moveLocation;

    public enum EnemyEmotes
    {
        Joy, Admire, Surprise, Fear,
        Anger, Intimidation, Sorrow, Pity,
        Singing, Conflicted, Confusion, Dizzy,
        Idea, Tired, NoHealth
    };

    public EnemyEmotes currentEnemyEmotes;
    public List<EnemyEmotes> emoteList;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
        rigid = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update () {           
        
        if (health == 0)
        {
            anim.StopPlayback();
            currentEnemyEmotes = EnemyEmotes.NoHealth;
            Destroy(GetComponent<CapsuleCollider>());
            GetComponent<Rigidbody>().useGravity = true;
            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            currentEnemyEmotes = emoteList[health - 1];

            walkCount -= Time.deltaTime;

            if (player.currentEnemy == this)
            {
                attackCount -= Time.deltaTime;
                if (attackCount <= 0.6f)
                {
                    anim.SetTrigger("EnemyAttack");
                }

                if (attackCount <= 0)
                {
                    attackCount = attackReload;
                    Attack();
                }
            }

            if (Vector3.Distance(transform.position, player.transform.position) >= 30.0f)
            {
                Wander();
            }
            else
            {
                Target();
            }


            animCount -= Time.deltaTime;
            if (animCount <= 0)
            {
                animCount = Random.Range(1.0f, animReaload);
                Animate();
            }
        }


    }

    public void EmoteHit(PlayerController.PlayerEmotes emote)
    {        
        if (currentEnemyEmotes == EnemyEmotes.Admire)
        {
            if (emote == PlayerController.PlayerEmotes.Anger || emote == PlayerController.PlayerEmotes.Intimidation
                || emote == PlayerController.PlayerEmotes.Sorrow || emote == PlayerController.PlayerEmotes.Pity)
            {
                BroadcastMessage("DamageTaken");
            }
        }
        else if (currentEnemyEmotes == EnemyEmotes.Anger)
        {
            if (emote == PlayerController.PlayerEmotes.Fear || emote == PlayerController.PlayerEmotes.Sorrow || emote == PlayerController.PlayerEmotes.Pity)
            {
                BroadcastMessage("DamageTaken");
            }
        }
        else if (currentEnemyEmotes == EnemyEmotes.Conflicted)
        {
            if (emote == PlayerController.PlayerEmotes.Joy || emote == PlayerController.PlayerEmotes.Admire
                || emote == PlayerController.PlayerEmotes.Surprise || emote == PlayerController.PlayerEmotes.Fear)
            {
                BroadcastMessage("DamageTaken");
            }
        }
        else if (currentEnemyEmotes == EnemyEmotes.Confusion)
        {
            if (emote == PlayerController.PlayerEmotes.Fear)
            {
                BroadcastMessage("DamageTaken");
            }
        }
        else if (currentEnemyEmotes == EnemyEmotes.Dizzy)
        {
            BroadcastMessage("DamageTaken");
        }
        else if (currentEnemyEmotes == EnemyEmotes.Fear)
        {
            if (emote == PlayerController.PlayerEmotes.Intimidation)
            {
                BroadcastMessage("DamageTaken");
            }
        }
        else if (currentEnemyEmotes == EnemyEmotes.Idea)
        {
            if (emote == PlayerController.PlayerEmotes.Joy || emote == PlayerController.PlayerEmotes.Admire
                || emote == PlayerController.PlayerEmotes.Surprise || emote == PlayerController.PlayerEmotes.Fear)
            {
                BroadcastMessage("DamageTaken");
            }

        }
        else if (currentEnemyEmotes == EnemyEmotes.Intimidation)
        {
            if (emote == PlayerController.PlayerEmotes.Fear)
            {
                BroadcastMessage("DamageTaken");
            }
        }
        else if (currentEnemyEmotes == EnemyEmotes.Joy)
        {
            if (emote == PlayerController.PlayerEmotes.Joy || emote == PlayerController.PlayerEmotes.Admire || emote == PlayerController.PlayerEmotes.Sorrow
               || emote == PlayerController.PlayerEmotes.Surprise || emote == PlayerController.PlayerEmotes.Fear)
            {
                BroadcastMessage("DamageTaken");
            }
        }
        else if (currentEnemyEmotes == EnemyEmotes.Pity)
        {
            if (emote == PlayerController.PlayerEmotes.Anger || emote == PlayerController.PlayerEmotes.Intimidation || emote == PlayerController.PlayerEmotes.Admire
                || emote == PlayerController.PlayerEmotes.Sorrow || emote == PlayerController.PlayerEmotes.Pity )
            {
                BroadcastMessage("DamageTaken");
            }
        }
        else if (currentEnemyEmotes == EnemyEmotes.Singing)
        {
            if (emote == PlayerController.PlayerEmotes.Joy || emote == PlayerController.PlayerEmotes.Admire)
            {
                BroadcastMessage("DamageTaken");
            }
        }
        else if (currentEnemyEmotes == EnemyEmotes.Sorrow)
        {
            if (emote == PlayerController.PlayerEmotes.Joy || emote == PlayerController.PlayerEmotes.Admire
                || emote == PlayerController.PlayerEmotes.Surprise || emote == PlayerController.PlayerEmotes.Fear
                || emote == PlayerController.PlayerEmotes.Intimidation || emote == PlayerController.PlayerEmotes.Sorrow)
            {
                BroadcastMessage("DamageTaken");
            }
        }
        else if (currentEnemyEmotes == EnemyEmotes.Surprise)
        {
            if (emote == PlayerController.PlayerEmotes.Surprise || emote == PlayerController.PlayerEmotes.Joy)
            {
                BroadcastMessage("DamageTaken");
            }
        }
        else if (currentEnemyEmotes == EnemyEmotes.Tired)
        {
            if (emote == PlayerController.PlayerEmotes.Joy || emote == PlayerController.PlayerEmotes.Pity)
            {
                BroadcastMessage("DamageTaken");      
            }
        }
    }

    void Animate()
    {
        if (currentEnemyEmotes == EnemyEmotes.Admire)
        {
            anim.SetTrigger("Admire");
        }
        else if (currentEnemyEmotes == EnemyEmotes.Anger)
        {
            anim.SetTrigger("Anger");
        }
        else if (currentEnemyEmotes == EnemyEmotes.Conflicted)
        {
            anim.SetTrigger("Admire");
        }
        else if (currentEnemyEmotes == EnemyEmotes.Confusion)
        {
            anim.SetTrigger("Admire");
        }
        else if (currentEnemyEmotes == EnemyEmotes.Dizzy)
        {
            anim.SetTrigger("Sorrow");
        }
        else if (currentEnemyEmotes == EnemyEmotes.Fear)
        {
            anim.SetTrigger("Fear");
        }
        else if (currentEnemyEmotes == EnemyEmotes.Idea)
        {
            anim.SetTrigger("Admire");
        }
        else if (currentEnemyEmotes == EnemyEmotes.Intimidation)
        {
            anim.SetTrigger("Intimidation");
        }
        else if (currentEnemyEmotes == EnemyEmotes.Joy)
        {
            anim.SetTrigger("Joy");
        }
        else if (currentEnemyEmotes == EnemyEmotes.Pity)
        {
            anim.SetTrigger("Pity");
        }
        else if (currentEnemyEmotes == EnemyEmotes.Singing)
        {
            anim.SetTrigger("Joy");
        }
        else if (currentEnemyEmotes == EnemyEmotes.Sorrow)
        {
            anim.SetTrigger("Sorrow");
        }
        else if (currentEnemyEmotes == EnemyEmotes.Surprise)
        {
            anim.SetTrigger("Surprise");
        }
        else if (currentEnemyEmotes == EnemyEmotes.Tired)
        {
            anim.SetTrigger("Pity");
        }
    }


    public EnemyEmotes GetCurrentEmote()
    {
        return currentEnemyEmotes;
    }

    void DamageTaken()
    {
        anim.SetTrigger("GotHit");
        attackCount = attackReload;
        animCount = 0.1f;
        health--;
    }

    void Wander()
    {

        if (walkCount <= 0)
        {
            float zLoc = Random.Range(-26.0f, 26.0f);
            float xChange = Random.Range(-10.0f, 0.0f);
            moveLocation = new Vector3(transform.position.x + xChange, transform.position.y, zLoc);            
            walkCount = walkReloadTime;
        }

        AnimateMove();
        rigid.MovePosition(Vector3.MoveTowards(transform.position, moveLocation, moveSpeed * Time.deltaTime));

    }

    void Target()
    {
        moveLocation = player.transform.position + new Vector3(20, 0, 0);
        AnimateMove();
        rigid.MovePosition(Vector3.MoveTowards(transform.position, moveLocation, moveSpeed * Time.deltaTime));
    }

    void AnimateMove()
    {
        Vector3 normal = Vector3.Normalize(moveLocation - transform.position);

        anim.SetFloat("WalkRight", normal.z);
        anim.SetFloat("WalkForward", normal.x);
    }

    void Attack()
    {
        player.BroadcastMessage("PlayerDamageTaken");
    }
}
