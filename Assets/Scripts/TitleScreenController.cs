using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenController : MonoBehaviour {

    public GameObject play;
    public GameObject controls;
    public GameObject quit;
    public GameObject back;
    public GameObject howTo;


    // Use this for initialization
    void Start () {
        play.SetActive(true);
        controls.SetActive(true);
        quit.SetActive(true);
        back.SetActive(false);
        howTo.SetActive(false);
    }

    public void HowToPlay()
    {
        play.SetActive(false);
        controls.SetActive(false);
        quit.SetActive(false);
        back.SetActive(true);
        howTo.SetActive(true);
    }

    public void Back()
    {
        play.SetActive(true);
        controls.SetActive(true);
        quit.SetActive(true);
        back.SetActive(false);
        howTo.SetActive(false);
    }
}
