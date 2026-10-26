using System;
using System.Collections.Generic;
using Exercicio12.Models;

namespace Exercicio12.Services
{
    // Regras de negócio dos eventos: guarda a lista e avisa quando um evento é criado
    public class EventService
    {
        private readonly List<Event> _eventos = new List<Event>();
        private readonly object _trava = new object();

        // Delegate Action<Event> disparado a cada novo evento
        public event Action<Event>? EventoCriado;

        public IReadOnlyList<Event> ObterTodos()
        {
            lock (_trava)
            {
                return _eventos.ToArray();
            }
        }

        public void Adicionar(Event evento)
        {
            lock (_trava)
            {
                _eventos.Add(evento);
            }

            // Notifica os inscritos (invocação segura, caso não haja nenhum)
            EventoCriado?.Invoke(evento);
        }
    }
}