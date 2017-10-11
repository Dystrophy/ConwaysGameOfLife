using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConwaysGameOfLife.Helpers;
using System.Timers;

namespace ConwaysGameOfLife.Helpers
{
    public class ConwayTimer
    {
        public CellHelper CellHelper;
        public GridHelper GridHelper;
        public int[,] GenerationArray;

        public ConwayTimer()
        {
            this.CellHelper = new CellHelper();
            this.GridHelper = new GridHelper();
            this.GenerationArray = null;
        }


        public Timer GetTimer(int interval)
        {
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = interval;
            timer.Enabled = true;
            
            return timer;
        }

        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if(this.GenerationArray == null)
            {
                GenerationArray = GridHelper.CreateInitialContainer(GridHelper.GenerateGlider());
            }

            GridHelper.RenderGrid(GenerationArray);
            SetNextGeneration(GenerationArray);
        }

        public void SetNextGeneration(int[,] currentGeneration)
        {
            this.GenerationArray = null;
            this.GenerationArray = GridHelper.GenerateNextGeneration(currentGeneration);
        }
    }
}
