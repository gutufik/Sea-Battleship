using System;
using System.Net;
using Common;
using Core;

namespace Network
{
    public class Connection
    {
        public Server Server { get; set; }
        public Client Client { get; set; }
        /// <summary>
        /// Создание лобби
        /// </summary>
        public void CreateLobby()
        {
            try
            {
                Server = new Server();
                IPAddress ip = ServerUtils.GetInternalIp();
                Server.Create(ip);
                Server.WaitConnection();
            }
            catch (Exception e)
            {
                LogService.Trace($"Ошибка создания лобби: {e}");
            }
        }
        /// <summary>
        /// Вход в лобби
        /// </summary>
        /// <param name="ipObj"></param>
        public void JoinToLobby(object ipObj)
        {
            IPAddress ip = (IPAddress)ipObj;
            Client = new Client();
            Client.Connect(ip);
        }
        /// <summary>
        /// Отправить операцию на север
        /// </summary>
        /// <param name="role"></param>
        /// <param name="operType"></param>
        /// <param name="oper"></param>
        public void SendOperation(PlayerRole role, OpearationTypes operType, IOperation oper)
        {
            if (role == PlayerRole.Server)
            {
                Server.SendResponse(operType, oper);
            }
            else
            {
                Client.SendRequest(operType, oper);
            }
        }
        /// <summary>
        /// Получить результат операции
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public Tuple<OpearationTypes, IOperation> GetOperation(PlayerRole role)
        {
            return role == PlayerRole.Server ? Server.GetRequest() : Client.GetResponse();
        }
    }
}
