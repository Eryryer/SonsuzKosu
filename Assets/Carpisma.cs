using UnityEngine;

public class Carpisma : MonoBehaviour
{
    void OnCollisionEnter(Collision carpilanObje)
    {
        // Çarpılan objenin adında Engel var mı diye kontrol ediyom
        if (carpilanObje.gameObject.name.Contains("Engel"))
        {
            OyunYoneticisi yonetici = GameObject.Find("OyunYoneticisi").GetComponent<OyunYoneticisi>();
            
            // Yöneticideki menü açma kodunu tetikliyom
            yonetici.OyunuBitir();

            Time.timeScale = 0.0f;
            Debug.Log("Engele Çarptın, Oyun Bitti!");
        }
    }
}