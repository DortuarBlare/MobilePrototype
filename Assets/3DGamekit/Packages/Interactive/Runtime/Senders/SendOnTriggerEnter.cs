using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Analytics;


namespace Gamekit3D.GameCommands
{

    public class SendOnTriggerEnter : TriggerCommand
    {
        public LayerMask layers;

        void OnTriggerEnter(Collider other)
        {
            if (0 != (layers.value & 1 << other.gameObject.layer))
            {
                Send();
                
                Dictionary<string, object> analytics = new Dictionary<string, object>
                {
                    { "TriggeredObjectTag", gameObject.tag },
                    { "TriggeredByObjectTag", other.gameObject.tag },
                    { "Position", transform.position }
                };
                
                AnalyticsResult analyticsResult = Analytics.CustomEvent(
                    "Triggered",
                    analytics
                );

                string dictionaryKeys = "";
                foreach (var key in analytics.Keys)
                {
                    dictionaryKeys += key.ToString() + ", ";
                }
                
                string dictionaryValues = "";
                foreach (var value in analytics.Values)
                {
                    dictionaryValues += value.ToString() + ", ";
                }
                
                Debug.Log("Analytics result: " + analyticsResult);
                Debug.Log("Analytics dictionary keys: " + dictionaryKeys + "\n" +
                          "Analytics dictionary values: " + dictionaryValues);
            }
        }
    }
}
