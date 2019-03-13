using UnityEngine;

namespace GameOfTransforms
{
    public interface ICartesianPlaneAttributes
    {
        int Size { get; }

        #region Axis attributes

        Material CartesianAxisMaterial { get; }
        float CartesianAxisWidth { get; }

        #endregion

        #region Lines attributes

        Material CartesianLinesMaterial { get; }
        float CartesianLinesWidth { get; }
        int LinesOffset { get; }

        #endregion

        #region Labels attributes

        int LabelOffset { get; }
        GameObject LabelPrefab { get; }
        float LabelDistance { get; }

        #endregion

    }

    [CreateAssetMenu(fileName = "Cartesian Plane Attributes", menuName = "Game Of Transforms/Cartesian Plane Attributes")]
    public class CartesianPlaneAttributes : ScriptableObject, ICartesianPlaneAttributes
    {

        [SerializeField] private int size = default;
        public int Size => size;

        #region Axis attributes

        [SerializeField] private Material cartesianAxisMaterial = default;
        public Material CartesianAxisMaterial => cartesianAxisMaterial;

        [SerializeField] private float cartesianAxisWidth = default;
        public float CartesianAxisWidth => cartesianAxisWidth;

        #endregion

        #region Lines attributes

        [SerializeField] private Material cartesianLinesMaterial = default;
        public Material CartesianLinesMaterial => cartesianLinesMaterial;

        [SerializeField] private float cartesianLinesWidth = default;
        public float CartesianLinesWidth => cartesianLinesWidth;

        [SerializeField] private int linesOffset = default;
        public int LinesOffset => linesOffset;

        #endregion

        #region Labels attributes

        [SerializeField] private int labelOffset = default;
        public int LabelOffset => labelOffset;

        [SerializeField] private GameObject labelPrefab = default;
        public GameObject LabelPrefab => labelPrefab;

        [SerializeField] private float labelDistance = default;
        public float LabelDistance => labelDistance;

        #endregion

    }
}
