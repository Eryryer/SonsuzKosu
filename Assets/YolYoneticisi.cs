using UnityEngine;

public class YolYoneticisi : MonoBehaviour
{
    public GameObject yolPrefab; 
    public GameObject oyuncu;
    
    public float spawnZ = 0.0f;
    public float yolUzunlugu = 100.0f;
    public int ekrandaKacYolOlsun = 3;
    
    void Start()
    {
        // Oyun baslarken ekrana 3 tane yol diz ulaaaa
        int sayac = 0;
        while (sayac < ekrandaKacYolOlsun)
        {
            YolUret();
            sayac = sayac + 1;
        }
    }

    void Update()
    {
        // Karakterin nerede oldugunu bul
        float oyuncuPozisyonuZ = oyuncu.transform.position.z;
        float uretimSiniri = spawnZ - (ekrandaKacYolOlsun * yolUzunlugu);

        if (oyuncuPozisyonuZ > uretimSiniri)
        {
            YolUret();
        }
    }

    void YolUret()
    {
        // Prefabdan sahnede yeni bir yol olustur
        GameObject yeniYol = Instantiate(yolPrefab);
        
        // Yeni yolun koordinatlari
        float yeniX = 0.0f;
        float yeniY = 0.0f;
        float yeniZ = spawnZ;
        
        yeniYol.transform.position = new Vector3(yeniX, yeniY, yeniZ);
        
        // Bir sonraki yolun nerede üretilecegini hesaplama
        spawnZ = spawnZ + yolUzunlugu;
    }
}