using UnityEngine;
using Zenject;
using TMPro;

namespace GameOfTransforms.CartesianPlane
{
    internal class CartesianPlaneGraphics : MonoBehaviour, ICartesianPlaneGraphics
    {
        #region Implements ICartesianPlaneGraphics

        [Inject] public ICartesianPlaneData Data { get; }
        [Inject] public ICartesianPlaneGraphicsAttributes Attributes { get; }

        private void Awake ()
        {
            transform.position = Data.Origin;
        }

        public void DrawCartesianPlane ()
        {
            DrawCartesianPlane("Axis X", Vector3.right, Vector3.up);
            DrawCartesianPlane("Axis Y", Vector3.up, Vector3.right);
        }

        #endregion
        
        #region Cartesian Plane Drawing
        
        private void DrawCartesianPlane (string axisName, Vector3 offsetDirection, Vector3 ortogonalDirection)
        {
            Transform axis = new GameObject(axisName).transform;
            axis.SetParent(transform);

            Transform lines = new GameObject("Lines").transform;
            lines.SetParent(axis);

            Transform labels = new GameObject("Labels").transform;
            labels.SetParent(axis);
            
            axis.position = lines.position = labels.position = Data.Origin;

            DrawCartesianLines(lines, offsetDirection, ortogonalDirection);
            DrawCartesianAxis(axis, axisName, offsetDirection);
            DrawCartesianLabels(labels, offsetDirection, ortogonalDirection);
        }
                          
        private void DrawCartesianAxis (Transform axis, string name, Vector3 offsetDirection)
        {
            LineRenderer axisLineRenderer = axis.gameObject.AddComponent<LineRenderer>();
            Vector3 axisStartingPoint = Data.Origin - offsetDirection * Data.Size;
            Vector3 axisEndingPoint = Data.Origin + offsetDirection * Data.Size;
            Vector3[] axisPoints = new Vector3[] {
                    axisStartingPoint,
                    axisEndingPoint
                };
            axisLineRenderer.material = Attributes.CartesianAxisMaterial;
            axisLineRenderer.startWidth = axisLineRenderer.endWidth = Attributes.CartesianAxisWidth;
            axisLineRenderer.SetPositions(axisPoints);
        }

        private void DrawCartesianLines (Transform lines, Vector3 offsetDirection, Vector3 ortogonalDirection)
        {
            int firstIndex = -((Data.Size - 1) / Attributes.LinesOffset) * Attributes.LinesOffset;
            for (int i = firstIndex; i < Data.Size; i += Attributes.LinesOffset)
            {
                if (i != 0)
                {
                    Transform lineTransform = new GameObject("Line " + i).transform;
                    lineTransform.SetParent(lines);
                    Vector3 linePosition = lineTransform.position = Data.Origin + offsetDirection * i;
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

        private void DrawCartesianLabels (Transform labels, Vector3 offsetDirection, Vector3 ortogonalDirection)
        {
            int firstIndex = -(Data.Size / Attributes.LabelsOffset) * Attributes.LabelsOffset;
            for (int i = firstIndex; i <= Data.Size; i += Attributes.LabelsOffset)
            {
                if (i != 0)
                {
                    GameObject label = Instantiate(Attributes.LabelPrefab, labels);
                    label.name = "Label " + i;
                    label.transform.position = Data.Origin + i * offsetDirection + ortogonalDirection * Attributes.LabelDistance;
                    label.GetComponent<TextMeshPro>().text = i.ToString();
                }
            }
        }

        #endregion  
    }
}
