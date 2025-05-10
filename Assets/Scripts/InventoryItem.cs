using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

    /*[HideInInspector]*/
    public Transform nextParent;
    /*[HideInInspector]*/
    public Item item;

    public Image thisImage;

    public void InitializeItem(Item newItem)
        {
        item = newItem;
        thisImage.sprite = newItem.sprite;
        }

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
        if (!data.pointerCurrentRaycast.isValid)
            {
            //preferably the item would get yeeted instead, we'll see
            Destroy(this.gameObject);
            }
        thisImage.raycastTarget = true;
        transform.SetParent(nextParent);
        }
    }