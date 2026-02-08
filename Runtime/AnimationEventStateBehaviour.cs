using UnityEngine;
using UnityEngine.Events;

namespace ImprovedUnityAnimationEvents {
    public class AnimationEventStateBehaviour : StateMachineBehaviour {
        public string eventName;
        [Range(0f, 1f)] public float triggerTime;
        public bool repeat;

        float nextTriggerTime;
        AnimationEventReceiver receiver;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            nextTriggerTime = triggerTime;
            receiver = animator.GetComponent<AnimationEventReceiver>();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            float currentTime = stateInfo.normalizedTime;
            if (currentTime > nextTriggerTime) {
                NotifyReceiver(animator);
                nextTriggerTime = repeat ? nextTriggerTime + 1 : float.MaxValue;
            }
        }

        void NotifyReceiver(Animator animator) {
            if (receiver != null) {
                receiver.OnAnimationEventTriggered(eventName);
            }
        }
    }
}
