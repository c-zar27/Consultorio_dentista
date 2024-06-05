// Server/Models/Appointment.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorDentista.Server.Models
{
    public class Appointment
    {
        [Key]
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
