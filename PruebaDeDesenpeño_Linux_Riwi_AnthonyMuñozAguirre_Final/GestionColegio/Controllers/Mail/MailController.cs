using System.Text;
using System.Text.Json;
using GestionColegio.Models;

namespace GestionColegio.Controllers
{
    public class MailController
    {
        public async void EnviarCorreo(string email, string student, string course, string descripcion, DateOnly fecha)
        {
            try
            {
                string url = "https://api.mailersend.com/v1/email";

                string jwtToken = "mlsn.68eff3c80a2a5f2ac5ba9f008584baef5cd20549edd298bf1d568316f3ea03d7";

                var EmailMessage = new Email
                {
                    from = new From { email = "solicitud@prueba-7dnvo4dzr0nl5r86.mlsender.net" },
                    to = [
                        new To { email = email }
                    ],
                    subject = "Matricula",
                    text = $"Hola, {student} quedaste en el curso  {course} con la descripcion  {descripcion} en la fecha {fecha}",
                };

                string jsonBody = JsonSerializer.Serialize(EmailMessage);

                using(HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");

                    StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Respuesta del servidor:");
                        Console.WriteLine(responseBody);
                        Console.WriteLine($"Se mandó correctamente el correo a {email} con el asunto: {EmailMessage.text}");
                    } else
                    {
                        Console.WriteLine($"La solicitud falló: {response.StatusCode}");
                        Console.WriteLine(response);
                    }
                }
            } catch
            {
                
            }
        }
    }
}