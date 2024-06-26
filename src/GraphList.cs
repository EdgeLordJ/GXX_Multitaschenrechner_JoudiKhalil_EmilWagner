﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Multitaschenrechner
{
    public class GraphList
    {
        private List<Graph> _grapheneList = new List<Graph>();

        private Brush[] _brushesArray = new Brush[] { Brushes.Blue, Brushes.Green, Brushes.Red, Brushes.YellowGreen, Brushes.Purple, Brushes.Pink, Brushes.Brown, Brushes.Orange, Brushes.DarkBlue, Brushes.Cyan };

        private List<Brush> _usedBrushes = new List<Brush>();

        private int _rounds;

        public GraphList() { }

        public List<Graph> GetList()
        {
            return this._grapheneList;
        }

        public void Add(Graph graph)
        {
            if (this._grapheneList.Count < 10)
            {
                if (graph.Color == null)
                {
                    Brush newColor = this._brushesArray[this._rounds];
                    graph.Color = newColor;
                    this._usedBrushes.Add(graph.Color);
                    this._rounds++;
                }
                this._grapheneList.Add(graph);
                this._usedBrushes.Add(graph.Color);
            }
            else
            {
                Logging.logger.Information("Limit an Graphen erreicht");
            }
        }

        public Graph GetGraphByLabelName(string labelName)
        {
            int index = int.Parse(labelName.Replace("lbl", "")) - 1;
            if (index >= 0 && index < this._grapheneList.Count)
            {
                return this._grapheneList[index];
            }
            return null;
        }

        public void DrawGraphene(Canvas canvas, CoordinateSystem coordinateSystem, int scale)
        {
            canvas.Children.Clear();  
            coordinateSystem.DrawCoordinateSystem(canvas);  

            foreach (var graph in _grapheneList)
            {
                if (graph.Function != null)
                {
                    graph.DrawGraph(canvas, scale);  
                }
                else
                {
                    Logging.logger.Information("Ein Graph = null");
                }
            }
        }

    }


}
