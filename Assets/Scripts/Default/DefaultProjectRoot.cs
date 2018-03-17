using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectRoot : ContextView
{
    void Awake()
    {
        //Instantiate the context, passing it this instance.
        context = new DefaultContext(this);
    }
}
