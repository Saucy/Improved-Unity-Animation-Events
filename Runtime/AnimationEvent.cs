using System;
using UnityEngine.Events;

namespace ImprovedUnityAnimationEvents {
    [Serializable]
    public class AnimationEvent {
        public string eventName;
        public UnityEvent OnAnimationEvent;
    }
}
