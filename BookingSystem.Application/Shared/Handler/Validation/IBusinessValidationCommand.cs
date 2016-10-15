using System.Collections.Generic;
using Abp.Domain.Entities;

namespace BookingSystem.Shared.Handler.Validation
{
    public class ValidationCommandResult
    {
        public static ValidationCommandResult Valid()
            => new ValidationCommandResult(true);

        public static ValidationCommandResult NotValid(string invalidMessage)
            => new ValidationCommandResult(false, invalidMessage);

        public bool IsValid { get; }

        public List<string> Messages { get; }

        private ValidationCommandResult(bool isValid, string message = "")
        {
            IsValid = isValid;
            Messages = new List<string>();
            if (!string.IsNullOrEmpty(message)) Messages.Add(message);
        }

        public void AddMessage(string message)
            => Messages.Add(message);
    }
    
    public interface IBusinessRule<in TCommand, TEntity>
        where TCommand : ICommand<TEntity>
        where TEntity : Entity
    {
        ValidationCommandResult IsValid(TCommand command);
    }
}
