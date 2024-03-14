using Building.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FeaturesUI : BaseUI
    {
        public Image icon;

        [Header("Text References")]
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI orderNumberText;
        public TextMeshProUGUI itemCodeText;
        public TextMeshProUGUI orderCountText;
        public TextMeshProUGUI oeePercentageText;
        public TextMeshProUGUI stoveTempereratureText;
        public TextMeshProUGUI stoveWeightText;
        public TextMeshProUGUI topMoldTemperatureText;
        public TextMeshProUGUI bottomMoldTemperatureText;
        public TextMeshProUGUI acceleratorText;
        public TextMeshProUGUI pressureText;

        string symbol = "\u00B0";

        [Header("Sliders")]
        public Image orderSlider;
        public Image oeeSlider;

        [Space]

        public Button infoButton;

        public BuildingData data;

        private void Start()
        {
            Hide();
            infoButton.onClick.AddListener(OnClickInfoButton);
        }

        private void OnDestroy()
        {
            infoButton.onClick.RemoveListener(OnClickInfoButton);
        }

        private void Update()
        {
            if (data == null) return;

            UpdateDisplay(data);
        }

        public void UpdateDisplay(BuildingData data)
        {
            icon.sprite = data.icon;    
            nameText.text = data.buildingName;

            orderNumberText.text = $"Sipariş Numarası\r\n{data.orderCode}";
            itemCodeText.text = $"Malzeme Kodu\r\n{data.itemCode}";

            orderCountText.text = $"{data.orderCount}/{data.maxOrderCount}";
            orderSlider.fillAmount = ((float)data.orderCount / data.maxOrderCount);
            oeePercentageText.text = "%" + data.oeePercentage.ToString();
            oeeSlider.fillAmount = (float)data.oeePercentage / 100;

            stoveTempereratureText.text = $"Ocak Sıcaklığı\r\n{data.stoveTemperature}°C";
            stoveWeightText.text = $"Ocak Ağırlığı\r\n{data.stoveWeight} kg";
            topMoldTemperatureText.text = $"Üst Kalıp Sıcaklığı\r\n{data.topMoldTemperature}°C";
            bottomMoldTemperatureText.text = $"Alt Kalıp Sıcaklığı\r\n{data.bottomMoldTemperature}°C";           
            acceleratorText.text = string.Format("İvme {0:F4} mm/s<sup>2</sup>", data.acceleration);
            pressureText.text = string.Format("Basınç {0:F4}", data.pressure);           
        }

        private void OnClickInfoButton()
        {
            Application.OpenURL("https://www.google.com/");
        }
    }
}