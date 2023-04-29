using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace WaveSimulator{

        public class WaveEngine {
        
        // variable setup
        Bitmap bmp;
        BitmapData bd;

        //VD = vertex data
        float[] vd; 
        float[] vdv;
        float[] vda; 
        float[] vds; 
        bool[] vd_static;

        int delay = 1;
        int osc1point = 0;
        int osc2point = 0; 
        int size = 200;
        int absorb_offset = 10;

        float mass = 0.1f;
        float limit = 500f;
        float action_resolution = 20f;
        float sustain = 1000f;
        float pahse1=0f;
        float phase2=0f;
        float freq1=0.2f;
        float freq2=0.2f;
        float power = 1.0f;
        float min_sustain = 2f; 

        BufferedGraphics bufgraph;

        BufferedGraphicsContext bufgcont;

        Thread ForceCalcT;

        Mutex mutex;

        bool work_now = false;
        bool highcont = false;
        bool disposing = false;
        bool osc1active = false;
        bool osc2active = false;
        bool edge_absorbtion = true;

        Color color1 = Color.Black;
        Color color2 = Color.Cyan;
        Color colorstatic = Color.Yellow;

        Control control;

        public float Mass
        {
            get { return mass; }
            set
            {
                if (value > 0f)
                {
                    mutex.WaitOne();
                    mass = value;
                    mutex.ReleaseMutex();
                }
            }
        }

        public float Limit
        {
            get { return limit; }
            set
            {
                if (value > 0f)
                {
                    mutex.WaitOne();
                    limit = value;
                    mutex.ReleaseMutex();
                }
            }
        }

    }

}
