// Shared/Appointment.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorDentista.Shared
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public string PatientName { get; set; }

        [Required]
        [EmailAddress]
        public string PatientEmail { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        public string Notes { get; set; }
    }
}
