using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
    {

    public Transform nextParent;
    public Item item;

    public Image image;
    public string tooltip;
    public Text tooltipText;

    public void InitializeItem(Item newItem)
        {
        item = newItem;
        image.sprite = newItem.image;
        tooltipText = GameObject.Find("Tooltip").GetComponent<Text>();
        tooltipText.text = tooltip;
        }

    public void OnBeginDrag(PointerEventData data)
        {
        image.raycastTarget = false;
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
        image.raycastTarget = true;
        transform.SetParent(nextParent);
        }
    public void OnPointerEnter(PointerEventData data)
        {
        tooltipText.enabled = true;
        tooltipText.text = tooltip;
        }
    public void OnPointerExit(PointerEventData data)
        {
        tooltipText.enabled = false;
        }
    }