using Building;
using Core.Utilities;
using Managers;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MainUI : Singleton<MainUI>
    {
        public Button backButton;

        private ClickableBuilding currentBuilding;

        private void Start()
        {
            if (InputManager.instanceExists)
            {
                InputManager.instance.clickBuilding += OnClickBuilding;
            }
            backButton.onClick.AddListener(OnClickBackButton);

            backButton.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            if(InputManager.instanceExists)
            {
                InputManager.instance.clickBuilding -= OnClickBuilding;
            }
            
            backButton.onClick.RemoveListener(OnClickBackButton);
        }

        private void OnClickBuilding(ClickableBuilding building)
        {
            backButton.gameObject.SetActive(true);
            currentBuilding = building;
        }

        private void OnClickBackButton()
        {
            currentBuilding.CloseBuilding();
            backButton.gameObject.SetActive(false);
        }
    }
}