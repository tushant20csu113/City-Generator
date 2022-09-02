using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Car",menuName ="Cars/Create New")]
public class Cars : ScriptableObject
{
    public Sprite[] characters;
    public string carName;
    public Color carColor;
    public int topSpeed;
    public float acceleration;
    public int hitpoints;
}
