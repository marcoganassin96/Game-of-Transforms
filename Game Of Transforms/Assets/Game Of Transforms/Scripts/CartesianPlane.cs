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
        private CartesianAxis[] cartesianAxis = default;
        private CartesianLines[] cartesianLines = default;

        private Vector3 origin = default; 

        private void Awake()
        {
            origin = transform.position;
            cartesianPlane = new CartesianPlaneController(attributes.Size);
            cartesianAxis = new CartesianAxis[]
            {
                new CartesianAxis("Horizontal Axis", Vector3.right),
                new CartesianAxis("Vertical Axis", Vector3.up)
            };
            cartesianLines = new CartesianLines[]
            {
                new CartesianLines(Vector3.right, Vector3.up),
                new CartesianLines(Vector3.up, Vector3.right)
            };
            DrawCartesianPlane();
        }

        #region Cartesian Plane Drawing

        private void DrawCartesianPlane()
        {
            DrawCartesianLines(transform, cartesianLines);
            DrawCartesianAxis(transform, cartesianAxis);
            DrawCartesianLabels(transform, cartesianLines);
        }

        private void DrawCartesianAxis(Transform cartesianPlaneTransform, CartesianAxis[] cartesianAxis)
        {
            foreach (CartesianAxis axis in cartesianAxis )
            {
                Transform axisTransform = new GameObject(axis.name).transform;
                axisTransform.SetParent(cartesianPlaneTransform);
                axisTransform.position = transform.position;
                LineRenderer axisLineRenderer = axisTransform.gameObject.AddComponent<LineRenderer>();
                Vector3 axisStartingPoint = origin - axis.offsetDirection * attributes.Size;
                Vector3 axisEndingPoint = origin + axis.offsetDirection * attributes.Size;
                Vector3[] axisPoints = new Vector3[] {
                    axisStartingPoint,
                    axisEndingPoint
                };
                axisLineRenderer.material = attributes.CartesianAxisMaterial;
                axisLineRenderer.startWidth = axisLineRenderer.endWidth = attributes.CartesianAxisWidth;
                axisLineRenderer.SetPositions(axisPoints);
            }
        }

        private void DrawCartesianLines(Transform cartesianPlaneTransform, CartesianLines[] cartesianLines)
        {
            int index = -( ( attributes.Size - 1 ) / attributes.LinesOffset ) * attributes.LinesOffset;
            foreach (var cartesianLine in cartesianLines )
            {
                for ( int i = index; i < attributes.Size; i += attributes.LinesOffset )
                {
                    if ( i != 0 )
                    {
                        Transform lineTransform = new GameObject("Line " + i).transform;
                        lineTransform.SetParent(cartesianPlaneTransform);
                        Vector3 linePosition = lineTransform.position = origin + cartesianLine.offsetDirection * i;
                        LineRenderer lineLineRenderer = lineTransform.gameObject.AddComponent<LineRenderer>();
                        Vector3 axisStartingPoint = linePosition - cartesianLine.ortogonalDirection * attributes.Size;
                        Vector3 axisEndingPoint = linePosition + cartesianLine.ortogonalDirection * attributes.Size;
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
        }

        private void DrawCartesianLabels(Transform cartesianPlaneTransform, CartesianLines[] cartesianLines)
        {
            int index = -( attributes.Size / attributes.LabelOffset ) * attributes.LabelOffset;
            foreach ( var cartesianLine in cartesianLines )
            {
                for ( int i = index; i <= attributes.Size; i += attributes.LabelOffset )
                {
                    if ( i != 0 )
                    {
                        GameObject label = Instantiate(attributes.LabelPrefab, cartesianPlaneTransform);
                        label.name = "Label " + i;
                        label.transform.position = origin + i * cartesianLine.offsetDirection + cartesianLine.ortogonalDirection * attributes.LabelDistance;
                        label.GetComponent<Text>().text = i + "";
                    }
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
