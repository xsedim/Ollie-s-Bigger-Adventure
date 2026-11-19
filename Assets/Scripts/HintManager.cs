using UnityEngine;
using UnityEngine.Events;

namespace Circle
{
    public class HintManager : MonoBehaviour
    {
        [SerializeField] private TriggerEventWrapper[] triggers;
        [SerializeField] private GameObject[] hintBubbles;

        private int progress = 0;

        private void Start() {
            foreach (GameObject hintBubble in hintBubbles) {
                hintBubble.SetActive(false);
            }
        }

        private void OnEnable() {
            foreach (TriggerEventWrapper trigger in triggers) {
                trigger.onTriggerEnter.AddListener(_ => ShowHint());
                trigger.onTriggerExit.AddListener(_ => HideHint());
            }
        }
        
        private void ShowHint() {
            hintBubbles[progress].SetActive(true);
        }

        private void HideHint() {
            hintBubbles[progress].SetActive(false);
            progress++;
        }
    }
}
