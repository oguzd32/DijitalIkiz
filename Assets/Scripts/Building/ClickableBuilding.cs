using System;
using UnityEngine;

namespace Building
{
    [RequireComponent(typeof(Collider))]
    public abstract class ClickableBuilding : MonoBehaviour
    {
        public event Action onClick;

        private void OnMouseDown()
        {
            onClick?.Invoke();
        }
    }
}