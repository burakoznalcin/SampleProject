namespace SampleProject.Model.Utilities.Authentication
{
    public class LoginResponseModel
    {
        public bool IsSuccess { get; set; } = false;
        public string Message  { get; set; }
        public string Token { get; set; }
    }
}
