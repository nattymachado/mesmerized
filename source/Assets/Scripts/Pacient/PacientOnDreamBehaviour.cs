﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PacientOnDreamBehaviour : InteractableItemBehaviour
{
    [SerializeField] public string itemName;
    const string SCENE = "hospital";


    protected override void ExecuteAction(Collider other)
    {
        CharacterBehaviour character = other.GetComponent<CharacterBehaviour>();
        if (character && character.CheckInventaryObjectOnSelectedPosition(itemName))
        {
            GameEvents.FSMEvents.StartInteraction.SafeInvoke(GameEnums.FSMInteractionEnum.ActivateItem);
            GameEvents.FSMEvents.StartInteraction.SafeInvoke(GameEnums.FSMInteractionEnum.Victory);
            SceneManager.LoadScene(SCENE);
        }
    }
}

