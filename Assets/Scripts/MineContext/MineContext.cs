using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineContext : MVCSContext
{

    public MineContext(MonoBehaviour view) : base(view)
    {

    }
    public MineContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
    {
    }
    protected override void mapBindings()
    {
        //Injection binding.
        //Models and Services
        injectionBinder.Bind<ITileService>().To<TileService>().ToSingleton();
        injectionBinder.Bind<ITilePositionComparisonService>().To<TilePositionComparisonService>().ToSingleton();
        injectionBinder.Bind<ISurroundingIndexService>().To<SurroundingIndexService>().ToSingleton();
        injectionBinder.Bind<IGameEvaluationService>().To<GameEvaluationService>().ToSingleton();

        //View/Mediator binding
        mediationBinder.Bind<TileView>().To<TileMediator>();
        mediationBinder.Bind<TileCoverView>().To<TileCoverMediator>();

        //Event/Command binding
        //The START event is fired as soon as mappings are complete.
        //Note how we've bound it "Once". This means that the mapping goes away as soon as the command fires.

        commandBinder.Bind(ContextEvent.START).To<StratupCommand>().Once();
        commandBinder.Bind(EventConstants.RegisterTile).To<RegisterTileCommand>();
        commandBinder.Bind(EventConstants.ClickedOn).To<UncoverTileCommand>();
        commandBinder.Bind(EventConstants.Explosion).To<GameOverCommand>();
        commandBinder.Bind(EventConstants.UncoverEmptyNeighbours).To<UncoverEmptyNeigboursCommand>();
        commandBinder.Bind(EventConstants.LastTileUncovered).To<GameWonCommand>();
        


    }
}
