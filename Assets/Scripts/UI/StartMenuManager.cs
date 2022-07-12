using UnityEngine;

public class StartMenuManager : MonoBehaviour
{

    [SerializeField] private GameObject[] menuObjects;
    [SerializeField] private int targetIndex;

    public void SetTargetIndex(int i)
    {
        targetIndex = i;
    }

    public void ChangeActiveMenu()
    {
        foreach (var item in menuObjects)
        {
            item.gameObject.SetActive(false);
        }

        menuObjects[targetIndex].SetActive(true);
    }



}
