using UnityEngine;

namespace GameOfTransform.CartesianPlane
{
    [CreateAssetMenu(fileName = "Cartesian Plane Graphics Attributes", menuName = "Game Of Transforms/Cartesian Plane Graphics Attributes")]
    internal class CartesianPlaneGraphicsAttributes : ScriptableObject, ICartesianPlaneGraphicsAttributes
    {
        #region Implements ICartesianPlaneGraphicsAttributes

            #region Axis attributes

            [SerializeField] private Material cartesianAxisMaterial = default;
            public Material CartesianAxisMaterial => cartesianAxisMaterial;

            [SerializeField] private float cartesianAxisWidth = default;
            public float CartesianAxisWidth => cartesianAxisWidth;

            #endregion

            #region Lines attributes

            [SerializeField] private int linesOffset = default;
            public int LinesOffset => linesOffset;

            [SerializeField] private Material cartesianLinesMaterial = default;
            public Material CartesianLinesMaterial => cartesianLinesMaterial;

            [SerializeField] private float cartesianLinesWidth = default;
            public float CartesianLinesWidth => cartesianLinesWidth;

            #endregion

            #region Labels attributes
        
            [SerializeField] private GameObject labelPrefab = default;
            public GameObject LabelPrefab => labelPrefab;

            [SerializeField] private int labelOffset = default;
            public int LabelsOffset => labelOffset;

            [SerializeField] private float labelDistance = default;
            public float LabelDistance => labelDistance;

            #endregion

        #endregion
    }
}
