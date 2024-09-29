using Mahalo.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mahalo.Back.Data;

public class SeedDb
{
    private readonly DataContext _context;
    private readonly DateTime _creationDate = DateTime.Now;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCitiesAsync();
        await CheckCountriesAsync();
        await CheckDisordersAsync();
        await CheckDocumentTypesAsync();
        await CheckPsychologistAsync();

        await CheckNotificationsHistoryAsync();
        await CheckNotificationsSchedulingAsync();
        await CheckNotificationsSchedulingResourcesAsync();
        await CheckResourcesAsync();
        await CheckResourcesDisorderAsync();
        await CheckStatesAsync();
        await CheckTerapiesAsync();
        await CheckUsersAsync();
    }

    private async Task CheckCitiesAsync()
    {
        if (!_context.Cities.Any())
        {
            var citiesSQLScript = File.ReadAllText("Data\\Cities.sql");
            await _context.Database.ExecuteSqlRawAsync(citiesSQLScript);
        }
    }

    private async Task CheckCountriesAsync()
    {
        if (!_context.Countries.Any())
        {
            var countriesSQLScript = File.ReadAllText("Data\\Countries.sql");
            await _context.Database.ExecuteSqlRawAsync(countriesSQLScript);
        }
    }

    private async Task CheckDisordersAsync()
    {
        if (!_context.Disorders.Any())
        {
            var DisordersSQLScript = File.ReadAllText("Data\\Disorders.sql");
            await _context.Database.ExecuteSqlRawAsync(DisordersSQLScript);
        }
    }

    private async Task CheckDocumentTypesAsync()
    {
        if (!_context.DocumentTypes.Any())
        {
            var documentTypesSQLScript = File.ReadAllText("Data\\DocumentTypes.sql");
            await _context.Database.ExecuteSqlRawAsync(documentTypesSQLScript);
        }
    }

    private async Task CheckPsychologistAsync()
    {
        if (!_context.Psychologists.Any())
        {
            var PsychologistSQLScript = File.ReadAllText("Data\\Psychologists.sql");
            await _context.Database.ExecuteSqlRawAsync(PsychologistSQLScript);
        }
    }

    private async Task CheckStatesAsync()
    {
        if (!_context.States.Any())
        {
            var statesSQLScript = File.ReadAllText("Data\\States.sql");
            await _context.Database.ExecuteSqlRawAsync(statesSQLScript);
        }
    }

    private async Task CheckNotificationsHistoryAsync()
    {
        if (!_context.NotificationsHistory.Any())
        {
            _context.NotificationsHistory.Add(new NotificationHistory { CreationDate = _creationDate!, IsActive = true, Resource = new Resource { Name = "Anxiety resource", Location = "C://Downloads", CreationDate = _creationDate, ModifiedDate = _creationDate, Status = "Published", IsActive = true } });
            _context.NotificationsHistory.Add(new NotificationHistory { CreationDate = _creationDate!, IsActive = true, Resource = new Resource { Name = "Depression resource", Location = "C://Documents", CreationDate = _creationDate, ModifiedDate = _creationDate, Status = "Under review", IsActive = true } });
        }

        await _context.SaveChangesAsync();
    }

    private async Task CheckNotificationsSchedulingAsync()
    {
        if (!_context.NotificationsScheduling.Any())
        {
            _context.NotificationsScheduling.Add(new NotificationScheduling { Name = "Notificacion scheduling 1", SchedulingDays = _creationDate!, IsActive = true, });
            _context.NotificationsScheduling.Add(new NotificationScheduling { Name = "Notificacion scheduling 2", SchedulingDays = _creationDate!, IsActive = true, });
        }

        await _context.SaveChangesAsync();
    }

    private async Task CheckNotificationsSchedulingResourcesAsync()
    {
        if (!_context.NotificationsSchedulingResources.Any())
        {
            _context.NotificationsSchedulingResources.Add(new NotificationSchedulingResource { SchedulingDays = _creationDate!, IsActive = true, Resource = new Resource { Name = "Anxiety resource", Location = "C://Downloads", CreationDate = _creationDate, ModifiedDate = _creationDate, Status = "Published", IsActive = true } });
            _context.NotificationsSchedulingResources.Add(new NotificationSchedulingResource { SchedulingDays = _creationDate!, IsActive = true, Resource = new Resource { Name = "Anxiety resource", Location = "C://Downloads", CreationDate = _creationDate, ModifiedDate = _creationDate, Status = "Published", IsActive = true } });
        }

        await _context.SaveChangesAsync();
    }

    private async Task CheckResourcesAsync()
    {
        if (!_context.Resources.Any())
        {
            _context.Resources.Add(new Resource { Name = "Schizophrenia resource", Location = "C://Downloads", CreationDate = _creationDate, ModifiedDate = _creationDate, Status = "Published", IsActive = true });
            _context.Resources.Add(new Resource { Name = "Social anxiety resource", Location = "C://Downloads", CreationDate = _creationDate, ModifiedDate = _creationDate, Status = "Published", IsActive = true });
        }

        await _context.SaveChangesAsync();
    }

    private async Task CheckResourcesDisorderAsync()
    {
        if (!_context.ResourcesDisorder.Any())
        {
            _context.ResourcesDisorder.Add(new ResourceDisorder { Name = "Schizophrenia resource 1", CreationDate = _creationDate, IsActive = true });
            _context.ResourcesDisorder.Add(new ResourceDisorder { Name = "Social anxiety resource 2", CreationDate = _creationDate, IsActive = true });
        }

        await _context.SaveChangesAsync();
    }

    private async Task CheckTerapiesAsync()
    {
        if (!_context.Terapies.Any())
        {
            _context.Terapies.Add(new Terapy { HourTerapy = _creationDate, IsActive = true });
            _context.Terapies.Add(new Terapy { HourTerapy = _creationDate, IsActive = true });
        }

        await _context.SaveChangesAsync();
    }
    private async Task CheckUsersAsync()
    {
        if (!_context.Users.Any())
        {
            _context.Users.Add(new User { Name= "Homer Simpson", Email= "homer@yopmail.com", Password="123456", CreationDate = _creationDate, IsActive = true });
            _context.Users.Add(new User { Name= "Lisa Simpson", Email= "lisa@yopmail.com", Password="123456", CreationDate = _creationDate, IsActive = true });
            _context.Users.Add(new User { Name= "Maggie Simpson", Email= "maggie@yopmail.com", Password="123456", CreationDate = _creationDate, IsActive = true });
        }

        await _context.SaveChangesAsync();
    }
}