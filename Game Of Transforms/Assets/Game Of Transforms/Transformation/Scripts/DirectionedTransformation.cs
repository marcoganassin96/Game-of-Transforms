namespace GameOfTransforms.Transformation
{
    public struct DirectionedTransformation
    {
        public Transformation Transformation { get; }
        public Direction Direction { get; }
       
        private DirectionedTransformation (Transformation transformation, Direction direction)
        {
            Transformation = transformation;
            Direction = direction;
        }
        
        #region Translations

        public static DirectionedTransformation HorizontalTranslation = new DirectionedTransformation(Transformation.Translation, Direction.X);
        public static DirectionedTransformation VerticalTranslation = new DirectionedTransformation(Transformation.Translation, Direction.Y);

        #endregion

        #region Rotations

        public static DirectionedTransformation OriginRotation = new DirectionedTransformation(Transformation.Rotation, Direction.O);

        #endregion

        #region Scalings

        public static DirectionedTransformation HorizontalScaling = new DirectionedTransformation(Transformation.Scaling, Direction.X);
        public static DirectionedTransformation VerticalScaling = new DirectionedTransformation(Transformation.Scaling, Direction.Y);
        public static DirectionedTransformation OriginScaling = new DirectionedTransformation(Transformation.Scaling, Direction.O);

        #endregion

        #region Reflections

        public static DirectionedTransformation HorizontalReflection = new DirectionedTransformation(Transformation.Reflection, Direction.X);
        public static DirectionedTransformation VerticalReflection = new DirectionedTransformation(Transformation.Reflection, Direction.Y);
        public static DirectionedTransformation OriginReflection = new DirectionedTransformation(Transformation.Reflection, Direction.O);

        #endregion
    }
}
