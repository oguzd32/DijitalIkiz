using System;
using UnityEngine;

namespace UI
{
    public class BaseUI : MonoBehaviour
    {
        /// <summary>
        /// Canvas to disable. If this object is set, then the canvas is disabled instead of the game object 
        /// </summary>
        public Canvas _canvas;

        /// <summary>
        /// Activates this UI
        /// </summary>
        public virtual void Show()
        {
            if (_canvas != null)
            {
                _canvas.enabled = true;
            }
            else
            {
                gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// Deactivates this UI
        /// </summary>
        public virtual void Hide()
        {
            if (_canvas != null)
            {
                _canvas.enabled = false;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}