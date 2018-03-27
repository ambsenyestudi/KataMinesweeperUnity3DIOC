using System.Collections.Generic;
using System.Linq;

public class GameEvaluationService : IGameEvaluationService
{
    public bool IsGameWon(IList<TileModel> tiles)
    {
        List<TileModel> coveredTiles = tiles.Where(t => t.IsUncovered == false).ToList();
        List<TileModel> nonBombTiles = coveredTiles.Where(t => t.HiddenItem != TileItemEnum.Bomb).ToList();
        return nonBombTiles.Count == 0;
    }
}
