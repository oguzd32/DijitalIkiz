using TMPro;
using UnityEngine;

namespace UI
{
    public class NameBoardUI : MonoBehaviour
    {
        public TextMeshProUGUI nameText;

        public void SetName(string name)
        {
            nameText.text = name;
        }
    }
}