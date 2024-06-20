using UnityEngine;

namespace BGS_Shop.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
            }
            Instance = this;
        }

        public void ClosePanel(CanvasRenderer panel)
        {
            panel.gameObject.SetActive(false);
        }
        
        public void OpenPanel(CanvasRenderer panel)
        {
            panel.gameObject.SetActive(true);
        }
    }
    
}
