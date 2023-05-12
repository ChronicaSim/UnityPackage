using System.Reactive.Subjects;
using UnityEngine;

namespace UnityReactiveExtensions
{
    public class LifecycleTrigger : MonoBehaviour
    {
        public Subject<GameObject> onEnableAsObservable { get; } = new Subject<GameObject>();
        public Subject<GameObject> onDisableAsObservable { get; } = new Subject<GameObject>();
        public Subject<GameObject> onAwakeAsObservable { get; } = new Subject<GameObject>();
        public Subject<GameObject> onStartAsObservable { get; } = new Subject<GameObject>();


        void Start()
        {
            onStartAsObservable.OnNext(this.gameObject);
        }

        void OnEnable()
        {
            onEnableAsObservable.OnNext(this.gameObject);
        }

        void OnDisable()
        {
            onDisableAsObservable.OnNext(this.gameObject);
        }


    }
}

