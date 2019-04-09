using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameOfTransforms
{
    [Serializable]
    public class CartesianPlane : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private CartesianPlaneAttributes attributes = default;

        #endregion

        private CartesianPlaneController cartesianPlane = default;

        private Vector3 origin = default; 

        private void Awake()
        {
            origin = transform.position;
            cartesianPlane = new CartesianPlaneController(attributes.Size);
            DrawCartesianPlane();
        }

        #region Cartesian Plane Drawing

        private void DrawCartesianPlane()
        {
            DrawCartesianLines(transform, Vector3.right, Vector3.up);
            DrawCartesianLines(transform, Vector3.up, Vector3.right);

            DrawCartesianAxis(transform, "Axis X", Vector3.right);
            DrawCartesianAxis(transform, "Axis Y", Vector3.up);

            DrawCartesianLabels(transform, Vector3.right, Vector3.up);
            DrawCartesianLabels(transform, Vector3.up, Vector3.right);
        }

        private void DrawCartesianAxis(Transform cartesianPlaneTransform, string name, Vector3 offsetDirection)
        {
                Transform axisTransform = new GameObject(name).transform;
                axisTransform.SetParent(cartesianPlaneTransform);
                axisTransform.position = transform.position;
                LineRenderer axisLineRenderer = axisTransform.gameObject.AddComponent<LineRenderer>();
                Vector3 axisStartingPoint = origin - offsetDirection * attributes.Size;
                Vector3 axisEndingPoint = origin + offsetDirection * attributes.Size;
                Vector3[] axisPoints = new Vector3[] {
                    axisStartingPoint,
                    axisEndingPoint
                };
                axisLineRenderer.material = attributes.CartesianAxisMaterial;
                axisLineRenderer.startWidth = axisLineRenderer.endWidth = attributes.CartesianAxisWidth;
                axisLineRenderer.SetPositions(axisPoints);
        }

        private void DrawCartesianLines(Transform cartesianPlaneTransform, Vector3 offsetDirection, Vector3 ortogonalDirection)
        {
            int index = -( ( attributes.Size - 1 ) / attributes.LinesOffset ) * attributes.LinesOffset;
            for (int i = index; i < attributes.Size; i += attributes.LinesOffset)
            {
                if (i != 0)
                {
                    Transform lineTransform = new GameObject("Line " + i).transform;
                    lineTransform.SetParent(cartesianPlaneTransform);
                    Vector3 linePosition = lineTransform.position = origin + offsetDirection * i;
                    LineRenderer lineLineRenderer = lineTransform.gameObject.AddComponent<LineRenderer>();
                    Vector3 axisStartingPoint = linePosition - ortogonalDirection * attributes.Size;
                    Vector3 axisEndingPoint = linePosition + ortogonalDirection * attributes.Size;
                    Vector3[] axisPoints = new Vector3[] {
                            axisStartingPoint,
                            axisEndingPoint
                        };
                    lineLineRenderer.material = attributes.CartesianLinesMaterial;
                    lineLineRenderer.startWidth = lineLineRenderer.endWidth = attributes.CartesianLinesWidth;
                    lineLineRenderer.SetPositions(axisPoints);
                }
            }
        }

        private void DrawCartesianLabels (Transform cartesianPlaneTransform, Vector3 offsetDirection, Vector3 ortogonalDirection)
        {
            int index = -( attributes.Size / attributes.LabelOffset ) * attributes.LabelOffset;
            for (int i = index; i <= attributes.Size; i += attributes.LabelOffset)
            {
                if (i != 0)
                {
                    GameObject label = Instantiate(attributes.LabelPrefab, cartesianPlaneTransform);
                    label.name = "Label " + i;
                    label.transform.position = origin + i * offsetDirection + ortogonalDirection * attributes.LabelDistance;
                    label.GetComponent<Text>().text = i + "";
                }
            }
        }

        #endregion                
    }

    public class CartesianPlaneController
    {
        private int Size = default;

        public CartesianPlaneController(int Size)
        {
            if ( Size <= 0 )
            {
                throw new ArgumentOutOfRangeException("Size must be greater than 0");
            }
            this.Size = Size;
        }
    }
}
