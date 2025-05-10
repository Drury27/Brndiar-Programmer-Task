using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    
    public void OnDrop(PointerEventData data)
        {
        InventoryItem incomingItem = data.pointerDrag.GetComponent<InventoryItem>();
        if (transform.childCount != 0)
            {
            InventoryItem currentItem = GetComponentInChildren<InventoryItem>();
            currentItem.transform.SetParent(incomingItem.nextParent);
            }
        incomingItem.nextParent = transform;
        }
}
