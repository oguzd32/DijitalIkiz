using System.Collections;
using UnityEngine;

namespace Building
{
    /// <summary>
    /// Clickable buildings must have a collider for raycasting
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public abstract class ClickableBuilding : MonoBehaviour
    {
        /// <summary>
        /// Is building opened or not
        /// </summary>
        public bool opened {  get; protected set; }

        public virtual void ClickThisBuilding()
        {
            opened = true;
        }

        public virtual void CloseBuilding()
        {
            StartCoroutine(OpenedDelayed());
        }

        private IEnumerator OpenedDelayed()
        {
            yield return new WaitForSeconds(1f);

            opened = false;
        }
    }
}