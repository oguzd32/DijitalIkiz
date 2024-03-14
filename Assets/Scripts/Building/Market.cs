using Building.Data;
using System.Collections;
using UI;

namespace Building
{
    public class Market : ClickableBuilding
    {        
        public NameBoardUI nameDisplay;
        public FeaturesUI featuresDisplay;
        public BuildingData data;

        private void Start()
        {
            nameDisplay.SetName(data.buildingName);
            featuresDisplay.data = data;
        }

        /// <summary>
        /// When user click this building fired this method
        /// </summary>
        public override void ClickThisBuilding()
        {
            base.ClickThisBuilding();

            if(featuresDisplay._canvas.enabled) { return; }

            nameDisplay.Hide();
            featuresDisplay.Show();
        }

        /// <summary>
        /// When user click back button fired this method
        /// </summary>
        public override void CloseBuilding()
        {
            base.CloseBuilding();

            if (nameDisplay._canvas.enabled) { return; }

            nameDisplay.Show();
            featuresDisplay.Hide();
        }        
    }
}