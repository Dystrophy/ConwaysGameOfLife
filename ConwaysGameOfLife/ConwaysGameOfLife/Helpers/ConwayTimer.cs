using System.Timers;
using ConwaysGameOfLife.Models;

namespace ConwaysGameOfLife.Helpers
{
    public class ConwayTimer
    {
        public GridPresentation Renderer;
        public Grid GameGrid;

        public ConwayTimer(int xSize, int ySize)
        {
            this.GameGrid = new Grid(xSize, ySize);
            this.Renderer = new GridPresentation();
        }


        public Timer GetTimer(int interval)
        {
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = interval;
            timer.Enabled = true;
            GameGrid.GridArray = null;
            return timer;
        }

        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if(this.GameGrid.GridArray == null)
            {
                //GenerateGlider GenerateBlinker GenerateGosperGliderGun
                this.GameGrid.GridArray = GameGrid.CreateInitialContainer(GameGrid.GenerateGlider());
            }

            Renderer.RenderArray(GameGrid.GridArray);
            SetNextGeneration(GameGrid.GridArray);
        }

        public void SetNextGeneration(bool[,] currentGeneration)
        {
            this.GameGrid.GridArray = GameGrid.GenerateNextGeneration(currentGeneration);
        }
    }
}
