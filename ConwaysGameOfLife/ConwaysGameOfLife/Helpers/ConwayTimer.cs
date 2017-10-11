using System.Timers;

namespace ConwaysGameOfLife.Helpers
{
    public class ConwayTimer
    {
        public GridPresentation Renderer;
        public GridDomain GridHelper;

        public int[,] GenerationArray;

        public ConwayTimer(int xSize, int ySize)
        {
            this.GridHelper = new GridDomain(xSize, ySize);
            this.Renderer = new GridPresentation();
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
                //GenerateGlider GenerateBlinker GenerateGosperGliderGun
                GenerationArray = GridHelper.CreateInitialContainer(GridHelper.GenerateGlider());
            }

            Renderer.RenderArray(GenerationArray);
            SetNextGeneration(GenerationArray);
        }

        public void SetNextGeneration(int[,] currentGeneration)
        {
            this.GenerationArray = GridHelper.GenerateNextGeneration(currentGeneration);
        }
    }
}
