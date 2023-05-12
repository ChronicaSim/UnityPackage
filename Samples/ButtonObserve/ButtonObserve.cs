using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityReactiveExtensions.Samples
{
    public class ButtonObserve : MonoBehaviour
    {
        public Button button;

        void Awake()
        {
            button.OnClickAsObservable().Subscribe(obj =>
            {
                Debug.Log($"{obj} is clicked");
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

