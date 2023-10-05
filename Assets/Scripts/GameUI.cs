using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] BallManagement ballManager;
    Vector2 buttonSize = new Vector2(80, 80);
    Vector2 buttonPosition1 = new Vector2(300, 200);
    Vector2 buttonPosition2 = new Vector2(300, 400);
    bool b_zeroP = false;
    int currentPointsInt;
    string currentPoints;


    private void Start()
    {
        currentPointsInt = 0;  
        // ballManager = GetComponent<BallManagement>();
    }

    private void Update()
    {

        if (!b_zeroP) 
        {
            currentPoints = currentPointsInt.ToString();
        }
        else
        {
            currentPoints = "0";
            b_zeroP = false;
        }

    }

    private void OnGUI()
    {
        GUI.Label(new Rect(buttonPosition2, buttonSize), currentPoints);
        
        if (GUI.Button(new Rect(buttonPosition1, buttonSize), "Restart"))
        {
            // gives back lives and puts points to zero
            ballManager.LifeCounter = 5;
            currentPointsInt = 0;
        }
    }

    public void currentPointsCounter()
    {
        currentPointsInt += 100;
    }

}
