using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.IO;
//using UnityEngine.UIElements;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
    public int identifier;

    public Transform nextParent;
    public Item item;

    public Image image;
    public string tooltip;
    public Text tooltipText;
    public ItemType type;
    public GameObject collectiblePrefab;

    public void InitializeItem(Item newItem)
        {
        item = newItem;
        identifier = newItem.identifier;
        type = newItem.type;
        image.sprite = newItem.image;
        tooltip = newItem.tooltip;
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
            if (type == ItemType.Weapon && nextParent.GetComponent<InventorySlot>().weaponSlot)
                {
                InventoryManager.instance.armed = false;
                }
            GameObject spawnedCollectible = Instantiate(collectiblePrefab);
            spawnedCollectible.GetComponentInChildren<ItemCollectible>().item = item;
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