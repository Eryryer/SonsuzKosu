using UnityEngine;

public class KarakterHareketi : MonoBehaviour
{
    public float hiz = 5.0f;
    public int serit = 1; 
    public float seritMesafesi = 2.5f; 
    public float ziplamaGucu = 7.0f; 

    
    public float maksimumHiz = 20.0f;
    public float hizlanmaMiktari = 0.5f; // Saniyede hiz bu kadar artcak

    void Update()
    {
        // 1. Zamanla hizlanma mantigi
        // Eğer mevcut hiz belirlediğim sinirin altindaysa hiz artmaya devam eder
        if (hiz < maksimumHiz)
        {
            hiz = hiz + (hizlanmaMiktari * Time.deltaTime);
        }

        // 2. mevcut pozisyonlari alma 
        float mevcutX = transform.position.x;
        float mevcutZ = transform.position.z;

        // ileri gitme
        mevcutZ = mevcutZ + (hiz * Time.deltaTime);

        // 3. saga sola kayma
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            serit = serit + 1;
            if (serit > 2) serit = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            serit = serit - 1;
            if (serit < 0) serit = 0;
        }

        // 4. Ziplama mantigi
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y <= 1.1f)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
        }

        // 5. Şerit degistirme ve yumusak gecis(AI) benım yazdıgım kodda ışınlandı
        float hedefX = 0f;
        if (serit == 0) hedefX = 0f - seritMesafesi;
        if (serit == 1) hedefX = 0f;
        if (serit == 2) hedefX = 0f + seritMesafesi;

        mevcutX = Mathf.Lerp(mevcutX, hedefX, 10f * Time.deltaTime);

        // 6. yeni pozisyon
        transform.position = new Vector3(mevcutX, transform.position.y, mevcutZ);
    }
}