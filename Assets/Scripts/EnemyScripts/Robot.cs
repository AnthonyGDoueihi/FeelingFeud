using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : EnemyController
{
    EnemyEmotes[] possibleEmotedOne;
    EnemyEmotes[] possibleEmotedTwo;
    EnemyEmotes[] possibleEmotedThree;
    EnemyEmotes[] possibleEmotedFour;

    // Use this for initialization
    void Awake()
    {
        health = 4;
        emoteList = GetEmoteOrder();
        walkReloadTime = 5.0f;
        attackReload = 4.0f;
        moveSpeed = 5.0f;
    }

    List<EnemyEmotes> GetEmoteOrder()
    {
        List<EnemyEmotes> list = new List<EnemyEmotes>(health - 1);

        list.Add(EnemyEmotes.Dizzy);
        list.Add(EnemyEmotes.Surprise);
        list.Add(EnemyEmotes.Confusion);
        list.Add(EnemyEmotes.Idea);

        return list;
    }
}