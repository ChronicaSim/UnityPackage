using System;
using System.Reactive.Disposables;
using UnityEngine;

namespace UnityReactiveExtensions
{
    public class ObservableAutoDispose : MonoBehaviour
    {
        private CompositeDisposable disposables { get; } = new CompositeDisposable();

        void OnDestroy()
        {
            disposables.Dispose();
        }

        public void AddDisposable(IDisposable disposable)
        {
            disposables.Add(disposable);
        }
    }
}

