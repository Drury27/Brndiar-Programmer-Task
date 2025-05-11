using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    // TODO: make equip slots extensible via scriptableobject
    public bool weaponSlot;

    // this is terrible but I have to move on
    public void OnDrop(PointerEventData data)
        {
        InventoryItem incomingItem = data.pointerDrag.GetComponent<InventoryItem>();
        InventorySlot incomingSlot = incomingItem.nextParent.GetComponent<InventorySlot>();
        if (!weaponSlot || (weaponSlot && incomingItem.type == ItemType.Weapon))
            {
            if (!incomingSlot.weaponSlot)
                {
                if (transform.childCount != 0)
                    {
                    InventoryItem currentItem = GetComponentInChildren<InventoryItem>();
                    currentItem.transform.SetParent(incomingItem.nextParent);
                    }
                incomingItem.nextParent = transform;
                }
            else if (transform.childCount == 0)
                {
                incomingItem.nextParent = transform;
                InventoryManager.instance.armed = false;
                }
            if (weaponSlot)
                {
                InventoryManager.instance.armed = true;
                }
            }
        }
}
