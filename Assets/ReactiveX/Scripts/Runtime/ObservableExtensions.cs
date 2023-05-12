using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityReactiveExtensions
{
    public static class ComponentExtensions
    {
        public static T GetOrAddChild<T>(this GameObject gameObject, string path)
            where T : UnityEngine.Component
        {
            var component = gameObject.GetComponentInChildren<T>();
            if (component == null)
            {
                var child = GameObject.Instantiate(Resources.Load(path), gameObject.transform) as GameObject;

                component = child.GetComponent<T>();
            }

            return component;
        }

        public static T GetOrAddComponent<T>(this GameObject gameObject)
            where T : UnityEngine.Component
        {
            var component = gameObject.GetComponent<T>();
            if (component == null)
            {
                component = gameObject.AddComponent<T>();
            }

            return component;
        }

        public static void AddTo(this IDisposable disposable, UnityEngine.Component component)
        {
            var trigger = component.gameObject.GetOrAddChild<ObservableAutoDispose>("ObservableAutoDispose");
            trigger.AddDisposable(disposable);
        }
    }

    public static class LifecycleExtensions
    {
        public static IObservable<GameObject> OnEnableAsObservable(this GameObject gameObject)
        {
            var trigger = gameObject.GetOrAddChild<LifecycleTrigger>("ObservableTrigger");
            return trigger.onEnableAsObservable;
        }

        public static IObservable<GameObject> OnDisableAsObservable(this GameObject gameObject)
        {
            var trigger = gameObject.GetOrAddChild<LifecycleTrigger>("ObservableTrigger");
            return trigger.onDisableAsObservable;
        }

        public static IObservable<GameObject> OnStartAsObservable(this GameObject gameObject)
        {
            var trigger = gameObject.GetOrAddChild<LifecycleTrigger>("ObservableTrigger");
            return trigger.onStartAsObservable;
        }


    }

    public static class ButtonExtensions
    {
        public static IObservable<Button> OnClickAsObservable(this Button button)
        {
            var trigger = button.gameObject.GetOrAddComponent<ButtonTrigger>();
            return trigger.onClickAsObservable;
        }
    }
}

