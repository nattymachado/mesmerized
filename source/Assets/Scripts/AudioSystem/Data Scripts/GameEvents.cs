﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static class UIEvents
    {
        public static Action<GameEnums.PatientEnum> OpenPatientRecord;
        public static Action<bool> OpenMenu;
    }

    public static class AudioEvents
    {
        public static Action<float> SetBGMVolume;
        public static Action<float> SetSFXVolume;
        public static Action<string, bool, bool> TriggerSFX;
        public static Action<string, bool, bool> TriggerRandomSFX;
    }

    public static class FSMEvents
    {
        public static Action FinishedInteraction;
        public static Action<GameEnums.FSMInteractionEnum> StartInteraction;
    }
}
