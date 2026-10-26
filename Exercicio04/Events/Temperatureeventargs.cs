using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio04.Events
{
    public class TemperatureEventArgs : EventArgs
    {
        public double Temperatura { get; }
        public double Limite { get; }
        public DateTime Momento { get; }

        public TemperatureEventArgs(double temperatura, double limite)
        {
            Temperatura = temperatura;
            Limite = limite;
            Momento = DateTime.Now;
        }
    }
}
