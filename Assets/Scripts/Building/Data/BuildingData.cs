using UnityEngine;

namespace Building.Data
{
    [CreateAssetMenu(fileName = "Building", menuName = "BuildingData", order = 0)]
    public class BuildingData : ScriptableObject
    {
        public string buildingName;
    }
}