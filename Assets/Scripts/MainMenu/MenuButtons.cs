using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public Button continueButton;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("currLevel") == 0)
            continueButton.interactable = false;
        else 
            continueButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame() 
    {

    }
    
    public void ContinueGame() 
    {

    }
    
    public void QuitGame() 
    {
        Application.Quit();
    }
}
