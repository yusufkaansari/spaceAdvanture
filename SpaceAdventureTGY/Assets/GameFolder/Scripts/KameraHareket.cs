using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraHareket : MonoBehaviour
{
    float hiz;
    float hizlanma;
    float maksimumHiz;

    bool hareket=true;

    private void Start()
    {
        hiz = 0.5f;
        hizlanma = 0.05f;
        maksimumHiz = 2.0f;
    }
    private void Update()
    {
        if (hareket)
        {
            KamerayiHareketEttir();
        }
    }

    void KamerayiHareketEttir()
    {
        transform.position += transform.up * hiz * Time.deltaTime;
        hiz += hizlanma * Time.deltaTime;
        if (hiz> maksimumHiz)
        {
            hiz = maksimumHiz;
        }
    }
}
