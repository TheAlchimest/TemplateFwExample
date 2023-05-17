using System;

namespace TemplateFwExample.Domain.Models
{
    public class ActionLog
    {
        private ActionLog()
        {

        }

        public ActionLog(
            Guid userId,
            string userIdNumber,
            string userName,
            string token,
            ActionLogActionType actionType,
            string requestData,
            string responseData)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            UserIdNumber = userIdNumber;
            UserName = userName;
            Token = token;
            ActionType = actionType;
            RequestData = requestData;
            ResponseData = responseData;
            CreationDate = DateTime.Now;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserIdNumber { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public ActionLogActionType ActionType { get; set; }
        public string RequestData { get; set; }
        public string ResponseData { get; set; }
        public DateTime CreationDate { get; set; }

        public enum ActionLogActionType
        {
            SendSMS,
            SendEmail,
            GetUserNumber,
            GetUserAddress
        }
    }
}
