using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PolygonCollider2D polygonCollider2D;

    bool hareket;
    public bool Hareket {
        get
        {
            return hareket;
        }
        set
        {
            hareket = value;
        }
    }
    float randomHiz;

    float min, max;
    private void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        randomHiz = Random.Range(0.5f, 1.0f);

        float objeGenislik = polygonCollider2D.bounds.size.x / 2;

        if (transform.position.x > 0)
        {
            min = objeGenislik;
            max = EkranHesaplayicisi.instance.Genislik - objeGenislik;
        }
        else
        {
            min = -EkranHesaplayicisi.instance.Genislik + objeGenislik;
            max = -objeGenislik;
        }
    }
    private void Update()
    {
        if (hareket)
        {
            // pingpong methodu: zamanla 0 ile 3.0f deðeri arasýnda girip gelir, düzenli bir þekilde 0 -> 0.2 -> 0.3 ... 2.9 -> 3.0 -> 2.9 -> 2.8 ... 0.1 -> 0 þeklinde
            //float pingPongX = Mathf.PingPong(Time.time * randomHiz, 3.0f);
            float pingPongX = Mathf.PingPong(Time.time * randomHiz, max - min)+ min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ayaklar"))
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<OyuncuHareket>().ZiplamayiSifirla();
        }
    }
}
