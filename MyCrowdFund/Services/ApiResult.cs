namespace MyCrowdFund.Services {
    public  class ApiResult<T>
  {
        public StatusCode ErrorCode { get; set; }

        public string ErrorText { get; set; }

        public T Data { get; set; }

        public bool Success => ErrorCode == StatusCode.Ok;

        public bool IsTrue { get; set; }

        public ApiResult()
        { }

        public ApiResult(StatusCode errorCode, string errorText ) {

            ErrorCode = errorCode;
            ErrorText = errorText;         
        }

        public ApiResult( bool value ) {

            IsTrue = value;
        }

        public static ApiResult<T> CreateSuccess(T data ) {

            return new ApiResult<T>()
            {
                Data = data,
                ErrorCode = StatusCode.Ok
            };
        }
    }
}
