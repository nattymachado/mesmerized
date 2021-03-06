﻿using UnityEngine;
using System.Collections;


public class PlanetMachineButtonBehaviour : InteractableItemBehaviour
{
    [SerializeField] public GameObject planet;
    [SerializeField] GameObject support;
    [SerializeField] GameObject planetAndSupport;
    [SerializeField] float speed;
    [SerializeField] public bool isOn = false;
    [SerializeField] public PlanetMachineBehaviour planetMachine;
    [SerializeField] public Transform rotatePoint;
    [SerializeField] public int position;
    [SerializeField] private Material _materialWithLight;
    [SerializeField]  private Material _originalMaterial;
    [SerializeField] private Animator _planetMachineSupportAnimator;
    private MeshRenderer _renderer;
    private Animator _animator;
    private bool _canRotate = false;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _animator = GetComponent<Animator>();
    }


    protected override void ExecuteAction(CharacterBehaviour character)
    {
        if (!isOn)
        {
            GameEvents.AudioEvents.TriggerSFX.SafeInvoke("NotOn", false, true);
            _planetMachineSupportAnimator.SetTrigger("highlight");
            _animator.SetTrigger("Pressed");
            SetActive(false);
            return;
        }
        _canRotate = true;
        _renderer.material = _materialWithLight;
        GameEvents.AudioEvents.TriggerSFX.SafeInvoke("Rattle", false, true);
    }

    private void OnTriggerExit(Collider other)
    {
        _renderer.material = _originalMaterial;
    }

    private void Update()
    {
        if (!isOn)
        {
            return;
        }
        if (_canRotate && planetAndSupport != null)
        {

            _animator.SetTrigger("Pressed");
            planetAndSupport.GetComponent<Animator>().SetTrigger("Rotate");
            _canRotate = false;
            SetActive(false);
            position++;
            if (position > 4)
            {
                position = 1;
            }
            planetMachine.CheckPlanets();
        }
    }


}

