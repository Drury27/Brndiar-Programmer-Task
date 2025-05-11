using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public Sprite image;
    public ItemType type;
    public string tooltip;
    public int identifier;
}
public enum ItemType
    {
    Weapon,
    Food,
    Misc
    }