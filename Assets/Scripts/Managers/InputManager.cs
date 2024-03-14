using System;
using Building;
using Core.Camera;
using Core.Utilities;
using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(CameraController))]
    public class InputManager : Singleton<InputManager>
    {
        public event Action<ClickableBuilding> clickBuilding;
        
        public LayerMask buildingLayer;
        
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
        }

        private void ClickBuildingProcess()
        {
            RaycastHit hit;

            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f, buildingLayer))
            {
                ClickableBuilding building = hit.transform.GetComponent<ClickableBuilding>();
                clickBuilding?.Invoke(building);
            }
        }
    }
}