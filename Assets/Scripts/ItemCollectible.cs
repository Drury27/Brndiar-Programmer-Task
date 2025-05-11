using UnityEngine;

public class ItemCollectible : MonoBehaviour
    {
    public Item item;

    private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.CompareTag("Player"))
            {
            InventoryManager.instance.AddItem(item);
            Destroy(transform.parent.gameObject);
            }
        }
    }
