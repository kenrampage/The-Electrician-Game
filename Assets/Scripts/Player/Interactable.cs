using UnityEngine;

[System.Serializable]
public class Interactable : MonoBehaviour
{
    public enum Type
    {
        WALLON,
        WALLOFF,
        NODEPOWEROFF,
        NODEPOWERON,
        WIRE
    }

    [SerializeField] private Type _type;

    public Type GetInteractableType()
    {
        return _type;
    }

    public void SetInteractableType(Type type)
    {
        _type = type;
    }
}

