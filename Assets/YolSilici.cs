using UnityEngine;

public class YolSilici : MonoBehaviour
{
    public GameObject oyuncu;

    void Start()
    {
        // Sahnedeki Karakter isimli objeyi otomatik olarak bulma
        oyuncu = GameObject.Find("Karakter");
    }

    void Update()
    {
        float benimZ = transform.position.z;
        float oyuncuZ = oyuncu.transform.position.z;

        float mesafeFarki = oyuncuZ - benimZ;

        // Eger karakter bu yoldan 150 birim uzaklastiysa yok olur
        if (mesafeFarki > 150.0f)
        {
            Destroy(gameObject);
        }
    }
}