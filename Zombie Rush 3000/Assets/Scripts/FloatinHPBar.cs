using UnityEngine;
using UnityEngine.UI;

public class FloatinHPBar : MonoBehaviour
{
    private Slider slider;
    public int hp;

    private void Start()
    {
        slider = GetComponent<Slider>();
        //player = GetComponentInParent<>
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = hp;
    }
}
