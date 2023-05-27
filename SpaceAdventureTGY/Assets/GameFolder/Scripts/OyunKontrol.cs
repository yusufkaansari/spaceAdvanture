using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public GameObject oyunBittiPanel;
    public GameObject joystick;
    public GameObject ziplamaButonu;
    public GameObject tabele;
    public GameObject menuButonu;
    public GameObject slider;


    // Start is called before the first frame update
    void Start()
    {
        oyunBittiPanel.SetActive(false);
        UIAc();
    }

    public void OyunuBitir()
    {
        oyunBittiPanel.SetActive(true);
        FindObjectOfType<Puan>().OyunBitti();
        UIKapat();
        Time.timeScale = 0;
    }

    public void AnaMenuyeDon()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void TekrarOyna()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Oyun");
    }
    void UIAc()
    {
        joystick.SetActive(true);
        ziplamaButonu.SetActive(true);
        tabele.SetActive(true);
        menuButonu.SetActive(true);
        slider.SetActive(true);
    }
    void UIKapat()
    {
        joystick.SetActive(false);
        ziplamaButonu.SetActive(false);
        tabele.SetActive(false);
        menuButonu.SetActive(false);
        slider.SetActive(false);
    }
}
