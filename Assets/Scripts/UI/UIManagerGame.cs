using UnityEngine;

namespace RampageUtils.UI
{
    // Bespoke manager for easily swapping between game ui menus and triggering in/out animations
    public class UIManagerGame : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject _startUI;
        [SerializeField] private GameObject _gameUI;
        [SerializeField] private GameObject _endUI;
        [SerializeField] private GameObject _pauseUI;

        private Anim_ClipboardVert _startUIAnim;
        private Anim_ClipboardVert _gameUIAnim;
        private Anim_ClipboardVert _endUIAnim;
        private Anim_ClipboardVert _pauseUIAnim;

        private void Awake()
        {
            GetAnimReferences();
        }

        private void GetAnimReferences()
        {
            _startUIAnim = _startUI.GetComponent<Anim_ClipboardVert>();
            _gameUIAnim = _gameUI.GetComponent<Anim_ClipboardVert>();
            _endUIAnim = _endUI.GetComponent<Anim_ClipboardVert>();
            _pauseUIAnim = _pauseUI.GetComponent<Anim_ClipboardVert>();
        }

        public void StartUIOn()
        {
            AllUIOff();
            _startUI.SetActive(true);
            _startUIAnim.ClipboardIn();
        }

        public void GameUIOn()
        {
            AllUIOff();
            _gameUI.SetActive(true);
        }

        public void PauseUIOn()
        {
            AllUIOff();
            _pauseUI.SetActive(true);
            _pauseUIAnim.ClipboardIn();
        }

        public void EndUIOn()
        {
            AllUIOff();
            _endUI.SetActive(true);
            _endUIAnim.ClipboardIn();
        }

        public void StartUIOff()
        {
            _startUIAnim.ClipboardOut();
        }

        public void GameUIOff()
        {
            _gameUI.SetActive(false);
        }


        public void PauseUIOff()
        {
            _pauseUIAnim.ClipboardOut();
        }

        public void EndUIOff()
        {
            _endUIAnim.ClipboardOut();
        }

        private void AllUIOff()
        {
            _startUI.SetActive(false);
            _gameUI.SetActive(false);
            _endUI.SetActive(false);
            _pauseUI.SetActive(false);
        }

    }


}
