using UnityEngine;
using UnityEngine.UI;

public class FloatinXPBar : MonoBehaviour
{
    private Slider slider;
    public PlayerScript player; // Referenz auf die PlayerScript-Komponente

    private void Start()
    {
        slider = GetComponent<Slider>();
        player = FindFirstObjectByType<PlayerScript>(); // Sucht die PlayerScript-Komponente im Spiel
    }

    void Update()
    {
        if (player != null)
        {
            slider.value = player.playerXP; // Zugriff auf die xp-Variable in PlayerScript
        }
    }
}
