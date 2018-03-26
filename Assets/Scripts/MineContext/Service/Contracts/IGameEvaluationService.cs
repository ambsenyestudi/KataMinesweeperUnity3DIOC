using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IGameEvaluationService
{
    bool IsGameWon(IList<TileModel> tiles);
}
