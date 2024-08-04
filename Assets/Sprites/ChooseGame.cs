using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Select(int index)
    {
        //load the game scene
        switch (index)
        {
            case 0:
                //load the game scene
                SceneManager.LoadScene("Game1");
                break;
            case 1:
                //load the game scene
                break;
            case 2:
                //load the game scene
                break;
            case 3:
                //load the game scene
                break;
            case 4:
                //load the game scene
                break;
            case 5:
                //load the game scene
                break;
            case 6:
                //load the game scene
                break;
            case 7:
                //load the game scene
                break;
            case 8:
                //load the game scene
                break;
            case 9:
                //load the game scene
                break;
            case 10:
                //load the game scene
                break;
        }
    }
}
