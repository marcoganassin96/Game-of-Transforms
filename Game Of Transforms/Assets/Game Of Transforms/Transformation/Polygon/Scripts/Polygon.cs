﻿using System.Collections.Generic;
using UnityEngine;

namespace GameOfTransforms.Transformation.Polygon
{
    public class Polygon : MonoBehaviour
    {
        public List<Vector2> points = default;

        public Polygon (List<Vector2> points)
        {
            this.points = points;
        }
    }
}
