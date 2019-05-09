﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace prototypeRobot
{
    public class ShapeControllerBehaviour : MonoBehaviour
    {

        [SerializeField] public string[] sequece = new string[4];
        [SerializeField] public Material right;
        [SerializeField] public Material wrong;
        [SerializeField] public GameObject card3;
        //[SerializeField] public GameObject item1;
        private int position = 0;

        public void CheckShapePosition(string shape, MeshRenderer shapeMesh)
        {
            if (sequece[position] == shape)
            {
                GameEvents.AudioEvents.TriggerRandomSFX.SafeInvoke("ButtonClick", false);
                shapeMesh.material = right;
                position += 1;
            } else
            {
                shapeMesh.material = wrong;
                IEnumerator  coroutine = WaitAndClear(1.0f);
                StartCoroutine(coroutine);
            }
            shapeMesh.enabled = true;
            if (position == sequece.Length)
            {
                GameEvents.AudioEvents.TriggerSFX.SafeInvoke("GenerateKeycard", false);
                card3.SetActive(true);
                //item1.SetActive(true);
            }
        }

 
        private IEnumerator WaitAndClear(float waitTime)
        {
            GameEvents.AudioEvents.TriggerSFX.SafeInvoke("Does-not-compute", false);
            yield return new WaitForSeconds(waitTime);
            ShapeButtonBehaviour[] buttons = GetComponentsInChildren<ShapeButtonBehaviour>();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Clear();
            }
            position = 0;
           
        }


    }
}