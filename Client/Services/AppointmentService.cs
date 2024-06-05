
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorDentista.Shared;

namespace BlazorDentista.Client.Services
{
    public class AppointmentService
    {
        private readonly HttpClient _http;

        public AppointmentService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Appointment>> GetAppointments()
        {
            return await _http.GetFromJsonAsync<List<Appointment>>("api/appointments");
        }

        public async Task<Appointment> GetAppointment(int id)
        {
            return await _http.GetFromJsonAsync<Appointment>($"api/appointments/{id}");
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            await _http.PostAsJsonAsync("api/appointments", appointment);
        }

        public async Task UpdateAppointment(Appointment appointment)
        {
            await _http.PutAsJsonAsync($"api/appointments/{appointment.Id}", appointment);
        }

        public async Task DeleteAppointment(int id)
        {
            await _http.DeleteAsync($"api/appointments/{id}");
        }
    }
}
