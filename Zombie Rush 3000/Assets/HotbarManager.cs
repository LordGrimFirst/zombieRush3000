using UnityEngine;
using UnityEngine.UI;

public class HotbarManager : MonoBehaviour
{
    public Button[] hotbarSlots;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Hotbarslot 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
            UseAbility(0);

        // Hotbarslot 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
            UseAbility(1);

        // Hotbarslot 3
        if (Input.GetKeyDown(KeyCode.Alpha3))
            UseAbility(2);

        // Hotbarslot 4
        if (Input.GetKeyDown(KeyCode.Alpha4))
            UseAbility(3);

        // Hotbarslot 5
        if (Input.GetKeyDown(KeyCode.Alpha5))
            UseAbility(4);
    }
    void UseAbility(int slotIndex)
    {
        Debug.Log("Ability ausgelöst: Slot " + (slotIndex+1));
        // hier später: Fähigkeiten logik einbauen
    }
}
