using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : EnemyController
{
    EnemyEmotes[] possibleEmotedOne;
    EnemyEmotes[] possibleEmotedTwo;

    // Use this for initialization
    void Awake () {
        health = 2;
        emoteList = GetEmoteOrder();
        walkReloadTime = 5.0f;
        attackReload = 4.0f;
        moveSpeed = 5.0f;
    }

    List<EnemyEmotes> GetEmoteOrder()
    {
        List<EnemyEmotes> list = new List<EnemyEmotes>(health - 1);
        List<EnemyEmotes> possibleEmotedTwo = new List<EnemyEmotes> { EnemyEmotes.Intimidation, EnemyEmotes.Anger};

        list.Add(EnemyEmotes.Joy);

        int randomTwo = Random.Range(1, possibleEmotedTwo.Count);
        list.Add(possibleEmotedTwo[randomTwo]);


        return list;
    }

}
