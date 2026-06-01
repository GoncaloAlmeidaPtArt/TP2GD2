using System;
using TMPro;
using UnityEngine;

public class tempofinal : MonoBehaviour
{

    [SerializeField] TextMeshPro timerText;

    [SerializeField] float tempo = 100f;

    void Update()
    {
        if (tempo > 0)
        {
            tempo -= Time.deltaTime;

            if (tempo < 0)
            {
                tempo = 0;
            }
                
            timerText.text = Convert.ToString(tempo);
        }
    }
}
