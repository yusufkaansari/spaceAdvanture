using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuKontrol : MonoBehaviour
{
    [SerializeField]
    Sprite[] muzikIkonlar = default;

    [SerializeField]
    Button muzikButon = default;

    [SerializeField]
    bool muzikAc�k = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Oyun");
    }
    public void EnYuksekPuan()
    {
        SceneManager.LoadScene("Puan");
    }

    public void Ayarlar()
    {
        SceneManager.LoadScene("Ayarlar");
    }

    public void Muzik()
    {
        if(muzikAc�k)
        {
            muzikAc�k = false;
            // muzik kapal� ikonu getirilir
            muzikButon.image.sprite = muzikIkonlar[0];
        }
        else
        {
            muzikAc�k = true;
            // muzik a��k ikonu getirilir
            muzikButon.image.sprite = muzikIkonlar[1];
        }
    }
}
