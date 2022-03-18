using System;
using System.IO;
using System.Threading.Tasks;
using FluentEmail.Core;
using FluentEmail.Liquid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

namespace mapun_api.Services
{
    public class EmailService
    {
        private IFluentEmail _email;

        public EmailService(IFluentEmail email)
        {
            _email = email;
        }

        public async void sendStatusUpdate(string status, string header, string name, string target)
        {
            try
            {

                // template which utilizes layout
                var template = @"{% layout 'status_update.liquid' %}";

                var mail = await _email.To(target)
                    .Subject(header)
                    .UsingTemplate(template, new { status = status, name = name })
                    .SendAsync();

                Console.WriteLine("sendresponse");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}