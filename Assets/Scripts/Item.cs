using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public ItemType type;
    public string tooltip;

}
public enum ItemType
    {
    Weapon,
    Food,
    Misc
    }