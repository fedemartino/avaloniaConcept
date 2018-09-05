using System;
using System.Collections.Generic;
using System.Text;

namespace AvaloniaTest.Interfaces
{
    interface IGrid
    {
        int RowCount { get; }
        int ColumnCount { get; }
        IButton GetButton(int x, int y);
    }
}
