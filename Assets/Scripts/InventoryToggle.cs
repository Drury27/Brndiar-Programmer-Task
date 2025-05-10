using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            {
            inventory.SetActive(!inventory.activeSelf);
            }
    }
}
