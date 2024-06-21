using UnityEngine;

namespace BGS_Shop.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        private InteractPopUp _popUp; 
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
            }
            Instance = this;
            _popUp = GetComponentInChildren<InteractPopUp>();
            _popUp.gameObject.SetActive(false);
        }

        public void ClosePanel(CanvasRenderer panel)
        {
            panel.gameObject.SetActive(false);
        }
        
        public void OpenPanel(CanvasRenderer panel)
        {
            panel.gameObject.SetActive(true);
        }
        
        public void OpenInteractPopUp()
        {
            _popUp.gameObject.SetActive(true);
        } 
        
        public void CloseInteractPopUp()
        {
            _popUp.gameObject.SetActive(false);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
    
}

