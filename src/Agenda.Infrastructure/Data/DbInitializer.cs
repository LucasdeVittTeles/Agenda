using Agenda.Domain.Entities;
using Agenda.Domain.Enums;
using Agenda.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Data;

public class DbInitializer
{
    private readonly AppDbContext _context;
    private readonly IPasswordHasher<Users> _passwordHasher;

    public DbInitializer(
        AppDbContext context,
        IPasswordHasher<Users> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task SeedAsync()
    {

        if (await _context.Business.AnyAsync())
        {
            return;
        }

        Console.WriteLine("========== CRIANDO DADOS ==========");

        var now = DateTime.UtcNow;

        // =========================
        // BUSINESSES
        // =========================

        var alpha = new Business
        {
            Name = "Barbearia Alpha",
            Document = "12.345.678/0001-90",
            Email = "contato@alpha.com",
            Phone = "(51) 3333-1111",
            Whatsapp = "(51) 99999-1111",
            Logo_Url = "",
            Zip_Code = "90000-000",
            Street = "Rua das Flores",
            Number = "100",
            District = "Centro",
            City = "Porto Alegre",
            State = "RS",
            Country = "Brasil",
            Subscription = "Premium",
            Created_At = now,
            Updated_At = now
        };

        var bella = new Business
        {
            Name = "Studio Bella",
            Document = "98.765.432/0001-10",
            Email = "contato@bella.com",
            Phone = "(51) 3333-2222",
            Whatsapp = "(51) 99999-2222",
            Logo_Url = "",
            Zip_Code = "90000-100",
            Street = "Avenida Brasil",
            Number = "200",
            District = "Centro",
            City = "Porto Alegre",
            State = "RS",
            Country = "Brasil",
            Subscription = "Basic",
            Created_At = now,
            Updated_At = now
        };

        _context.Business.AddRange(alpha, bella);

        await _context.SaveChangesAsync();

        // =========================
        // BUSINESS SETTINGS
        // =========================

        var alphaSettings = new BusinessSettings
        {
            Business_Id = alpha.Id,
            Allow_Online_Booking = true,
            Appointment_Approval_Required = false,
            Max_Daily_Appointments = 30,
            Cancelation_Limit_Hours = 2,
            Appointment_Interval_Minutes = 30,
            Working_Days = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"],
            Theme_Color = "#111827",
            Created_At = now,
            Updated_At = now
        };

        var bellaSettings = new BusinessSettings
        {
            Business_Id = bella.Id,
            Allow_Online_Booking = true,
            Appointment_Approval_Required = true,
            Max_Daily_Appointments = 20,
            Cancelation_Limit_Hours = 4,
            Appointment_Interval_Minutes = 30,
            Working_Days = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"],
            Theme_Color = "#EC4899",
            Created_At = now,
            Updated_At = now
        };

        _context.BusinessSettings.AddRange(alphaSettings, bellaSettings);

        await _context.SaveChangesAsync();


        var users = new List<Users>
    {
    // =========================
    // BARBEARIA ALPHA
    // =========================

    new Users
    {
            BusinessId = alpha.Id,
            Name = "Dono Alpha",
            Email = "owner@alpha.com",
            PasswordHash = _passwordHasher.HashPassword(null!, "123456"),
            Role = UserRoles.Owner,
            StaffType = null,
            Phone = "(51) 99999-1001",
            Created_At = now,
            Updated_At = now
        },

        new Users
        {
            BusinessId = alpha.Id,
            Name = "Staff Alpha",
            Email = "staff@alpha.com",
            PasswordHash = _passwordHasher.HashPassword(null!, "123456"),
            Role = UserRoles.Staff,
            StaffType = StaffType.Barber,
            Phone = "(51) 99999-1002",
            Created_At = now,
            Updated_At = now
        },

        new Users
        {
            BusinessId = alpha.Id,
            Name = "Cliente Alpha",
            Email = "client@alpha.com",
            PasswordHash = _passwordHasher.HashPassword(null!, "123456"),
            Role = UserRoles.Client,
            StaffType = null,
            Phone = "(51) 99999-1003",
            Created_At = now,
            Updated_At = now
        },

        // =========================
        // STUDIO BELLA
        // =========================

        new Users
        {
            BusinessId = bella.Id,
            Name = "Dona Bella",
            Email = "owner@bella.com",
            PasswordHash = _passwordHasher.HashPassword(null!, "123456"),
            Role = UserRoles.Owner,
            StaffType = null,
            Phone = "(51) 99999-2001",
            Created_At = now,
            Updated_At = now
        },

        new Users
        {
            BusinessId = bella.Id,
            Name = "Staff Bella",
            Email = "staff@bella.com",
            PasswordHash = _passwordHasher.HashPassword(null!, "123456"),
            Role = UserRoles.Staff,
            StaffType = StaffType.Other,
            Phone = "(51) 99999-2002",
            Created_At = now,
            Updated_At = now
        },

        new Users
        {
            BusinessId = bella.Id,
            Name = "Cliente Bella",
            Email = "client@bella.com",
            PasswordHash = _passwordHasher.HashPassword(null!, "123456"),
            Role = UserRoles.Client,
            StaffType = null,
            Phone = "(51) 99999-2003",
            Created_At = now,
            Updated_At = now
        }
    };

        _context.Users.AddRange(users);

        await _context.SaveChangesAsync();


        var services = new List<Services>
{
    // =========================
    // BARBEARIA ALPHA
    // =========================

    new Services
    {
        Business_Id = alpha.Id,
        Name = "Corte Masculino",
        Description = "Corte de cabelo masculino",
        Default_Duration_Minutes = 30,
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new Services
    {
        Business_Id = alpha.Id,
        Name = "Barba",
        Description = "Barba completa",
        Default_Duration_Minutes = 30,
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new Services
    {
        Business_Id = alpha.Id,
        Name = "Corte + Barba",
        Description = "Corte masculino mais barba completa",
        Default_Duration_Minutes = 60,
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    // =========================
    // STUDIO BELLA
    // =========================

    new Services
    {
        Business_Id = bella.Id,
        Name = "Corte Feminino",
        Description = "Corte de cabelo feminino",
        Default_Duration_Minutes = 60,
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new Services
    {
        Business_Id = bella.Id,
        Name = "Manicure",
        Description = "Manicure tradicional",
        Default_Duration_Minutes = 45,
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new Services
    {
        Business_Id = bella.Id,
        Name = "Design de Sobrancelha",
        Description = "Design completo de sobrancelha",
        Default_Duration_Minutes = 30,
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    }
};

        _context.Services.AddRange(services);

        await _context.SaveChangesAsync();


        var alphaStaff = users.First(x =>
            x.Email == "staff@alpha.com");

        var bellaStaff = users.First(x =>
            x.Email == "staff@bella.com");

        var serviceStaffs = new List<ServiceStaff>
{
    // =========================
    // BARBEARIA ALPHA
    // =========================

    new ServiceStaff
    {
        Service_Id = services.First(x => x.Name == "Corte Masculino").Id,
        Staff_User_Id = alphaStaff.Id,
        Price = 40.00m,
        Duration_Minutes = 30,
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new ServiceStaff
    {
        Service_Id = services.First(x => x.Name == "Barba").Id,
        Staff_User_Id = alphaStaff.Id,
        Price = 30.00m,
        Duration_Minutes = 30,
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new ServiceStaff
    {
        Service_Id = services.First(x => x.Name == "Corte + Barba").Id,
        Staff_User_Id = alphaStaff.Id,
        Price = 60.00m,
        Duration_Minutes = 60,
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    // =========================
    // STUDIO BELLA
    // =========================

    new ServiceStaff
    {
        Service_Id = services.First(x => x.Name == "Corte Feminino").Id,
        Staff_User_Id = bellaStaff.Id,
        Price = 80.00m,
        Duration_Minutes = 60,
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new ServiceStaff
    {
        Service_Id = services.First(x => x.Name == "Manicure").Id,
        Staff_User_Id = bellaStaff.Id,
        Price = 45.00m,
        Duration_Minutes = 45,
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new ServiceStaff
    {
        Service_Id = services.First(x => x.Name == "Design de Sobrancelha").Id,
        Staff_User_Id = bellaStaff.Id,
        Price = 35.00m,
        Duration_Minutes = 30,
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    }
};

        _context.ServiceStaff.AddRange(serviceStaffs);

        await _context.SaveChangesAsync();

        var availability = new List<Availability>
{
    // =========================
    // STAFF ALPHA
    // =========================

    new Availability
    {
        User_Id = alphaStaff.Id,
        Week_Day = WeekDay.Monday,
        Start_Time = new TimeSpan(9, 0, 0),
        End_Time = new TimeSpan(18, 0, 0),
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new Availability
    {
        User_Id = alphaStaff.Id,
        Week_Day = WeekDay.Tuesday,
        Start_Time = new TimeSpan(9, 0, 0),
        End_Time = new TimeSpan(18, 0, 0),
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new Availability
    {
        User_Id = alphaStaff.Id,
        Week_Day = WeekDay.Wednesday,
        Start_Time = new TimeSpan(9, 0, 0),
        End_Time = new TimeSpan(18, 0, 0),
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new Availability
    {
        User_Id = alphaStaff.Id,
        Week_Day = WeekDay.Thursday,
        Start_Time = new TimeSpan(9, 0, 0),
        End_Time = new TimeSpan(18, 0, 0),
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new Availability
    {
        User_Id = alphaStaff.Id,
        Week_Day = WeekDay.Friday,
        Start_Time = new TimeSpan(9, 0, 0),
        End_Time = new TimeSpan(18, 0, 0),
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    // =========================
    // STAFF BELLA
    // =========================

    new Availability
    {
        User_Id = bellaStaff.Id,
        Week_Day = WeekDay.Monday,
        Start_Time = new TimeSpan(10, 0, 0),
        End_Time = new TimeSpan(19, 0, 0),
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new Availability
    {
        User_Id = bellaStaff.Id,
        Week_Day = WeekDay.Tuesday,
        Start_Time = new TimeSpan(10, 0, 0),
        End_Time = new TimeSpan(19, 0, 0),
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new Availability
    {
        User_Id = bellaStaff.Id,
        Week_Day = WeekDay.Wednesday,
        Start_Time = new TimeSpan(10, 0, 0),
        End_Time = new TimeSpan(19, 0, 0),
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new Availability
    {
        User_Id = bellaStaff.Id,
        Week_Day = WeekDay.Thursday,
        Start_Time = new TimeSpan(10, 0, 0),
        End_Time = new TimeSpan(19, 0, 0),
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new Availability
    {
        User_Id = bellaStaff.Id,
        Week_Day = WeekDay.Friday,
        Start_Time = new TimeSpan(10, 0, 0),
        End_Time = new TimeSpan(19, 0, 0),
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    },

    new Availability
    {
        User_Id = bellaStaff.Id,
        Week_Day = WeekDay.Saturday,
        Start_Time = new TimeSpan(9, 0, 0),
        End_Time = new TimeSpan(13, 0, 0),
        Is_Active = true,
        Created_At = now,
        Updated_At = now
    }
};

        _context.Availabilities.AddRange(availability);

        await _context.SaveChangesAsync();


        var blockedTimes = new List<BlockedTimes>
{
    // =========================
    // STAFF ALPHA
    // =========================

    new BlockedTimes
    {
        User_Id = alphaStaff.Id,
        Start_Datetime = now.Date.AddDays(1).AddHours(12),
        End_Datetime = now.Date.AddDays(1).AddHours(13),
        Reason = "Horário de almoço",
        Created_At = now,
        Updated_At = now
    },

    new BlockedTimes
    {
        User_Id = alphaStaff.Id,
        Start_Datetime = now.Date.AddDays(4).AddHours(15),
        End_Datetime = now.Date.AddDays(4).AddHours(17),
        Reason = "Compromisso pessoal",
        Created_At = now,
        Updated_At = now
    },

    // =========================
    // STAFF BELLA
    // =========================

    new BlockedTimes
    {
        User_Id = bellaStaff.Id,
        Start_Datetime = now.Date.AddDays(2).AddHours(13),
        End_Datetime = now.Date.AddDays(2).AddHours(14),
        Reason = "Horário de almoço",
        Created_At = now,
        Updated_At = now
    },

    new BlockedTimes
    {
        User_Id = bellaStaff.Id,
        Start_Datetime = now.Date.AddDays(5).AddHours(10),
        End_Datetime = now.Date.AddDays(5).AddHours(12),
        Reason = "Compromisso pessoal",
        Created_At = now,
        Updated_At = now
    }
};

        _context.BlockedTimes.AddRange(blockedTimes);

        await _context.SaveChangesAsync();


        var alphaClient = users.First(x =>
            x.Email == "client@alpha.com");

        var bellaClient = users.First(x =>
            x.Email == "client@bella.com");


        var alphaCorte = serviceStaffs.First(x =>
            x.Service_Id == services.First(s => s.Name == "Corte Masculino").Id);

        var alphaBarba = serviceStaffs.First(x =>
            x.Service_Id == services.First(s => s.Name == "Barba").Id);

        var bellaCorte = serviceStaffs.First(x =>
            x.Service_Id == services.First(s => s.Name == "Corte Feminino").Id);

        var bellaManicure = serviceStaffs.First(x =>
            x.Service_Id == services.First(s => s.Name == "Manicure").Id);


        var appointments = new List<Appointments>
    {
        // =========================
        // BARBEARIA ALPHA
        // =========================

        new Appointments
        {
            Business_Id = alpha.Id,
            Client_User_Id = alphaClient.Id,
            Service_Staff_Id = alphaCorte.Id,
            Start_Datetime = now.Date.AddDays(1).AddHours(9),
            End_Datetime = now.Date.AddDays(1).AddHours(9).AddMinutes(30),
            Status = AppointmentStatus.Confirmed,
            Notes = "Cliente solicitou corte tradicional.",
            Created_At = now,
            Updated_At = now
        },

        new Appointments
        {
            Business_Id = alpha.Id,
            Client_User_Id = alphaClient.Id,
            Service_Staff_Id = alphaBarba.Id,
            Start_Datetime = now.Date.AddDays(2).AddHours(14),
            End_Datetime = now.Date.AddDays(2).AddHours(14).AddMinutes(30),
            Status = AppointmentStatus.Pending,
            Notes = "Barba completa.",
            Created_At = now,
            Updated_At = now
        },

        // =========================
        // STUDIO BELLA
        // =========================

        new Appointments
        {
            Business_Id = bella.Id,
            Client_User_Id = bellaClient.Id,
            Service_Staff_Id = bellaCorte.Id,
            Start_Datetime = now.Date.AddDays(1).AddHours(10),
            End_Datetime = now.Date.AddDays(1).AddHours(11),
            Status = AppointmentStatus.Confirmed,
            Notes = "Corte feminino.",
            Created_At = now,
            Updated_At = now
        },

        new Appointments
        {
            Business_Id = bella.Id,
            Client_User_Id = bellaClient.Id,
            Service_Staff_Id = bellaManicure.Id,
            Start_Datetime = now.Date.AddDays(3).AddHours(15),
            End_Datetime = now.Date.AddDays(3).AddHours(15).AddMinutes(45),
            Status = AppointmentStatus.Pending,
            Notes = "Manicure tradicional.",
            Created_At = now,
            Updated_At = now
        }
    };

        _context.Appointments.AddRange(appointments);

        await _context.SaveChangesAsync();


    }
}