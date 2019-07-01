using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alphaEventViewer.Models;
using alphaEventViewer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace alphaEventViewer.Controller
{
    public class EventItemsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly EventService _eventService;
        private readonly ILogger<EventItemsController> _logger;
        private readonly SalutationsService _salutationsService;

        public EventItemsController(ILogger<EventItemsController> logger, EventService eventService,
            SalutationsService salutationsService)
        {
            _logger = logger;
            _eventService = eventService;
            _salutationsService = salutationsService;
        }

        [Route("")]
        public async Task<IActionResult> Main(int? pageNumber)
        {
            var mainViewModel = await CreateViewModelAsync();
            var events = mainViewModel.SimpleEventItem;
            var pageSize = 10;

            IQueryable<EventItemEntity> queryableEvents = new EnumerableQuery<EventItemEntity>(events);
           
            return View(await PaginatedList<EventItemEntity>.Create(queryableEvents, pageNumber ?? 1, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            return View(await CreateViewModelAsync(Id));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Get(Guid Id, ParticipantRegistrationModel participation)
        {
            var model = await CreateViewModelAsync(Id);

            // Prüfung ob participation valide ist. Das ist Magic vom MVC. Siehe Attribute in der ParticipantRegistrationModel Klasse
            if (ModelState.IsValid)
            {
                try
                {
                    var participationId = await _eventService.AddConfirmationParticipantAsync(Id, participation);
                    model.Participation = new ParticipantRegistrationModel();
                    ModelState.Clear();

                    MailingFactory mailingFactory = new MailingFactory();
                    mailingFactory.SendVerificationMail(participation, model.EventItem, participationId);

                    model.Success = true;
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, "Cannot add Participant");
                    model.Error = true;
                }
            }
            
            return View(model);
        }

        [Route("confirm/{id}")]
        public async Task<IActionResult> RegistrationSuccess(Guid Id)
        {
            var model = CreateRegistrationSuccessViewModelAsync();

            try
            {
                var participation = await _eventService.GetParticipationAsync(Id);
                

                if (participation != null)
                {
                    if (!participation.Confirmed)
                    {
                        var eventItem = await _eventService.GetEventItemAsync(participation.EventItemId);
                        await _eventService.AddParticipantAsync(participation);
                        await _eventService.UpdateParticipationAsync(Id);
                        ModelState.Clear();

                        MailingFactory mailingFactory = new MailingFactory();
                        mailingFactory.SendConfirmationMail(participation, eventItem.Title);

                        model.RegistrationSuccess = true;
                    }
                    else
                    {
                        model.RegistrationError = true;
                    }     
                }

            }
            catch (Exception e)
            {
                _logger.LogCritical(e, "Teilnehmer kann nicht hinzugefügt werden");
                model.RegistrationError = true;
            }


            return View(model);

        }

        private async Task<GetViewModel> CreateViewModelAsync(Guid eventItemId)
        {
            var eventItem = await _eventService.GetEventItemAsync(eventItemId);
            eventItem.Modules = await _eventService.GetEventItemModulesAsync(eventItemId);
            var salutations = await _salutationsService.GetAllAsync();

            return new GetViewModel
            {
                EventItem = eventItem,
                Salutations =
                    salutations,
                Participation = new ParticipantRegistrationModel()
            };
        }

        private async Task<GetMainViewModel> CreateViewModelAsync()
        {
            var eventItem = await _eventService.GetAllEventItemsAsync();

            return new GetMainViewModel
            {
                SimpleEventItem = eventItem
            };
        }

        private RegistrationSuccessViewModel CreateRegistrationSuccessViewModelAsync()
        {
            return new RegistrationSuccessViewModel();
        }

    }

    public class GetViewModel
    {
        public EventItemEntity EventItem { get; set; }
        public IEnumerable<SalutationEntity> Salutations { get; set; }
        public ParticipantRegistrationModel Participation { get; set; }
        public bool Error { get; set; }
        public bool Success { get; set; }
    }

    public class GetMainViewModel
    {
        public IEnumerable<EventItemEntity> SimpleEventItem { get; set; }

    }

    public class RegistrationSuccessViewModel
    {
        public bool RegistrationSuccess { get; set; }
        public bool RegistrationError { get; set; }
    }

   


}