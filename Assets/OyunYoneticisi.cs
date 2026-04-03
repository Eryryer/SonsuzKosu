using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OyunYoneticisi : MonoBehaviour
{
    public TMP_Text skorYazisi;
    public TMP_Text yuksekSkorYazisi; 
    public GameObject oyunBittiPaneli;

    public float skor = 0.0f;
    public bool oyunDevamEdiyorMu = true;

    void Update()
    {
        if (oyunDevamEdiyorMu == true)
        {
            skor = skor + (5.0f * Time.deltaTime);
            skorYazisi.text = "Skor: " + (int)skor;
        }
    }

    public void OyunuBitir()
    {
        oyunDevamEdiyorMu = false;
        Time.timeScale = 0.0f;

        int mevcutSkor = (int)skor;
        
        //  eski rekoru cihazin hafizasindan cekme (Eger hic yoksa 0 getirir)
        int enYuksekSkor = PlayerPrefs.GetInt("EnYuksekSkor", 0);

        if (mevcutSkor > enYuksekSkor)
        {
            // Yeni rekoru hafızaya yazma
            PlayerPrefs.SetInt("EnYuksekSkor", mevcutSkor);
            enYuksekSkor = mevcutSkor; 
        }

        //  Ekranda rekoru gösterme
        yuksekSkorYazisi.text = "En Yüksek Skor: " + enYuksekSkor;

        oyunBittiPaneli.SetActive(true);
    }

    public void TekrarOyna()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}