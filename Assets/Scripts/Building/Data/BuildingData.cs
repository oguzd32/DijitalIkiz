using UnityEngine;

namespace Building.Data
{
    [CreateAssetMenu(fileName = "Building", menuName = "BuildingData", order = 0)]
    public class BuildingData : ScriptableObject
    {
        public Sprite icon;
        public string buildingName;
        public string orderCode;
        public string itemCode;
        public int orderCount;
        public int maxOrderCount;
        public int oeePercentage;
        public int stoveTemperature;
        public int stoveWeight;
        public int topMoldTemperature;
        public int bottomMoldTemperature;
        public float acceleration;
        public float pressure;
    }
}