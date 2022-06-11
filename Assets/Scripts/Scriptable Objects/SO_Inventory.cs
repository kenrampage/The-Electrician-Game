using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "SO_Inventory", menuName = "Lost-Relic-Game-Jam-1/SO_Inventory", order = 0)]
public class SO_Inventory : ScriptableObject 
{
    public SO_InventoryItem[] inventoryItems;
    public int currentItem;
    public int defaultItem;
    public UnityEvent onItemChange;
}
