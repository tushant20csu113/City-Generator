using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class TextView 
{
    public TextMeshProUGUI h_Object;//Health
    public TextMeshProUGUI s_Object;//Score


    public void StatsUpdate()
    {
        h_Object.text = "Health:" + TextModal.Instance.PlayerHealth.ToString();
        s_Object.text = "Score:" + TextModal.Instance.PlayerScore.ToString();
    }

}
