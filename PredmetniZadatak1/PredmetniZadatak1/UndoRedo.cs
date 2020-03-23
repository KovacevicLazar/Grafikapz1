using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PredmetniZadatak1
{
    public enum ActionType
    {
        CreateShape = 0,
        DeleteShape = 1,
        ClearCanvas = 2,
        NoActon=3
    }

    class UndoRedo : IUndoRedo
    {
        private FrameworkElement UndoShape = new FrameworkElement();
        private List<FrameworkElement> UndoClearShapes = new List<FrameworkElement>();
        private FrameworkElement RedoShape = new FrameworkElement();
        private ActionType actionType;

        public void InsertAllShapeforUndoRedo(List<FrameworkElement> shapesForUndoRedo)
        {
            foreach(var shape in shapesForUndoRedo)
            {
                UndoClearShapes.Add(shape);
            }
            actionType = ActionType.ClearCanvas;
        }

        public void InsertShapeforUndoRedo(FrameworkElement dataobject)
        { 
            UndoShape = dataobject;
            actionType = ActionType.CreateShape;
        }

        public void Redo(MainWindow mainWindow)
        {
            
            if (actionType == ActionType.DeleteShape && RedoShape != null)
            {
                 mainWindow.PaintCanvas.Children.Add(RedoShape);
                 UndoShape = RedoShape;
                 RedoShape = null;
                 actionType = ActionType.CreateShape;
            }

        }

        public void Undo(MainWindow mainWindow)
        {
            if (actionType == ActionType.ClearCanvas)
            {
                foreach(var shape in UndoClearShapes)
                {
                    mainWindow.PaintCanvas.Children.Add(shape);
                    mainWindow.ListAllShapes.Add(shape);
                }
                UndoClearShapes.Clear();
                actionType = ActionType.NoActon;
            }
            else if (actionType == ActionType.CreateShape)
            {
                if (UndoShape != null)
                {
                    mainWindow.PaintCanvas.Children.Remove(UndoShape);
                    actionType = ActionType.DeleteShape;
                    RedoShape = UndoShape;
                    UndoShape = null;
                }
            }
        }
    }
}

