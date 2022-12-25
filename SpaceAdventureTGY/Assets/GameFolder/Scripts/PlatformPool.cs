using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    GameObject platformPrefab = default;
    [SerializeField]
    GameObject olumculplatformPrefab = default;

    [SerializeField]
    GameObject playerPrefab = default;

    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformPozisyon;
    Vector2 playerPozisyon;

    [SerializeField]
    float platformArasiMesafe = default; 

    private void Start()
    {
        PlatformUret();
    }
    private void Update()
    {
        //Ekranýn en üst noktasý, þuan list'in içerisinde olan platformlarýn sonuncunun konumuna ulaþtý mý.
        if (platforms[platforms.Count - 1].transform.position.y < Camera.main.transform.position.y + EkranHesaplayicisi.instance.Yukseklik)
        {
            PlatformYerlestir();
        }
    }
    void PlatformUret()
    {
        platformPozisyon = new Vector2(0, 0);
        PlayerYerlestir();
        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPozisyon, Quaternion.identity);
            platforms.Add(platform);
            platform.transform.parent = transform;
            platform.GetComponent<Platform>().Hareket = true;
            SonrakiPlatformPozisyon();
        }
        GameObject olumculPlatform = Instantiate(olumculplatformPrefab, platformPozisyon, Quaternion.identity);
        platforms.Add(olumculPlatform);
        olumculPlatform.transform.parent = transform;
        olumculPlatform.GetComponent<OlumculPlatform>().Hareket = true;
        SonrakiPlatformPozisyon();
    }
    void PlatformYerlestir()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            // 5.elemandan baþlayacak gezecek
            temp = platforms[i + 5];
            // en baþtaki elemaný 5 kademe ileri alýnýr
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPozisyon;
            SonrakiPlatformPozisyon();
        }
    }
    void PlayerYerlestir()
    {
        playerPozisyon = new Vector2(0, 0.5f);

        GameObject player = Instantiate(playerPrefab, playerPozisyon, Quaternion.identity);
        GameObject ilkPlatform = Instantiate(platformPrefab, platformPozisyon, Quaternion.identity);
        platforms.Add(ilkPlatform);
        SonrakiPlatformPozisyon();
        ilkPlatform.GetComponent<Platform>().Hareket = true;

    }
    void SonrakiPlatformPozisyon()
    {
        // platformlar arasý dikey mesafe ayarlanýr
        platformPozisyon.y += platformArasiMesafe;
        float random = Random.Range(0.0f, 1.0f);
        if (random < 0.5f)
        {
            platformPozisyon.x = EkranHesaplayicisi.instance.Genislik / 2;
        }
        else
        {
            platformPozisyon.x = -EkranHesaplayicisi.instance.Genislik / 2;
        }
    }

}
