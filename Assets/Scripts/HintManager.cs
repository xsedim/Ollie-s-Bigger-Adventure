using UnityEngine;
using UnityEngine.Events;

namespace Circle
{
    public class HintManager : MonoBehaviour
    {
        private static readonly int Shown = Animator.StringToHash("Shown");
        
        [SerializeField] private TriggerEventWrapper[] triggers;
        [SerializeField] private GameObject[] hintBubbles;
        [SerializeField] private Animator animator;
        
        private int progress = 0;
        private GameObject activeHint;
        
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
            if (activeHint) {
                activeHint.SetActive(false);
            }
            hintBubbles[progress].SetActive(true);
            activeHint = hintBubbles[progress];
            animator.SetBool(Shown, true);
        }

        private void HideHint() {
            progress++;
            animator.SetBool(Shown, false);
        }
    }
}
