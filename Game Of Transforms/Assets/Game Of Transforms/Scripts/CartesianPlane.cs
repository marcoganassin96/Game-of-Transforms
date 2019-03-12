using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameOfTransforms
{
    [Serializable]
    public class CartesianPlane : MonoBehaviour
    {
        #region Inspector
        [SerializeField] private int size = default;
        [SerializeField] private Material cartesianAxisMaterial = default;
        [SerializeField] private float cartesianAxisWidth = default;
        [SerializeField] private Material cartesianLinesMaterial = default;
        [SerializeField] private float cartesianLinesWidth = default;
        [SerializeField] private int linesOffset = default;
        [SerializeField] private int labelOffset = default;
        [SerializeField] private GameObject labelPrefab = default;
        [SerializeField] private float labelDistance = default;

        #endregion

        private CartesianPlaneController cartesianPlane = default;
        private CartesianAxis[] cartesianAxis = default;
        private CartesianLines[] cartesianLines = default;

        private void Awake()
        {
            cartesianPlane = new CartesianPlaneController(size);
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
            Vector3 cartesianAxisOrigin = cartesianPlaneTransform.position;

            foreach (CartesianAxis axis in cartesianAxis )
            {
                Transform axisTransform = new GameObject(axis.name).transform;
                axisTransform.SetParent(cartesianPlaneTransform);
                axisTransform.position = transform.position;
                LineRenderer axisLineRenderer = axisTransform.gameObject.AddComponent<LineRenderer>();
                Vector3 axisStartingPoint = cartesianAxisOrigin - axis.offsetDirection * size;
                Vector3 axisEndingPoint = cartesianAxisOrigin + axis.offsetDirection * size;
                Vector3[] axisPoints = new Vector3[] {
                    axisStartingPoint,
                    axisEndingPoint
                };
                axisLineRenderer.material = cartesianAxisMaterial;
                axisLineRenderer.startWidth = axisLineRenderer.endWidth = cartesianAxisWidth;
                axisLineRenderer.SetPositions(axisPoints);
            }
        }

        private void DrawCartesianLines(Transform cartesianPlaneTransform, CartesianLines[] cartesianLines)
        {
            int index = -( ( size - 1 ) / linesOffset ) * linesOffset;
            foreach (var cartesianLine in cartesianLines )
            {
                for ( int i = index; i < size; i += linesOffset )
                {
                    if ( i != 0 )
                    {
                        Transform lineTransform = new GameObject("Line " + i).transform;
                        lineTransform.SetParent(cartesianPlaneTransform);
                        Vector3 linePosition = lineTransform.position = transform.position + cartesianLine.offsetDirection * i;
                        LineRenderer lineLineRenderer = lineTransform.gameObject.AddComponent<LineRenderer>();
                        Vector3 axisStartingPoint = linePosition - cartesianLine.ortogonalDirection * size;
                        Vector3 axisEndingPoint = linePosition + cartesianLine.ortogonalDirection * size;
                        Vector3[] axisPoints = new Vector3[] {
                            axisStartingPoint,
                            axisEndingPoint
                        };
                        lineLineRenderer.material = cartesianLinesMaterial;
                        lineLineRenderer.startWidth = lineLineRenderer.endWidth = cartesianLinesWidth;
                        lineLineRenderer.SetPositions(axisPoints);
                    }
                }
            }
        }

        private void DrawCartesianLabels(Transform cartesianPlaneTransform, CartesianLines[] cartesianLines)
        {
            int index = -( size / labelOffset ) * labelOffset;
            foreach ( var cartesianLine in cartesianLines )
            {
                for ( int i = index; i <= size; i += labelOffset )
                {
                    if ( i != 0 )
                    {
                        GameObject label = Instantiate(labelPrefab, cartesianPlaneTransform);
                        label.name = "Label " + i;
                        label.transform.position = cartesianPlaneTransform.position + i * cartesianLine.offsetDirection + cartesianLine.ortogonalDirection * labelDistance;
                        label.GetComponent<Text>().text = i + "";
                    }
                }
            }
        }

        #endregion

    }

    public class CartesianPlaneController
    {
        private int size = default;

        public CartesianPlaneController(int size)
        {
            if ( size <= 0 )
            {
                throw new ArgumentOutOfRangeException("Size must be greater than 0");
            }
            this.size = size;
        }

    }
}
