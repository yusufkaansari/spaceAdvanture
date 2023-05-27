using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltinAlgilayici : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ayaklar"))
        {
            GetComponentInParent<Altin>().AltiniKapat();
            FindObjectOfType<Puan>().AltinKazan();
        }
    }
}
