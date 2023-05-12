using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityReactiveExtensions.Samples
{
    public class LoopObserve : MonoBehaviour
    {
        public Component subject;

        void Awake()
        {
            subject.gameObject.OnEnableAsObservable().Subscribe(obj =>
            {
                Debug.Log($"{obj} enable");
            }).AddTo(this);

            subject.gameObject.OnStartAsObservable().Subscribe(obj =>
            {
                Debug.Log($"{obj} start");
            }).AddTo(this);

            subject.gameObject.OnDisableAsObservable().Subscribe(obj =>
            {
                Debug.Log($"{obj} disable");
            }).AddTo(this);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

