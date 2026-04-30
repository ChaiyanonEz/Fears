using UnityEngine;
using UnityEngine.SceneManagement; // ใช้สำหรับจัดการการเปลี่ยนฉาก/เริ่มเกมใหม่

public class KillZone : MonoBehaviour
{
    // ฟังก์ชันนี้จะทำงานเมื่อมีวัตถุเข้ามาในพื้นที่ Trigger
    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าสิ่งที่ตกลงมามี Tag ว่า "Player" หรือไม่
        if (other.CompareTag("Player"))
        {
            // สั่งให้เริ่มฉากปัจจุบันใหม่ทันที (Game Over)
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene(4);
        }
    }
}
