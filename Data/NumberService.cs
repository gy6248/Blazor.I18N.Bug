using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;

namespace Blazor.I18N.Bug.Data
{
    public class NumberService : IObservable<double>
    {

        private double number = 0;



        // Cold observable - lager verdier pr observer - lager ingenting uten observers
        public IObservable<double> RandomNumbers(int updateInterval)
        {
            var random = new Random();
            return Observable.Generate(
                number,
                i => true,
                i => i,
                i => number += (-0.5 + random.NextDouble()) * 0.05,
                i => TimeSpan.FromMilliseconds(updateInterval));
        }

              
        

        public IDisposable Subscribe(IObserver<double> observer)
        {
            return RandomNumbers(60).Subscribe(observer);
            //throw new NotImplementedException();
        }
    }
}
