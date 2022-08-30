using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextModal 
{
    private static TextModal instance;
    public static TextModal Instance
    {
        get
        {
            if (instance == null)
                instance = new TextModal();
            return instance;
        }
    }
    private int playerHealth;
    public int PlayerHealth
    { 
        get
        {
            return playerHealth;
        }
        set
        {
            playerHealth = value;
        }
            
     }
    private int playerScore;
    public int PlayerScore
    {
        get
        {
            return playerScore;
        }
        set
        {
            playerScore = value;
        }

    }

    
}
