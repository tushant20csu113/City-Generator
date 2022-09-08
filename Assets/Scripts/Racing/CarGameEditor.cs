using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CarGameEditor : EditorWindow
{
    string carName;
    //Sprite carImage;
    [MenuItem("Racing/Car Game/Game Info")]
    static void OpenWindow()
    {
        CarGameEditor myWindow = (CarGameEditor)GetWindow(typeof(CarGameEditor));
        myWindow.Show();
    }
    private void OnGUI()
    {
        GUILayout.Label("This is my cutom editor window.");
        carName = EditorGUILayout.TextField("Car Name", carName);
        //(Sprite)EditorGUILayout.ObjectField("Head", player.headSprite);
        //carImage = (Sprite)EditorGUILayout.ObjectField("Car Image", carImage, typeof(Sprite));
        if (GUILayout.Button("Create Car"))
        {
            CarsData car = ScriptableObject.CreateInstance<CarsData>();
            car.carName = carName;
            //car.carImage = carImage;
            AssetDatabase.CreateAsset(car, "Assets/Scripts/Racing/Cars/" + carName + ".asset");
            AssetDatabase.SaveAssets();
        }
    }
}
