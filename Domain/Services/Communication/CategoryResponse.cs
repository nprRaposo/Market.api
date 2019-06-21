namespace Market.Api.Domain.Services.Communication
{
    public class ActionResponse <T> where T: class
    {
        public T Entity { get; private set; }
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        /// <summary>
        /// Creates a success response. 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="entity"></param>
        public ActionResponse(T entity)
        {
            Success = true;
            Entity = entity;
        }

        /// <summary>
        /// Creates an error response
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public ActionResponse(string message)
        {
            Success = false;
            Message = message;
            Entity = null;
        }
    }
}
