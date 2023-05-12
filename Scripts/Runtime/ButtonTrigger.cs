using System;
using System.Reactive.Subjects;
using UnityEngine;
using UnityEngine.UI;

namespace UnityReactiveExtensions
{
    internal class ButtonTrigger : MonoBehaviour
    {
        public Subject<Button> onClickAsObservable { get; } = new Subject<Button>();

        void Start()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(() => onClickAsObservable.OnNext(button));
        }
    }
}