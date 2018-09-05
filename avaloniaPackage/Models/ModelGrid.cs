using System;

namespace AvaloniaTest.Models
{
    public class ModelGrid
    {
        public int Rows { get; } = 10;
        public int Cols { get; } = 10;
        public static ModelGrid Instance = new ModelGrid();
    }
}