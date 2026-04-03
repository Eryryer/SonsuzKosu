using UnityEngine;

public class HareketliEngel : MonoBehaviour
{
    Transform oyuncu;
    OyunYoneticisi yonetici;
    bool tetiklendi = false;
    int tuzakTipi; 

    void Start()
    {
        oyuncu = GameObject.Find("Karakter").transform;
        yonetici = GameObject.Find("OyunYoneticisi").GetComponent<OyunYoneticisi>();
        tuzakTipi = Random.Range(0, 2); 
    }

    void Update()
    {
        if (oyuncu == null || yonetici == null) return;

        float mesafe = transform.position.z - oyuncu.position.z;

        // standart zor mod ayarlari 200 skordna sonra
        float tetiklenmeMesafesi = 30.0f; 
        float animasyonHizi = 10.0f;      
        float buyumeX = 1.5f;             
        float buyumeY = 3.5f;             

        // Cehennem mod skoru 350'den sonra
        if (yonetici.skor > 350.0f)
        {
            tetiklenmeMesafesi = 15.0f; 
            animasyonHizi = 25.0f;      
            buyumeX = 2.2f;             
            buyumeY = 4.5f;             
        }

        if (mesafe < tetiklenmeMesafesi && mesafe > 0)
        {
            tetiklendi = true;
        }

        if (tetiklendi)
        {
            if (tuzakTipi == 0) 
            {
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(buyumeX, buyumeY, 1.5f), animasyonHizi * Time.deltaTime);
            }
            else 
            {
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, 0.2f, 1f), animasyonHizi * Time.deltaTime);
            }
        }
    }
}