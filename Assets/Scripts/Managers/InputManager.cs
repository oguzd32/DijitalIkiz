using System;
using Building;
using Building.Data;
using Core.Camera;
using Core.Utilities;
using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(CameraController))]
    public class InputManager : Singleton<InputManager>
    {             
        public LayerMask buildingLayer;

        public event Action<ClickableBuilding> clickBuilding;

        public BuildingData buildingData;

        private ClickableBuilding currentBuilding;
        
        // cached component(s)
        private Camera _cam;

        private void Start()
        {
            _cam = GetComponent<Camera>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ClickBuildingProcess();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                IncreseOrderCode();
                IncreaseItemCode();
                IncreaseOrderCount();
            }
        }

        private void IncreaseOrderCount()
        {
            buildingData.orderCount = Mathf.Clamp(
                buildingData.orderCount + 50,
                0,
                buildingData.maxOrderCount
                );
        }

        private void IncreaseItemCode()
        {
            string frontItem = buildingData.orderCode.Substring(0, 2);
            string numericPartItem = buildingData.orderCode.Substring(2);
            int itemCodeNumb = Int32.Parse(numericPartItem);
            itemCodeNumb++;
            buildingData.orderCode = frontItem + itemCodeNumb.ToString();
        }

        private void IncreseOrderCode()
        {
            string frontOrder = buildingData.orderCode.Substring(0, 2);
            string numericPartOrder = buildingData.orderCode.Substring(2);
            int orderCodeNumb = Int32.Parse(numericPartOrder);
            orderCodeNumb++;
            buildingData.orderCode = frontOrder + orderCodeNumb.ToString();
        }

        private void ClickBuildingProcess()
        {                      
            if(currentBuilding != null)
            {
                if (currentBuilding.opened) return;
            }

            RaycastHit hit;

            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f, buildingLayer))
            {                
                ClickableBuilding building = hit.transform.GetComponent<ClickableBuilding>();
                building.ClickThisBuilding();
                currentBuilding = building;
                clickBuilding?.Invoke(building);
            }
        }
    }
}