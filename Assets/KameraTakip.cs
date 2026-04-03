using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    // Hangi objeyi takip edileceğini unity'den seçtim
    public GameObject takipEdilecekKarakter; 
    
    float mesafeX;
    float mesafeY;
    float mesafeZ;

    void Start()
    {
        // Oyun basladiginda kamera ile karakter arasindaki o anki mesafe hesaplandi
        mesafeX = transform.position.x - takipEdilecekKarakter.transform.position.x;
        mesafeY = transform.position.y - takipEdilecekKarakter.transform.position.y;
        mesafeZ = transform.position.z - takipEdilecekKarakter.transform.position.z;
    }

    void Update()
    {
        // kameranin gitmesi gereken yer heasplandi
        float yeniKameraX = takipEdilecekKarakter.transform.position.x + mesafeX;
        float yeniKameraY = takipEdilecekKarakter.transform.position.y + mesafeY;
        float yeniKameraZ = takipEdilecekKarakter.transform.position.z + mesafeZ;

        // yeni pozisyonu kameraya verdim.
        transform.position = new Vector3(yeniKameraX, yeniKameraY, yeniKameraZ);
    }
}