using Building.Data;
using UnityEngine;

namespace Assets.Scripts.Test
{
    public class RandomDataGenerator : MonoBehaviour
    {
        private float OEEChangeIntervalSeconds = 60;

        public BuildingData data;

        private float oeeTimer = 0;
        private float timer = 0;

        private void Update()
        {
            oeeTimer += Time.deltaTime;
            timer += Time.deltaTime;

            if(oeeTimer > OEEChangeIntervalSeconds) 
            {
                data.oeePercentage = Random.Range(75, 86);
                oeeTimer = 0;
            }

            if(timer > 1f)
            {
                timer = 0.0f;

                data.stoveTemperature += (int)FiftyFifty(data.stoveTemperature);
                data.stoveWeight += (int)FiftyFifty(data.stoveWeight);
                data.topMoldTemperature += (int)FiftyFifty(data.topMoldTemperature);
                data.bottomMoldTemperature += (int)FiftyFifty(data.bottomMoldTemperature);
                data.acceleration += FiftyFifty(data.acceleration);
                data.pressure += FiftyFifty(data.pressure);
            }
        }

        private float FiftyFifty(float value)
        {
            float random = Random.Range(0, 1f);

            if(random > 0.5f) { return value * 0.1f; }
            else { return value * -0.1f; }
        }
    }
}