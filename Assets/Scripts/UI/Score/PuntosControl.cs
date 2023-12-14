using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntosControl : MonoBehaviour
{
    public LevelScore levelScore;
    public static PuntosControl instancia;
    public TextMeshProUGUI puntosText;
    public float puntos;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else if (instancia != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        puntos = 0;
    }
    void Update()
    {
        UpdatePoints();
    }
    void UpdatePoints()
    {
        puntosText.text = puntos.ToString();
    }
}
