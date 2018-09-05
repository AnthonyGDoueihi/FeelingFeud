using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour {

    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;

    bool spawned1 = false;
    bool spawned2 = false;
    bool spawned3 = false;
    bool spawned4 = false;

    bool spawn1Destroy;
    bool spawn2Destroy;
    bool spawn3Destroy;
    bool spawn4Destroy;

    public GameObject adventurerPrefab;
    public GameObject manAltPrefab;
    public GameObject orcPrefab;
    public GameObject robotPrefab;
    public GameObject soldierPrefab;
    public GameObject womanAltPrefab;

    public GameObject enemyFolder;

    private PlayerController player;

    GameObject one;
    GameObject two;
    GameObject three;
    GameObject four;

    GameObject[] alive;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        alive = new GameObject[4];
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawn1Destroy)
        {
            if (!spawned1)
            {
                if (Vector3.Distance(player.transform.position, spawner1.transform.position) <= 300.0f)
                {

                    GameObject one = Instantiate(manAltPrefab,
                        new Vector3(Random.Range(spawner1.transform.position.x, spawner1.transform.position.x - 50), 0, Random.Range(-26, 26)),
                        Quaternion.Euler(0, -90, 0), enemyFolder.transform);
                    alive[0] = one;
                    GameObject two = Instantiate(womanAltPrefab,
                        new Vector3(Random.Range(spawner1.transform.position.x - 50, spawner1.transform.position.x - 100), 0, Random.Range(-26, 26)),
                        Quaternion.Euler(0, -90, 0), enemyFolder.transform);
                    alive[1] = two;

                    spawned1 = true;

                }
            }
            else
            {
                if (alive[0] == null && alive[1] == null)
                {
                    spawn1Destroy = true;
                    Destroy(spawner1);
                }
            }
        }
        else
        {
            if (!spawn2Destroy)
            {
                if (spawned2)
                {
                    if (Vector3.Distance(player.transform.position, spawner2.transform.position) <= 300.0f)
                    {

                        GameObject one = Instantiate(orcPrefab,
                            new Vector3(Random.Range(spawner2.transform.position.x, spawner2.transform.position.x - 50), 0, Random.Range(-26, 26)),
                            Quaternion.Euler(0, -90, 0), enemyFolder.transform);
                        alive[0] = one;
                        GameObject two = Instantiate(womanAltPrefab,
                            new Vector3(Random.Range(spawner2.transform.position.x - 50, spawner2.transform.position.x - 100), 0, Random.Range(-26, 26)),
                            Quaternion.Euler(0, -90, 0), enemyFolder.transform);
                        alive[1] = two;
                        GameObject three = Instantiate(adventurerPrefab,
                            new Vector3(Random.Range(spawner2.transform.position.x - 100, spawner2.transform.position.x - 150), 0, Random.Range(-26, 26)),
                            Quaternion.Euler(0, -90, 0), enemyFolder.transform);
                        alive[2] = three;

                        spawned2 = true;

                    }
                }                    
                 else
                {
                    if (alive[0] == null && alive[1] == null && alive[2] == null)
                    {
                        spawn2Destroy = true;
                        Destroy(spawner2);
                    }
                }
            }
            else
            {
                if (!spawn3Destroy)
                {
                    if (spawned3)
                    {
                        if (Vector3.Distance(player.transform.position, spawner3.transform.position) <= 300.0f)
                        {
                            spawned3 = true;

                            GameObject one = Instantiate(orcPrefab,
                                new Vector3(Random.Range(spawner3.transform.position.x, spawner3.transform.position.x - 50), 0, Random.Range(-26, 26)),
                                Quaternion.Euler(0, -90, 0), enemyFolder.transform);
                            alive[0] = one;
                            GameObject two = Instantiate(soldierPrefab,
                                new Vector3(Random.Range(spawner3.transform.position.x - 50, spawner3.transform.position.x - 100), 0, Random.Range(-26, 26)),
                                Quaternion.Euler(0, -90, 0), enemyFolder.transform);
                            alive[1] = two;
                            GameObject three = Instantiate(adventurerPrefab,
                                new Vector3(Random.Range(spawner3.transform.position.x - 100, spawner3.transform.position.x - 150), 0, Random.Range(-26, 26)),
                                Quaternion.Euler(0, -90, 0), enemyFolder.transform);
                            alive[2] = three;
                            GameObject four = Instantiate(soldierPrefab,
                                new Vector3(Random.Range(spawner3.transform.position.x - 150, spawner3.transform.position.x - 200), 0, Random.Range(-26, 26)),
                                Quaternion.Euler(0, -90, 0), enemyFolder.transform);
                            alive[3] = four;
                        }
                    }
                    else
                    {
                        if (alive[0] == null && alive[1] == null && alive[2] == null && alive[3] == null)
                        {
                            spawn3Destroy = true;
                            Destroy(spawner3);
                        }
                    }
                }
                else
                {
                    if (!spawn4Destroy)
                    {
                        if (spawned4)
                        {
                            if (Vector3.Distance(player.transform.position, spawner4.transform.position) <= 300.0f)
                            {
                                spawned3 = true;

                                GameObject one = Instantiate(robotPrefab,
                                    new Vector3(Random.Range(spawner4.transform.position.x, spawner4.transform.position.x - 50), 0, Random.Range(-26, 26)),
                                    Quaternion.Euler(0, -90, 0), enemyFolder.transform);
                                alive[0] = one;
                            }
                        }
                        else
                        {
                            if (alive[0] == null)
                            {
                                spawn4Destroy = true;
                                Destroy(spawner4);
                            }
                        }
                    }
                    else
                    {
                        //TODO You Win
                    }
                }
            }
        }
    }
}
