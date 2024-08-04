using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Game1Manager : MonoBehaviour
{
    //implement the singleton pattern
    public static Game1Manager instance;
    public TMPro.TextMeshProUGUI timeText;
    public bool isGameActive = false;
    public GameObject goEndGame;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GetTime();
    }

    IEnumerator ieStart()
    {
        //countdown from 3 and update the text
        for (int i = 3; i > 0; i--)
        {
            timeText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        timeText.text = "GO!";
        yield return new WaitForSeconds(1);
        timeText.gameObject.SetActive(false);
        isGameActive = true;
    }
    //make a request to https://timeapi.io/api/Time/current/zone?timeZone=Asia/Ho_Chi_Minh
    public void GetTime()
    {
        timeText.text = "Loading...";
        StartCoroutine(ieGetTime());
    }
    IEnumerator ieGetTime()
    {
        WWW www = new WWW("https://timeapi.io/api/Time/current/zone?timeZone=Asia/Ho_Chi_Minh");
        yield return www;
        timeText.text = "Call Sample Api Done";
        yield return new WaitForSeconds(2);
        StartCoroutine(ieStart());
    }
    public IEnumerator ieEndGame()
    {
        isGameActive = false;
        goEndGame.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
