using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.I18N.Bug.Data
{
    public class Number : IObservable<double>
    {

        private int updateInterval = 1200; // milliseconds between numbers are sent

        List<IObserver<double>> observers;

        public Number()
        {
            observers = new List<IObserver<double>>();
        }

        public IDisposable Subscribe(IObserver<double> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);

        }

        public class Unsubscriber : IDisposable
        {
            private List<IObserver<double>> _observers;
            private IObserver<double> _observer;

            public Unsubscriber(List<IObserver<double>> observers, IObserver<double> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null))
                    _observers.Remove(_observer);
            }
        }

        private Timer newData1Timer;

        private double number = 0;

        public void StartStream()
        {
            var timer1Interval = TimeSpan.FromMilliseconds(updateInterval);
            newData1Timer = new Timer(NewData1TimerCallback, null, timer1Interval, timer1Interval);
        }

        public void StopStream()
        {
            newData1Timer?.Dispose();
            newData1Timer = null;
        }

        private void NewData1TimerCallback(object state)
        {
            var random = new Random();
            number += (-0.5 + random.NextDouble()) * 0.05;

            foreach (var observer in observers)
                observer.OnNext(number);
        }

    }
}
