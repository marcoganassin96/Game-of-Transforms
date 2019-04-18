using UnityEngine;

namespace GameOfTransform.CartesianPlane
{
    public interface ICartesianPlaneGraphicsAttributes
    {        
        #region Axis attributes

        Material CartesianAxisMaterial { get; }
        float CartesianAxisWidth { get; }

        #endregion

        #region Lines attributes

        int LinesOffset { get; }
        Material CartesianLinesMaterial { get; }
        float CartesianLinesWidth { get; }

        #endregion

        #region Labels attributes

        GameObject LabelPrefab { get; }
        int LabelsOffset { get; }
        float LabelDistance { get; }

        #endregion
    }
}
