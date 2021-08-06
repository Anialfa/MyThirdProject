using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Numerics;
using System.Windows.Controls;

namespace WpfTouchFrameSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            start();
            canvas1.TouchMove += mScrollViewer_TouchMove;
            canvas2.TouchMove += mScrollViewer_TouchMove2;

            canvas1.TouchLeave += mScrollViewer_TouchUpL;
            canvas2.TouchLeave += mScrollViewer_TouchUpR;
        }
        double CanvaseSize = 250;//都是方形,所以只记录一个尺寸
        double picSize = 60;
        double midCanvSize;
        double midPicSize;

        void start()
        {
            midCanvSize = CanvaseSize / 2;
            midPicSize = picSize / 2;


            setButLeft(midCanvSize, midCanvSize);
            setButRight(midCanvSize, midCanvSize);
            tt1show(midCanvSize, midCanvSize);
            tt2show(midCanvSize, midCanvSize);
        }

        private void mScrollViewer_TouchMove(object sender, TouchEventArgs e)
        {
           setButLeft(e.GetTouchPoint(this.canvas1).Position.X, e.GetTouchPoint(this.canvas1).Position.Y);


           tt1show(e.GetTouchPoint(this.canvas1).Position.X, e.GetTouchPoint(this.canvas1).Position.Y);



        }

        private void mScrollViewer_TouchMove2(object sender, TouchEventArgs e)
        {
           setButRight(e.GetTouchPoint(this.canvas2).Position.X, e.GetTouchPoint(this.canvas2).Position.Y);

            tt2show(e.GetTouchPoint(this.canvas2).Position.X, e.GetTouchPoint(this.canvas2).Position.Y);


        }

        void tt1show(double x, double y )
        {
            tt3.Text = "左边区域,实际坐标\n" + x.ToString("f5") + "\n" + y.ToString("f5");

            Vector2 v2 = PositonEx(x, y);

           tt1.Text ="相对坐标\n"+ v2.X.ToString("f5") + "\n" + v2.Y.ToString("f5");
        }
        void tt2show(double x , double y )
        {
            tt4.Text = "左边区域,实际坐标\n" + x.ToString("f5") + "\n" + y.ToString("f5");

            Vector2 v2 = PositonEx(x, y);
            tt2.Text = "相对坐标\n"+ v2.X.ToString("f5") + "\n" + v2.Y.ToString("f5");


        }
        private void mScrollViewer_TouchUpR(object sender, TouchEventArgs e)
        {
           
            setButRight(midCanvSize, midCanvSize);
            tt2show(midCanvSize, midCanvSize);

        }
        private void mScrollViewer_TouchUpL(object sender, TouchEventArgs e)
        {
            tt1show(midCanvSize, midCanvSize);
            setButLeft(midCanvSize, midCanvSize);
        }

        /// <summary>
        /// x=canvase.left
        /// y=canvase.top
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void setButLeft(double x, double y)//110是左上角的坐标,不是正中心坐标
        {
            if (x<= midPicSize)
            {
                x = midPicSize;
            }
            else if(x>=CanvaseSize- midPicSize)
            {
                x = CanvaseSize - midPicSize;
            }
            if (y<= midPicSize)
            {
                y = midPicSize;
            }
            else if (y>= CanvaseSize - midPicSize)
            {
                y = CanvaseSize - midPicSize;
            }



            butL.SetValue(Canvas.LeftProperty, x- midPicSize);
            butL.SetValue(Canvas.TopProperty, y- midPicSize);

          
        }
        void setButRight(double x, double y)
        {
            if (x <= midPicSize)
            {
                x = midPicSize;
            }
            else if (x >= CanvaseSize - midPicSize)
            {
                x = CanvaseSize - midPicSize;
            }
            if (y <= midPicSize)
            {
                y = midPicSize;
            }
            else if (y >= CanvaseSize - midPicSize)
            {
                y = CanvaseSize - midPicSize;
            }



            butR.SetValue(Canvas.LeftProperty, x- midPicSize);
            butR.SetValue(Canvas.TopProperty, y- midPicSize);

        }

        public Vector2 PositonEx(double x, double y)
        {
            if (x > CanvaseSize- midPicSize)//250
            {
                x = CanvaseSize - midPicSize; //250
            }
            else if (x < midPicSize) //30
            {
                x = midPicSize; //30
            }
            if (y > CanvaseSize - midPicSize)
            {
                y = CanvaseSize - midPicSize;
            }
            else if (y < midPicSize)
            {
                y = midPicSize;
            }


            float outX = (float)((x - midCanvSize) / (midCanvSize- midPicSize));//(x-140)/110
            float outY = (float)((midCanvSize - y) / (midCanvSize - midPicSize));//(140 - y) / 110


            Vector2 v2 = new Vector2(outX, outY);
            return v2;
            //
        }



      


    }
}