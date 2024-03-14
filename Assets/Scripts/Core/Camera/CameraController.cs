using UnityEngine;

namespace Core.Camera
{
    public class CameraController : MonoBehaviour
    {

        public Vector3 offSet;
        //protected Transform target { get; private set; }

        public Transform target;

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        private void LateUpdate()
        {
            if(target == null) return;
            
            transform.LookAt(target);
        }
    }
}
