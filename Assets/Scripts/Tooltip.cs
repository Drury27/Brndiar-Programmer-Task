using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
    public GameObject item;

    public void OnPointerEnter(PointerEventData data)
        {
        //item = data.pointerEnter;
        //if (data.pointerEnter == item)
        //    {
        //    gameObject.SetActive(true);
        //    }
        }
    public void OnPointerExit(PointerEventData data)
        {
        //if (data.selectedObject.tag == "Item")
        //    {
        //   gameObject.SetActive(false);
        //    }
        }
    }
