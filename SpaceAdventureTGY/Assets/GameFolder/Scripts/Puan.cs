using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puan : MonoBehaviour
{
    int puan;
    int altin;

    bool puanTopla = true;

    [SerializeField]
    Text puanText = default;

    [SerializeField]
    Text altinText = default;

    [SerializeField]
    Text oyunBittipuanText = default;

    [SerializeField]
    Text oyunBittialtinText = default;
    // Start is called before the first frame update
    void Start()
    {
        altinText.text = "X " + altin; 
    }

    // Update is called once per frame
    void Update()
    {
        if (puanTopla)
        {
            puan = (int)Camera.main.transform.position.y;
            puanText.text = "Puan: " + puan;
        }
        //Debug.Log((int) Camera.main.transform.position.y);
        
    }

    public void AltinKazan()
    {
        altin++;
        altinText.text = "X " + altin;
    }

    public void OyunBitti()
    {
        puanTopla = false;
        oyunBittipuanText.text = "Puan: " + puan;
        oyunBittialtinText.text = "X " + altin;
    }
}
