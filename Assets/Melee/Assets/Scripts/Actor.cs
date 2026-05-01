using UnityEngine;
using UnityEngine.SceneManagement;

public class Actor : MonoBehaviour
{
    int currentHealth;
    public int maxHealth;

    [Header("Boss Settings")]
    public bool isBoss = false;

    [Header("Effects")]
    public Material bloodMaterial; // ??????????????? Material ?????

    void Awake() => currentHealth = maxHealth;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Death();
    }

    void Death()
    {
        if (isBoss) WinGame();
        CreateDeathEffect();
        Destroy(gameObject);
    }

    void CreateDeathEffect()
    {
        GameObject blood = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        Vector3 spawnPos = transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 5f))
        {
            spawnPos = hit.point + new Vector3(0, 0.01f, 0);
        }

        blood.transform.position = spawnPos;
        blood.transform.localScale = new Vector3(1.2f, 0.05f, 1.2f);

        // ??? Material ???????????????
        Renderer ren = blood.GetComponent<Renderer>();
        if (ren != null && bloodMaterial != null)
        {
            ren.material = bloodMaterial;
        }

        Destroy(blood.GetComponent<Collider>());
        Destroy(blood, 10f);
    }

    void WinGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(3);
    }
}
