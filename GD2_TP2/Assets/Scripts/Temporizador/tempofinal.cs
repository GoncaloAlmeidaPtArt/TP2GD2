using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class tempofinal : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] private string _sceneName;

    [SerializeField] float tempo = 30f;
    [SerializeField] float addedTime = 10f;

    void Update()
    {
        if (tempo > 0)
        {
            tempo -= Time.deltaTime;

            if (tempo < 0)
            {
                tempo = 0;
                MataGato();
            }
                
            timerText.text = Convert.ToString(tempo);
        }
    }

    public void addTime()
    {
        tempo += addedTime;
    }

    void MataGato()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
