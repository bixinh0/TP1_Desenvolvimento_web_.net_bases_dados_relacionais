using System.Collections.Generic;
using Exercicio12.Models;
using Exercicio12.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercicio12.Pages
{
    public class CadastrarEventoModel : PageModel
    {
        private readonly EventService _eventService;

        // O EventService é recebido por injeção de dependência (registrado no Program.cs)
        public CadastrarEventoModel(EventService eventService)
        {
            _eventService = eventService;
        }

        [BindProperty]
        public Event Evento { get; set; } = new Event();

        public IReadOnlyList<Event> Eventos { get; private set; } = new List<Event>();

        [TempData]
        public string? Mensagem { get; set; }

        public void OnGet()
        {
            Eventos = _eventService.ObterTodos();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Eventos = _eventService.ObterTodos();
                return Page();
            }

            // Ao adicionar, o serviço dispara o Action<Event>
            _eventService.Adicionar(Evento);

            Mensagem = $"Evento \"{Evento.Titulo}\" cadastrado com sucesso.";

            // Redireciona para evitar reenvio do formulário ao atualizar a página
            return RedirectToPage();
        }
    }
}