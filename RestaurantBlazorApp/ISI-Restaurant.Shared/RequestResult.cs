namespace ISI_Restaurant.Shared
{
    public class RequestResult<T>
    {
        public Status Status { get; private set; }
        public T Result { get; private set; }

        public RequestResult(Status status, T result)
            => (Status, Result) = (status, result);

        public RequestResult(Status status)
            => (Status, Result) = (status, default(T));
    }
    public enum Status
    {
        OK,
        Waiting,
        Error
    }
}
