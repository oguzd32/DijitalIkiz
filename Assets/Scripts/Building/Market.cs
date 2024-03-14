using System;
using Building.Data;
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
        }
    }
}