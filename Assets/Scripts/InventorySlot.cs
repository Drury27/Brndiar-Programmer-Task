using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    
    public void OnDrop(PointerEventData data)
        {
        if (transform.childCount == 0)
            {
            InventoryItem inventoryItem = data.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.nextParent = transform;
            }
        }
}
