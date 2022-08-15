using UnityEngine;

// Handles the physical size and shape of the cable
public class CableTransform : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private GameObject _endPoint;
    [SerializeField] private GameObject _cableBody;

    [Header("Settings")]
    [SerializeField] private float _maxCableLength;

    private Vector3 _initialScale;
    private float _currentLength;

    private Cable _cable;

    private bool _isEditModeOn;
    private bool _isPreviewModeOn;

    private void OnEnable()
    {
        _cable = GetComponent<Cable>();
        _initialScale = _cableBody.transform.localScale;

        SetCableTransform();
    }

    // Update is called once per frame
    void Update()
    {


        if (_isPreviewModeOn)
        {
            SetCableTransform();
        }
        else if (_isEditModeOn)
        {
            SetCableTransform();

            if (_currentLength >= _maxCableLength)
            {
                _cable.DestroyCable();
                return;
            }

            _endPoint.transform.position = PlayerHoldPosition.Position;
        }
    }

    private void SetCableTransform()
    {
        //Get _currentLength between points
        _currentLength = Vector3.Distance(_startPoint.transform.position, _endPoint.transform.position);

        //sets scale based on _currentLength between points
        _cableBody.transform.localScale = new Vector3(_initialScale.x, _currentLength / 2f, _initialScale.z);

        //Gets position direction in the middle between points
        Vector3 middlePoint = (_startPoint.transform.position + _endPoint.transform.position) / 2f;

        //Sets _cable position to middle point
        _cableBody.transform.position = middlePoint;

        //Gets rotation direction between points
        Vector3 rotationDir = (_endPoint.transform.position - _startPoint.transform.position);
        _cableBody.transform.up = rotationDir;

    }

    #region Bool set/get methods
    private void EditModeOn()
    {
        _isEditModeOn = true;
    }

    private void EditModeOff()
    {
        _isEditModeOn = false;
        SetCableTransform();
    }

    private void PreviewModeOn()
    {
        _isPreviewModeOn = true;
    }

    private void PreviewModeOff()
    {
        _isPreviewModeOn = false;
    }
    #endregion

    #region Public Methods
    public void SetStartPosition(Vector3 pos)
    {
        _startPoint.transform.position = pos;
    }

    public void SetEndPosition(Vector3 pos)
    {
        _endPoint.transform.position = pos;
    }

    public void Install()
    {
        PreviewModeOff();
        EditModeOff();
    }

    public void Edit()
    {
        EditModeOn();
        PreviewModeOff();
    }

    public void Preview(Vector3 pos)
    {
        SetEndPosition(pos);
        PreviewModeOn();
    }
    #endregion

}
