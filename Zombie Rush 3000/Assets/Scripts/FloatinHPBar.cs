using UnityEngine;
using UnityEngine.UI;

public class FloatinHPBar : MonoBehaviour
{
    private Slider slider;
    private int hp;
    public PlayerScript player; // Referenz auf die PlayerScript-Komponente

    private void Start()
    {
        slider = GetComponent<Slider>();
        player = FindFirstObjectByType<PlayerScript>(); // Sucht die PlayerScript-Komponente im Spiel
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            int hp1 = player.playerHP;
            slider.value = hp1;
        }
    }
}
