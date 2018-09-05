using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEmoteController : MonoBehaviour {

    PlayerController player;
    PlayerController.PlayerEmotes currentEmote;

    RawImage image;
    Canvas[] hearts;
    public Canvas heartPrefab;
    int health;

    public Texture Joy, Admire, Surprise, Fear, Anger, Intimidation, Sorrow, Pity ;

	// Use this for initialization
	void Start () {
        player = GetComponentInParent<PlayerController>();
        image = GetComponentInChildren<RawImage>();
        health = player.health;
        hearts = new Canvas[health];

        for (int i = 0; i < health; i++)
        {
            Vector3 position = player.transform.position + new Vector3(0, 23.3f + (i * 2.02f), 0);
            hearts[i] = Instantiate(heartPrefab, player.transform);
            hearts[i].GetComponent<RectTransform>().position = position;
        }
    }
	
	// Update is called once per frame
	void Update () {
        currentEmote = player.GetCurrentEmote();

        if (currentEmote == PlayerController.PlayerEmotes.None)
        {
            image.enabled = false;
        }
        else if (currentEmote == PlayerController.PlayerEmotes.Joy)
        {
            image.enabled = true;
            image.texture = Joy;
        }
        else if (currentEmote == PlayerController.PlayerEmotes.Admire)
        {
            image.enabled = true;
            image.texture = Admire;
        }
        else if (currentEmote == PlayerController.PlayerEmotes.Surprise)
        {
            image.enabled = true;
            image.texture = Surprise;
        }
        else if (currentEmote == PlayerController.PlayerEmotes.Fear)
        {
            image.enabled = true;
            image.texture = Fear;
        }
        else if (currentEmote == PlayerController.PlayerEmotes.Anger)
        {
            image.enabled = true;
            image.texture = Anger;
        }
        else if (currentEmote == PlayerController.PlayerEmotes.Intimidation)
        {
            image.enabled = true;
            image.texture = Intimidation;
        }
        else if (currentEmote == PlayerController.PlayerEmotes.Sorrow)
        {
            image.enabled = true;
            image.texture = Sorrow;
        }
        else if (currentEmote == PlayerController.PlayerEmotes.Pity)
        {
            image.enabled = true;
            image.texture = Pity;
        }

    }

    void PlayerDamageTaken()
    {
        Destroy(hearts[health - 1].gameObject);
        health--;
    }
}
