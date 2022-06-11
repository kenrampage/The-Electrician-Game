using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Item_", menuName = "Lost-Relic-Game-Jam-1/SO_InventoryItem", order = 0)]
public class SO_InventoryItem : ScriptableObject
{
    public string itemName;
    public int itemCount;
    public LayerMask targetLayer;
    public GameObject visualPrefab;
    public UnityEvent onInteract1;
    public UnityEvent onInteract1Fail;
    public UnityEvent onInteract2;
    public UnityEvent onInteract2Fail;

}
