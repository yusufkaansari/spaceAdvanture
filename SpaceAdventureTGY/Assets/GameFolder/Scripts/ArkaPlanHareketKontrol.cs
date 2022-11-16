using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanHareketKontrol : MonoBehaviour
{
    float arkaPlanKonum;
    float mesafe;

    private void Start()
    {
        arkaPlanKonum = transform.position.y;
        mesafe=GetComponent<SpriteRenderer>().bounds.extents.y *2;
    }
    private void Update()
    {
        if (Camera.main.transform.position.y > arkaPlanKonum + mesafe )
        {
            ArkaplanYerlestir();
        }   
    }
    void ArkaplanYerlestir()
    {   
        // arkaplan gorselini yukarýya tasima islemi icin konum bilgisi
        arkaPlanKonum += (mesafe * 2);
        // arkaplan gorselini bir diger arkaplan objesinin ustune tasima islemi
        transform.position = new Vector2(0, arkaPlanKonum);  
    }
}
