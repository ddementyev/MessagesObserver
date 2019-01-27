using MessagesObserver.Interfaces;
using System;
using System.Web.Configuration;

namespace MessagesObserver.Services
{
    public class MessagesService : IMessagesService
    {
        public string GenerateMessage()
        {
            var random = new Random();

            var minimumWordLength = int.Parse(WebConfigurationManager.AppSettings["minimumWordLength"]);
            var maximumWordLength = int.Parse(WebConfigurationManager.AppSettings["maximumWordLength"]);

            var wordLength = random.Next(minimumWordLength, maximumWordLength);

            var characters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789";
            var message = new char[wordLength];

            for (int i = 0; i < message.Length; i++)
                message[i] = characters[random.Next(characters.Length)];

            return new string(message);
        }
    }
}