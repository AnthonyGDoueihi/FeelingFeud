using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : EnemyController
{
    EnemyEmotes[] possibleEmotedOne;
    EnemyEmotes[] possibleEmotedTwo;

    // Use this for initialization
    void Awake() {
        health = 2;
        emoteList = GetEmoteOrder();
        walkReloadTime = 5.0f;
        attackReload = 4.0f;
        moveSpeed = 5.0f;
    }

    List<EnemyEmotes> GetEmoteOrder()
    {
        List<EnemyEmotes> list = new List<EnemyEmotes>(health - 1);

        List<EnemyEmotes> possibleEmotedOne = new List<EnemyEmotes> { EnemyEmotes.Conflicted, EnemyEmotes.Surprise, EnemyEmotes.Pity};
        List<EnemyEmotes> possibleEmotedTwo = new List<EnemyEmotes> { EnemyEmotes.Intimidation, EnemyEmotes.Tired, EnemyEmotes.Conflicted };



        int randomOne = Random.Range(1, possibleEmotedOne.Count);
        list.Add(possibleEmotedOne[randomOne]);

        int randomTwo = Random.Range(1, possibleEmotedTwo.Count);
        list.Add(possibleEmotedTwo[randomTwo]);

        return list;
    }
}
