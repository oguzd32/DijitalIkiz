using TMPro;

namespace UI
{
    public class NameBoardUI : BaseUI
    {
        public TextMeshProUGUI nameText;

        private void Start()
        {
            Show();
        }

        public void SetName(string name)
        {
            nameText.text = name;
        }
    }
}