using System;
using UnityEngine;

namespace GameOfTransforms.Transformation.TransformationMatricesSettings
{
    [Serializable]
    public struct TransformationMatrixSetting
    {
        [SerializeField] private int probability;
        public int Probability => probability;
        
        [SerializeField] private Direction2ProbabilityDict directions2Probabilities;
        public Direction2ProbabilityDict Directions2Probabilities => directions2Probabilities;
    }
}
