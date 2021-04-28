using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AirlineApp.CustomControls
{
    public class AnalogClock : Control
    {
        static AnalogClock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnalogClock), new FrameworkPropertyMetadata(typeof(AnalogClock)));
        }

        private Line hourHand;
        private Line minuteHand;
        private Line secondHand;

        public static DependencyProperty ShowSecondsProperty = DependencyProperty.Register(
            "ShowSeconds", typeof(bool), typeof(AnalogClock), new PropertyMetadata(true));

        public bool ShowSeconds
        {
            get { return (bool)GetValue(ShowSecondsProperty); }
            set { SetValue(ShowSecondsProperty, value); }
        }
        public override void OnApplyTemplate()
        {
            hourHand = Template.FindName("PART_hourHand", this) as Line;
            minuteHand = Template.FindName("PART_minuteHand", this) as Line;
            secondHand = Template.FindName("PART_secondHand", this) as Line;

            base.OnApplyTemplate();
            UpdateHandAngles(DateTime.UtcNow);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += (s, e) => OnTimeChanged(DateTime.UtcNow);
            timer.Start();
        }

        //public static RoutedEvent TimeChanged = EventManager.RegisterRoutedEvent(
        //    "TimeChange", RoutingStrategy.Bubble, typeof(TimeChangedEventHandler), typeof(AnalogClock));
        //public event TimeChangedEventHandler TimeChange
        //{
        //    add
        //    {
        //        AddHandler(TimeChanged, value);
        //    }
        //    remove
        //    {
        //        RemoveHandler(TimeChanged, value);
        //    }
        //}
        protected virtual void OnTimeChanged(DateTime time)
        {
            UpdateHandAngles(time);
           // RaiseEvent(new TimeChangedEventArgs(TimeChanged, this) { newTime = time });
        }





        private void UpdateHandAngles(DateTime time)
        {
            hourHand.RenderTransform = new RotateTransform((time.Hour / 12.0) * 360, 0.5, 0.5);
            minuteHand.RenderTransform = new RotateTransform((time.Minute / 60.0) * 360, 0.5, 0.5);
            secondHand.RenderTransform = new RotateTransform((time.Second / 60.0) * 360, 0.5, 0.5);
        }
    }
}
