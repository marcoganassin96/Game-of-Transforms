using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransforms.GameFlow
{
    public class GameFlowData
    {
        internal bool playerTurn = true;
        public bool PlayerTurn => playerTurn;

        internal List<Vector2> winningPointsPositions = default;
        public List<Vector2> WinningPointsPositions => winningPointsPositions;
    }
}
