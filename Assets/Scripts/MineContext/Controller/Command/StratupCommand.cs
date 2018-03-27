using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

public class StratupCommand : EventCommand
{

    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }

    [Inject]
    public ITileService tileService { get; set; }

    public override void Execute()
    {
        //TODO startup
    }
    
}