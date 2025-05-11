using System.IO;
using UnityEngine;

[System.Serializable]
public class IntArrayWrapper
    {
    public int[] intArray;
    }

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public Item[] startingItems;
    public InventorySlot[] inventorySlots;
    public InventorySlot weaponSlot;
    public GameObject inventoryItemPrefab;
    public bool armed;
    public string[] saveSlot;
    private string filePath;
    public int[] invts;
    public GameObject hackyDangThingToDoAnHourBeforeTheDeadline;

    private void Start()
        {
        filePath = Path.Combine(Application.persistentDataPath, "Inventory.json");
        invts = new int[inventorySlots.Length];
        if (File.Exists(filePath))
            {
            invts = LoadArray();
            for (int i = 0; i < invts.Length; i++)
                {
                if (invts[i] != 0)
                    {
                    SpawnNewItem(startingItems[invts[i]], inventorySlots[i]);
                    }
                }
            }
        else
            {
            SpawnNewItem(startingItems[1], inventorySlots[0]);
            hackyDangThingToDoAnHourBeforeTheDeadline.SetActive(true);
            }
        }

    private void Awake()
        {
        instance = this;
        }

    public bool AddItem(Item item)
        {
        for (int i = 0; i < inventorySlots.Length; i++)
            {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
                {
                SpawnNewItem(item, slot);
                return true;
                }
            }
        return false;
        }
    private void SpawnNewItem(Item item, InventorySlot slot)
        {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
        }

    int[] LoadArray()
        {
        string json = File.ReadAllText(filePath);
        IntArrayWrapper wrapper = JsonUtility.FromJson<IntArrayWrapper>(json);
        return wrapper.intArray;
        }

    public void OnApplicationQuit()
        {
        for (int i = 0; i < inventorySlots.Length; i++)
            {
            if (inventorySlots[i].transform.childCount > 0)
                {
                invts[i] = inventorySlots[i].gameObject.GetComponentInChildren<InventoryItem>(true).identifier;
                }
            else
                {
                invts[i] = 0;
                }
            }
        IntArrayWrapper wrapper = new IntArrayWrapper() { intArray = invts };
        string json = JsonUtility.ToJson(wrapper);
        File.WriteAllText(filePath, json);
        }

    }
