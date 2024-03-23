using System;
using System.Collections;
using System.Collections.Generic;
using Factories;
using UnityEngine;
using Zenject;

public class Initializer : MonoBehaviour
{
    private IUIFactory _uiFactory;

    [Inject]
    public void Constructor(IUIFactory uiFactory)
    {
        _uiFactory = uiFactory;
    }

    private void Start()
    {
        _uiFactory.CreateMainUserInterface();
    }
}