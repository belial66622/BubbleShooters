using UnityEngine;

public class Item
{
    public enum ItemType
    {
        corbek,
        roket,
        bola,
    }

    public ItemType itemType; // Jenis item
    public int amount;        // Jumlah item

    public GameObject associatedGameObject; // GameObject terkait

    // Konstruktor untuk membuat item baru
    public Item(ItemType itemType, int amount, GameObject gameObject = null)
    {
        this.itemType = itemType;
        this.amount = amount;
        this.associatedGameObject = gameObject;
    }
}
