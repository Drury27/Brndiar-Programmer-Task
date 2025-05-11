using UnityEngine;

public class ItemCollectible : MonoBehaviour
    {
    public Item item;
    public SpriteRenderer thisSprite;

    private void Start()
        {
        thisSprite.sprite = item.image;
        }

    private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.CompareTag("Player"))
            {
            InventoryManager.instance.AddItem(item);
            Destroy(transform.parent.gameObject);
            }
        }
    }
