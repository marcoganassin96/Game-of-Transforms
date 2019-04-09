using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameOfTransforms
{
    public interface ICartesianPlaneGraphics
    {
        ICartesianPlaneData Data { get; }
        ICartesianPlaneGraphicsAttributes Attributes { get; }
        void DrawCartesianPlane ();
    }

    internal class CartesianPlaneGraphics : MonoBehaviour, ICartesianPlaneGraphics
    {
        #region Implements ICartesianPlaneGraphics

        [Inject] private ICartesianPlaneData data = default;
        public ICartesianPlaneData Data => data;

        [Inject] private ICartesianPlaneGraphicsAttributes attributes = default;
        public ICartesianPlaneGraphicsAttributes Attributes => attributes;

        public void DrawCartesianPlane ()
        {
            DrawCartesianPlane("Axis X", Vector3.right, Vector3.up);
            DrawCartesianPlane("Axis Y", Vector3.up, Vector3.right);
        }

        #endregion

        private Vector3 origin = default;

        #region Cartesian Plane Drawing
        
        private void DrawCartesianPlane (string axisName, Vector3 offsetDirection, Vector3 ortogonalDirection)
        {
            origin = transform.position;
            DrawCartesianLines(transform, offsetDirection, ortogonalDirection);
            DrawCartesianAxis(transform, axisName, offsetDirection);
            DrawCartesianLabels(transform, offsetDirection, ortogonalDirection);
        }
                          
        private void DrawCartesianAxis (Transform transform, string name, Vector3 offsetDirection)
        {
            Transform axisTransform = new GameObject(name).transform;
            axisTransform.SetParent(transform);
            axisTransform.position = transform.position;

            LineRenderer axisLineRenderer = axisTransform.gameObject.AddComponent<LineRenderer>();
            Vector3 axisStartingPoint = origin - offsetDirection * Data.Size;
            Vector3 axisEndingPoint = origin + offsetDirection * Data.Size;
            Vector3[] axisPoints = new Vector3[] {
                    axisStartingPoint,
                    axisEndingPoint
                };
            axisLineRenderer.material = Attributes.CartesianAxisMaterial;
            axisLineRenderer.startWidth = axisLineRenderer.endWidth = Attributes.CartesianAxisWidth;
            axisLineRenderer.SetPositions(axisPoints);
        }

        private void DrawCartesianLines (Transform parent, Vector3 offsetDirection, Vector3 ortogonalDirection)
        {
            int firstIndex = -((Data.Size - 1) / Attributes.LinesOffset) * Attributes.LinesOffset;
            for (int i = firstIndex; i < Data.Size; i += Attributes.LinesOffset)
            {
                if (i != 0)
                {
                    Transform lineTransform = new GameObject("Line " + i).transform;
                    lineTransform.SetParent(parent);
                    Vector3 linePosition = lineTransform.position = origin + offsetDirection * i;
                    LineRenderer lineLineRenderer = lineTransform.gameObject.AddComponent<LineRenderer>();
                    Vector3 axisStartingPoint = linePosition - ortogonalDirection * Data.Size;
                    Vector3 axisEndingPoint = linePosition + ortogonalDirection * Data.Size;
                    Vector3[] axisPoints = new Vector3[] {
                            axisStartingPoint,
                            axisEndingPoint
                        };
                    lineLineRenderer.material = Attributes.CartesianLinesMaterial;
                    lineLineRenderer.startWidth = lineLineRenderer.endWidth = Attributes.CartesianLinesWidth;
                    lineLineRenderer.SetPositions(axisPoints);
                }
            }
        }

        private void DrawCartesianLabels (Transform parent, Vector3 offsetDirection, Vector3 ortogonalDirection)
        {
            int firstIndex = -(Data.Size / Attributes.LabelsOffset) * Attributes.LabelsOffset;
            for (int i = firstIndex; i <= Data.Size; i += Attributes.LabelsOffset)
            {
                if (i != 0)
                {
                    GameObject label = Instantiate(Attributes.LabelPrefab, parent);
                    label.name = "Label " + i;
                    label.transform.position = origin + i * offsetDirection + ortogonalDirection * Attributes.LabelDistance;
                    label.GetComponent<Text>().text = i + "";
                }
            }
        }

        #endregion  
    }
}
