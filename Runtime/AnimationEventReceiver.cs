using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace ImprovedUnityAnimationEvents {
    public class AnimationEventReceiver : MonoBehaviour {
        [SerializeField] List<AnimationEvent> animationEvents = new();

        AnimationEvent GetEvent(string eventName) =>
            animationEvents.Find(se => se.eventName == eventName);

        public void AddListener(string eventName, UnityAction call) {
            var animationEvent = GetEvent(eventName);
            if (animationEvent == null) {
                animationEvent = new AnimationEvent() {
                    eventName = eventName,
                    OnAnimationEvent = new ()
                };
                animationEvents.Add(animationEvent);
            }
            animationEvent.OnAnimationEvent.AddListener(call);
        }

        public void RemoveListener(string eventName, UnityAction call) {
            var animationEvent = GetEvent(eventName);
            Debug.Assert(animationEvent != null,
                         $"Trying to remove listener from non-existent animation event '{eventName}'");
            animationEvent.OnAnimationEvent.RemoveListener(call);
        }

        public void OnAnimationEventTriggered(string eventName) {
            AnimationEvent matchingEvent = GetEvent(eventName);
            matchingEvent?.OnAnimationEvent?.Invoke();
        }
    }
}
