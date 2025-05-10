using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform nextParent;
    public Image thisImage;

    public void OnBeginDrag(PointerEventData data)
        {
        thisImage.raycastTarget = false;
        nextParent = transform.parent;
        transform.SetParent(transform.root);
        }
    public void OnDrag(PointerEventData data)
        {
        transform.position = Input.mousePosition;
        }
    public void OnEndDrag(PointerEventData data)
        {
        thisImage.raycastTarget = true;
        transform.SetParent(nextParent);
        }
}
