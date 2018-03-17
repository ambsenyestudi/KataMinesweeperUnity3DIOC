using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultContext : MVCSContext
{

    public DefaultContext(MonoBehaviour view) : base(view)
    {
    }
    public DefaultContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
    {
    }
    protected override void mapBindings()
    {
        //Injection binding.
        //Models and Services
       
        //View/Mediator binding

        //Event/Command binding
        //The START event is fired as soon as mappings are complete.
        //Note how we've bound it "Once". This means that the mapping goes away as soon as the command fires.
        //commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();

    }
}
