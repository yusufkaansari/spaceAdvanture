using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkranHesaplayicisi : MonoBehaviour
{
    public static EkranHesaplayicisi instance;

    float _yukseklik;
    float _genislik;
    public float Yukseklik { get => _yukseklik; }
    public float Genislik { get => _genislik; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        _yukseklik = Camera.main.orthographicSize;
        _genislik = _yukseklik * Camera.main.aspect;
    }
}
