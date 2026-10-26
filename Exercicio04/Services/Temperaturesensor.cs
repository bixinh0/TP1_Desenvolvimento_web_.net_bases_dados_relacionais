using Exercicio04.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio04.Services
{
        public class TemperatureSensor
    {
        public const double LimiteSeguro = 100.0;
 
        public event EventHandler<TemperatureEventArgs>? TemperatureExceeded;
 
        public void RegistrarLeitura(double temperatura)
        {
            if (temperatura > LimiteSeguro)
            {
                OnTemperatureExceeded(new TemperatureEventArgs(temperatura, LimiteSeguro));
            }
        }
 
        // Dispara o evento somente se houver assinantes
        protected virtual void OnTemperatureExceeded(TemperatureEventArgs e)
        {
            TemperatureExceeded?.Invoke(this, e);
        }
    }
}