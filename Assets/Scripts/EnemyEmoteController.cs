using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyEmoteController : MonoBehaviour {

    EnemyController enemy;
    EnemyController.EnemyEmotes currentEmote;

    RawImage image;
    Canvas[] hearts;
    public Canvas heartPrefab;
    int health;

    public Texture Joy, Admire, Surprise, Fear,
        Anger, Intimidation, Sorrow, Pity,
        Singing, Conflicted, Confusion, Dizzy,
        Idea, Tired, NoHealth;

    
    // Use this for initialization
    void Start () {
        enemy = GetComponentInParent<EnemyController>();
        image = GetComponentInChildren<RawImage>();
        health = enemy.health;
        hearts = new Canvas[health];

        print(health);

        for (int i = 0; i < health; i++)
        {            
            Vector3 position = enemy.transform.position + new Vector3(0, 23.3f + (i * 2.02f), 0);
            hearts[i] = Instantiate(heartPrefab, enemy.transform);
            hearts[i].GetComponent<RectTransform>().position = position;
        }
    }

    // Update is called once per frame
    void Update () {
        currentEmote = enemy.GetCurrentEmote();

        if (currentEmote == EnemyController.EnemyEmotes.NoHealth)
        {
            image.texture = NoHealth;
        }
        else if (currentEmote == EnemyController.EnemyEmotes.Admire)
        {
            image.texture = Admire;
        }
        else if (currentEmote == EnemyController.EnemyEmotes.Anger)
        {
            image.texture = Anger;
        }
        else if (currentEmote == EnemyController.EnemyEmotes.Conflicted)
        {
            image.texture = Conflicted;
        }
        else if (currentEmote == EnemyController.EnemyEmotes.Confusion)
        {
            image.texture = Confusion;
        }
        else if (currentEmote == EnemyController.EnemyEmotes.Dizzy)
        {
            image.texture = Dizzy;
        }
        else if (currentEmote == EnemyController.EnemyEmotes.Fear)
        {
            image.texture = Fear;
        }
        else if (currentEmote == EnemyController.EnemyEmotes.Idea)
        {
            image.texture = Idea;
        }
        else if (currentEmote == EnemyController.EnemyEmotes.Intimidation)
        {
            image.texture = Intimidation;
        }
        else if (currentEmote == EnemyController.EnemyEmotes.Joy)
        {
            image.texture = Joy;
        }
        else if (currentEmote == EnemyController.EnemyEmotes.Pity)
        {
            image.texture = Pity;
        }
        else if (currentEmote == EnemyController.EnemyEmotes.Singing)
        {
            image.texture = Singing;
        }
        else if (currentEmote == EnemyController.EnemyEmotes.Sorrow)
        {
            image.texture = Sorrow;
        }
        else if (currentEmote == EnemyController.EnemyEmotes.Surprise)
        {
            image.texture = Surprise;
        }
        else if (currentEmote == EnemyController.EnemyEmotes.Tired)
        {
            image.texture = Tired;
        }               

    }

    void DamageTaken()
    {
        Destroy(hearts[health - 1].gameObject);
        health--;
    }

}
