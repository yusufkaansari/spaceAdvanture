using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamEkran : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float spriteGenislik = spriteRenderer.size.x;

        float ekranYukseklik = Camera.main.orthographicSize * 2.0f;
        float ekranGenislik = ekranYukseklik / Screen.height * Screen.width;

        Vector2 tempScale = transform.localScale;
        tempScale.x = ekranGenislik / spriteGenislik;
        transform.localScale = tempScale;
    }


}
