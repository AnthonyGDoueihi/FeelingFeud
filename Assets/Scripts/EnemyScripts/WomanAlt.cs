using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanAlt : EnemyController
{
    EnemyEmotes[] possibleEmotedOne;

    // Use this for initialization
    void Awake () {
        health = 1;
        emoteList = GetEmoteOrder();
        walkReloadTime = 5.0f;
        attackReload = 4.0f;
        moveSpeed = 5.0f;
    }

    List<EnemyEmotes> GetEmoteOrder()
    {
        List<EnemyEmotes> list = new List<EnemyEmotes>(health - 1);
        List<EnemyEmotes> possibleEmotedOne = new List<EnemyEmotes> { EnemyEmotes.Joy, EnemyEmotes.Admire, EnemyEmotes.Fear,
                                                                     EnemyEmotes.Sorrow, EnemyEmotes.Pity, EnemyEmotes.Singing, EnemyEmotes.Confusion };

        int randomOne = Random.Range(1, possibleEmotedOne.Count);
        list.Add(possibleEmotedOne[randomOne]);

        return list;
    }
}
