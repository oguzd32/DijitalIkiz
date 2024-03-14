using Assets.Scripts.UI;
using Building;
using Managers;
using System.Collections;
using UnityEngine;

namespace Core.Camera
{
    public class CameraController : MonoBehaviour
    {
        [Header("Zoom Parameters")]
        public float zoomSpeed = 1.0f;
        public float minDistance = 1.0f;
        public float maxDistance = 10.0f;
        public float zoomTime = 0.5f;       

        /// <summary>
        /// Camera's looking target
        /// </summary>
        public Transform target;

        private Coroutine zoomRoutine;
        private bool zooming;

        /// <summary>
        /// Subscribe zoom in and zoom out method for when calling
        /// </summary>
        private void Start()
        {
            InputManager.instance.clickBuilding += ZoomCameraToTarget;
            MainUI.instance.backButton.onClick.AddListener(ZoomOutCameraToTarget);
        }

        /// <summary>
        /// Unsubcribe
        /// </summary>
        private void OnDestroy()
        {
            if (InputManager.instanceExists)
            {
                InputManager.instance.clickBuilding -= ZoomCameraToTarget;
            }

            if (MainUI.instanceExists)
            {
                MainUI.instance.backButton.onClick.RemoveListener(ZoomOutCameraToTarget);
            }
        }

        /// <summary>
        /// Set target
        /// </summary>
        /// <param name="target">Desired Target</param>
        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        /// <summary>
        /// Looking target after all updates
        /// </summary>
        private void LateUpdate()
        {
            if(target == null) return;
            
            transform.LookAt(target);
        }
        
        public void ZoomCameraToTarget(ClickableBuilding building)
        {
            if(zooming) return;

            zooming = true;

            if(zoomRoutine != null) 
            { 
                StopCoroutine(zoomRoutine); 
                zoomRoutine = null; 
            }
            zoomRoutine = StartCoroutine(ZoomProcess(-1));           
        }

        public void ZoomOutCameraToTarget()
        {
            if(zooming) return;

            zooming = true;

            if (zoomRoutine != null)
            {
                StopCoroutine(zoomRoutine);
                zoomRoutine = null;
            }
            zoomRoutine = StartCoroutine(ZoomProcess(1));            
        }        

        /// <summary>
        /// Zoom in or zoom out smoothly
        /// </summary>
        /// <param name="value">-1 for in +1 for out</param>
        /// <returns></returns>
        private IEnumerator ZoomProcess(float value)
        {
            float timer = zoomTime;

            while (timer > 0f) 
            {
                zooming = true;

                float currentDistance = Vector3.Distance(transform.position, target.position);

                float newDistance = Mathf.Clamp(currentDistance - Time.deltaTime * value * zoomSpeed, minDistance, maxDistance);
                
                Vector3 newPosition = transform.position + transform.forward * (newDistance - currentDistance);
                transform.position = newPosition;

                timer -= Time.deltaTime;

                yield return new WaitForSeconds(Time.deltaTime);  
            }

            zooming = false;
        }
    }
}

