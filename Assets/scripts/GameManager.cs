using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public float points = 0;

    public GameObject player;
    public TMP_Text txtPoints;
    public TMP_Text end;

    public float maxScore = 1000;

    public player playerSc; 

    public CinemachineVirtualCamera cinemachine;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        txtPoints.text = "0/100";
        end.enabled = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        txtPoints.text = Convert.ToString(points + "/1000");

        if (points > maxScore)
        {
            end.enabled = true;
            Time.timeScale = 0;
        }

        var sc = playerSc.scale.x;
        sc = Mathf.Round(sc);

        if (sc < 1){
            cinemachine.m_Lens.OrthographicSize = 4;
            print("change");
        }
        else if (sc > 1 && sc < 2){
            cinemachine.m_Lens.OrthographicSize = 5;
            print("change");
        }
        else if (sc > 2 && sc < 3)
        {
            cinemachine.m_Lens.OrthographicSize = 11;
            print("change");
        }
        else if (sc > 3 && sc < 5)
        {
            cinemachine.m_Lens.OrthographicSize = 12;
            print("change");
        }
        else if (sc > 5 && sc < 10)
        {
            cinemachine.m_Lens.OrthographicSize = 13;
            print("change");
        }
        else if (sc > 10 && sc < 15)
        {
            cinemachine.m_Lens.OrthographicSize = 14;
            print("change");
        }
        else if (sc > 15 && sc < 20)
        {
            cinemachine.m_Lens.OrthographicSize = 15;
            print("change");
        }
        else if (sc > 20 && sc < 30)
        {
            cinemachine.m_Lens.OrthographicSize = 20;
            print("change");
        }
        else if (sc > 30 && sc < 50)
        {
            cinemachine.m_Lens.OrthographicSize = 25;
            print("change");
        }
        else if (sc > 50)
        {
            cinemachine.m_Lens.OrthographicSize = 30;
            print("change");
        }

        //else cinemachine.m_Lens.OrthographicSize = playerSc.temp.x + 4;

        //cinemachine.m_Lens.OrthographicSize = playerSc.temp.x + 4;
    }
}
