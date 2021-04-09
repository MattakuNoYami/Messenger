﻿using System;
using SharedLibrary;
using System.Net;
using System.Net.Sockets;
using System.Configuration;

namespace Client
{
    class Program
    {
        static RequestDispatcher dispatcher;
        static Socket socket;
        static IPEndPoint endPoint;
        static Channel channel;
        static void Main(string[] args)
        {
            Pocket pocket = new Pocket("Auth");
            Console.WriteLine(pocket.Signature);

            dispatcher = new RequestDispatcher();
            dispatcher.Add(Auth);
            dispatcher.Add(Register);

            endPoint = new IPEndPoint(IPAddress.Loopback, 1000);
            socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endPoint);

            channel = new Channel(socket);

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    dispatcher.Execute(input);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }

        [Route("Auth")]
        static void Auth() 
        {
            Console.WriteLine("Запрос Авторизации");
            Pocket pocket = new Pocket("Auth");
            Console.Write("Логин: ");
            pocket.Message.Add(Console.ReadLine());
            Console.Write("Пароль: ");
            pocket.Message.Add(Console.ReadLine());
            channel.Send(pocket);
            Pocket response = channel.Recieve();
            Console.WriteLine((bool)response.Message[0]);
        }

        [Route("Register")]
        static void Register() 
        {
            Console.WriteLine("Запрос Регистрации");
            Pocket pocket = new Pocket("Register");
            Console.Write("Логин: ");
            pocket.Message.Add(Console.ReadLine());
            Console.Write("Пароль: ");
            pocket.Message.Add(Console.ReadLine());
            channel.Send(pocket);
            Pocket response = channel.Recieve();
            Console.WriteLine((bool)response.Message[0]);
        }
    }
}