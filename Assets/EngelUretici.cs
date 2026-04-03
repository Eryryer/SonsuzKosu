using UnityEngine;

public class EngelUretici : MonoBehaviour
{
    public GameObject uzunEngelPrefab;
    public GameObject kisaEngelPrefab;

    // YENİ: Unity'den sürükleyip bırakacağımız materyal yuvaları
    public Material zorModMateryali;
    public Material cehennemModuMateryali;

    void Start()
    {
        if (transform.position.z < 25.0f)
        {
            return; 
        }

        float sansDegeri = Random.Range(0.0f, 100.0f);
        
        if (sansDegeri > 10.0f)
        {
            int seritNumarasi = Random.Range(0, 3);
            float engelX = 0.0f;
            
            if (seritNumarasi == 0) engelX = -2.5f;
            if (seritNumarasi == 1) engelX = 0.0f;
            if (seritNumarasi == 2) engelX = 2.5f;

            int engelTipi = Random.Range(0, 2); 
            
            GameObject uretilecekEngel;
            float engelY = 0.0f;

            if (engelTipi == 0)
            {
                uretilecekEngel = kisaEngelPrefab;
                engelY = 0.75f; 
            }
            else 
            {
                uretilecekEngel = uzunEngelPrefab;
                engelY = 1.5f; 
            }

            float engelZ = transform.position.z;

            GameObject yeniEngel = Instantiate(uretilecekEngel);
            yeniEngel.transform.position = new Vector3(engelX, engelY, engelZ);

            OyunYoneticisi yonetici = GameObject.Find("OyunYoneticisi").GetComponent<OyunYoneticisi>();
            
            if (yonetici != null && yonetici.skor > 200.0f)
            {
                if (Random.Range(0, 100) < 40.0f)
                {
                    yeniEngel.AddComponent<HareketliEngel>();

                    //  Skora göre ilgili materyali objeye giydiriyoruz
                    if (yonetici.skor > 350.0f)
                    {
                        yeniEngel.GetComponent<Renderer>().material = cehennemModuMateryali;
                    }
                    else
                    {
                        yeniEngel.GetComponent<Renderer>().material = zorModMateryali;
                    }
                }
            }
        }
    }
}