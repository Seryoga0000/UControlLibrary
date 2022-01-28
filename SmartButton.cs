using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UControlLibrary
{
    public class SmartButton : Button
    {
        //    //Timer tmer = new Timer();
        //    private int counter = 0;
        //    private string bText;
        //    Stopwatch sw = new Stopwatch();
        //    //public SmartButton()
        //    //{
        //    //    //tmer.Tick += Tmer_Tick;
        //    //}

        //    //private void Tmer_Tick(object sender, EventArgs e)
        //    //{
        //    //    counter++;
        //    //    Text = counter.ToString();
        //    //}


        //    public async void Loading(CancellationToken token)
        //    {
        //        counter = 0;
        //        //Debug.WriteLine("before:bText = Text;" + Text);
        //        //Debug.WriteLine("before:bText = Text;" + bText);
        //        bText = Text;
        //        await Task.Factory.StartNew(() =>
        //        {
        //            sw.Restart();
        //            while (!token.IsCancellationRequested)
        //            {
        //                if (sw.ElapsedMilliseconds > 100)
        //                {
        //                    BeginInvoke(new Action(() => Text = counter.ToString()));
        //                    sw.Restart();
        //                }
        //                counter++;
        //            }
        //            sw.Stop();
        //        }, token);
        //        BeginInvoke(new Action(() =>
        //        {
        //            //Debug.WriteLine(bText);
        //            Text = bText;
        //        }));
        //    }
        //    //public void Start()
        //    //{
        //    //    counter = 0;
        //    //    bText = Text;
        //    //    tmer.Start();

        //    //}
        //    //public void Stop()
        //    //{
        //    //    tmer.Stop();
        //    //    Text = bText;
        //    //}
    }
}
