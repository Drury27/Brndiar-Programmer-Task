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
    public TMP_Text tooltipText;

    public void InitializeItem(Item newItem)
        {
        item = newItem;
        image.sprite = newItem.image;
        tooltipText = GetComponentInChildren<TMP_Text>();
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
        //if (!tooltipText.gameObject.activeSelf)
            tooltipText.gameObject.SetActive(true);
        }
    public void OnPointerExit(PointerEventData data)
        {
        //if (tooltipText.gameObject.activeSelf)
            tooltipText.gameObject.SetActive(false);
        }
    }