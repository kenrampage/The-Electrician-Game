using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITargetTracker : MonoBehaviour
{
    private NodeManager _nodeManager;
    [SerializeField] private TextMeshProUGUI _completedText;
    [SerializeField] private TextMeshProUGUI _totalText;

    private void Awake()
    {
        _nodeManager = NodeManager.Instance;
        _nodeManager.OnTargetNodesCompleteChanged.AddListener(UpdateCompletedText);
    }

    private void Start()
    {
        UpdateTotalText();
        UpdateCompletedText();
    }

    private void UpdateTotalText()
    {
        _totalText.text = _nodeManager.GetTotalTargetNodes().ToString();
    }

    private void UpdateCompletedText()
    {
        _completedText.text = _nodeManager.GetCompletedTargetNodes().ToString();
    }
}
