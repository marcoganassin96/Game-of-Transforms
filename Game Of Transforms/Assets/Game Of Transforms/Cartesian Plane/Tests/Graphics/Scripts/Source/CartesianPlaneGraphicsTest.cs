using TMPro;
using UnityEngine;
using Zenject;

namespace GameOfTransforms.GraphicsTests
{
    internal class CartesianPlaneGraphicsTest : MonoBehaviour
    {
        [Inject] private ICartesianPlaneLogic Logic { get; } = default;
        [Inject] private ICartesianPlaneGraphicsTestsData Data { get; } = default;
        
        void Start ()
        {
            foreach (var coordinate in Data.Coordinates)
            {
                GameObject marker = Instantiate(Data.CoordinateMarkerPrefab, transform);
                marker.transform.position = Logic[coordinate.x, coordinate.y];
                marker.GetComponent<TextMeshPro>().text = coordinate.ToString();
            }
        }
    }
}
