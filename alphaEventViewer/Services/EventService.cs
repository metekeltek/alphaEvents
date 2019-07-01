using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using alphaEventViewer.Extensions;
using alphaEventViewer.Models;
using alphaEventViewer.Repository;

namespace alphaEventViewer.Services
{
    public class EventService
    {
        private readonly EventItemRepository _eventItemRepository;
        private readonly JobContactRepository _jobContactRepository;
        private readonly JobEventRegistrationRepository _jobEventRegistrationRepository;
        private readonly JobRepository _jobRepository;
        private readonly JobContactConfirmationRepository _jobContactConfirmationRepository;

        public EventService(
            EventItemRepository eventItemRepository,
            JobContactRepository jobContactRepository, JobRepository jobRepository,
            JobEventRegistrationRepository jobEventRegistrationRepository, JobContactConfirmationRepository jobContactConfirmationRepository)
        {
            _eventItemRepository = eventItemRepository;
            _jobContactRepository = jobContactRepository;
            _jobRepository = jobRepository;
            _jobEventRegistrationRepository = jobEventRegistrationRepository;
            _jobContactConfirmationRepository = jobContactConfirmationRepository;
        }

        public async Task<IEnumerable<EventItemEntity>> GetAllEventItemsAsync()
        {
            return await _eventItemRepository.GetAllAsync();
        }

        public async Task<EventItemEntity> GetEventItemAsync(Guid eventItemId)
        {
            return await _eventItemRepository.GetAsync(eventItemId);
        }

        public async Task<IEnumerable<EventItemEntity>> GetEventItemModulesAsync(Guid eventItemId)
        {
            return await _eventItemRepository.GetModulesAsync(eventItemId);
        }

        public async Task<JobContactConfirmationEntity> GetParticipationAsync(Guid participationId)
        {
            return await _jobContactConfirmationRepository.GetAsync(participationId);
        }

        public async Task UpdateParticipationAsync(Guid participationId)
        {
            await _jobContactConfirmationRepository.UpdateAsync(participationId);
        }

        public async Task AddParticipantAsync(JobContactConfirmationEntity participant)
        {
            var eventItem = await GetEventItemAsync(participant.EventItemId);

            var jobContact = new JobContactEntity
            {
                JobContactId = Guid.NewGuid(),
                Salutation = participant.Salutation,
                Title = participant.Title,
                FirstName = participant.FirstName,
                LastName = participant.LastName,
                EMailAddress = participant.EMailAddress,
                Street = participant.Street,
                ZipCode = participant.ZipCode,
                City = participant.City,
                Country = participant.Country,
                Phone = participant.Phone,
            };
            if (jobContact.Phone.IsNullOrEmpty())
            {
                jobContact.Phone = "";
            }

            if (jobContact.Title.IsNullOrEmpty())
            {
                jobContact.Title = "";
            }

            await _jobContactRepository.CreateAsync(jobContact);

            var job = new JobEntity()
            {
                JobId = Guid.NewGuid(),
                JobType = "EventRegistration",
                Caption = "Seminaranmeldung",
                ShortDescription = eventItem.Title,
                State = "Pending",
                FullDescription = GetFullDescription(eventItem, jobContact) 
            };

            await _jobRepository.CreateAsync(job);

            var jobEventRegistration = new JobEventRegistrationEntity()
            {
                JobEventRegistrationId = Guid.NewGuid(),
                JobId = job.JobId,
                ParticipantJobContactId = jobContact.JobContactId,
                EventItemId = participant.EventItemId,
                Role = "TN",
                State = "A"
            };

            await _jobEventRegistrationRepository.CreateAsync(jobEventRegistration);
        }

        public async Task<Guid> AddConfirmationParticipantAsync(Guid eventItemId, ParticipantRegistrationModel participant)
        {
            var jobContactConfirmation = new JobContactConfirmationEntity();
            jobContactConfirmation.JobContactId = Guid.NewGuid();
            jobContactConfirmation.EventItemId = eventItemId;
            jobContactConfirmation.Salutation = participant.Salutation;
            jobContactConfirmation.Title = participant.Title;
            jobContactConfirmation.FirstName = participant.FirstName;
            jobContactConfirmation.LastName = participant.LastName;
            jobContactConfirmation.EMailAddress = participant.EMailAddress;
            jobContactConfirmation.Street = participant.Street;
            jobContactConfirmation.ZipCode = participant.ZipCode;
            jobContactConfirmation.City = participant.City;
            jobContactConfirmation.Country = participant.Country;
            jobContactConfirmation.Phone = participant.Phone;

            await _jobContactConfirmationRepository.CreateAsync(jobContactConfirmation);

            return jobContactConfirmation.JobContactId;

        }

        private string GetFullDescription(EventItemEntity eventItem, JobContactEntity jobContact)
        {
            var sb = new StringBuilder();
            sb.Append("Veranstaltung: " + eventItem.Title + " " + eventItem.Beginning + " in " + eventItem.City + " ");
            sb.Append("Teilnehmer: " + jobContact.Salutation + " " + jobContact.Title + " " + jobContact.FirstName +
                      " " + jobContact.LastName + " " +
                      jobContact.Street + " " + jobContact.ZipCode + " " + jobContact.City + " " + jobContact.Country + " ");

            if (jobContact.Phone.IsNotNullOrEmpty())
            {
                sb.Append("Telefon: " + jobContact.Phone + " ");
            }

            sb.Append("Email: " + jobContact.EMailAddress);

            return sb.ToString();
        }
    }
}