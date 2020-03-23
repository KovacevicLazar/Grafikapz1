using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PredmetniZadatak1
{
    interface IUndoRedo
    {
        void Undo(MainWindow mainWindow);
        void Redo(MainWindow mainWindow);
        void InsertShapeforUndoRedo(FrameworkElement dataobject);

        void InsertAllShapeforUndoRedo(List<FrameworkElement> shapesForUndoRedo);
    }
}
