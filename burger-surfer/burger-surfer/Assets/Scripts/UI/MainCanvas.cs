using UnityEngine;

namespace Scripts.UI
{
    public class MainCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _serveButton;

        public void ActiveButton()
        {
            _serveButton.SetActive(true);
        }
    }
}
