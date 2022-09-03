using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterPanel : MonoBehaviour
{
    public CarsData[] cars;

    public Image carImage;
    public TextMeshProUGUI carName;

    private int CurrentCarIndex;

    private void Start()
    {
        CurrentCarIndex = 0;
        UpdateHero();
    }
   
    public void GUI_Next()
    {
        CurrentCarIndex++;
        if(CurrentCarIndex < cars.Length)
        {
            UpdateHero();
        }
        else 
        {
            CurrentCarIndex = 0;
            UpdateHero();
        }
    }
    public void GUI_Previous()
    {
        CurrentCarIndex--;
        if (CurrentCarIndex >= 0)
        {
            UpdateHero();
        }
        else
        {
            CurrentCarIndex = cars.Length - 1;
            UpdateHero();
        }
    }
    private void UpdateHero()
    {
        carImage.sprite = cars[CurrentCarIndex].carImage;
        carName.text = cars[CurrentCarIndex].carName;

    }
}
