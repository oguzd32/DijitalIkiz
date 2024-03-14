using UnityEngine;

namespace UI
{
    [ExecuteInEditMode]
    public class BillBoard : MonoBehaviour
    {
        private Camera _camera;

        /// <summary>
        /// UI elements are looking camera
        /// </summary>
        private void Update()
        {
            if (_camera == null)
            {
                _camera = FindObjectOfType<Camera>();
            }

            if (_camera == null) return;
        
            transform.LookAt(_camera.transform);
            transform.Rotate(Vector3.up * 180);
        }
    }
}