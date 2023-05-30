namespace DION_BTVN.Utilities
{
    public class DionResponse
    {
        public int Status { get; set; }
        public string Title { get; set; }
        public object Resources { get; set; }
        public object Errors { get; set; }

        private DionResponse()
        {
        }

        public static DionResponse Success()
        {
            return new DionResponse()
            {
                Status = 200,
                Title = "Success"
            };
        }

        public static DionResponse Success<T>(T data) where T : class
        {
            return new DionResponse()
            {
                Status = 200,
                Title = "Success",
                Resources = data
            };
        }

        public static DionResponse CountLoginFail<T>(T data, int count) where T : class
        {
            return new DionResponse()
            {
                Status = 202,
                Title = "Tài khoản hoặc mật khẩu không đúng.",
                Resources = data
            };
        }

        public static DionResponse Locked<T>(T data) where T : class
        {
            return new DionResponse()
            {
                Status = 202,
                Title = "LOCKED",
                Resources = data
            };
        }



        public static DionResponse Error(int status, string title, object errors)
        {
            return new DionResponse()
            {
                Status = status,
                Title = title,
                Errors = errors
            };
        }

        public static DionResponse NotFound(string title, object errors)
        {
            return Error(404, title, errors);
        }

        public static DionResponse BadRequest(object errors)
        {
            return Error(403, "BadRequest", errors);
        }
    }
}
