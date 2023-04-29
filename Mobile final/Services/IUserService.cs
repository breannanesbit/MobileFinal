using Shared;

namespace Mobile_final.Services
{
    public interface IUserService
    {
        string AuthenticationID { get; set; }
        string Username { get; set; }

        Task CreateAppointment(Appointment appoint);
        Task<List<Appointment>> GetAllAppointments();
        Task<List<Comment>> GetAllCommentsForMediaElement(int id);
        Task<List<User>> GetAllUsers();
        Task<Category> GetCategory(int categoryId);
        Task<User> GetCurrentUser();
        Task<Media> GetMediaByKey(string mediaKey);
        Task<List<Media>> GetMostRecentUploaded();
        Task<List<Media>> GetUserMedia();
        Task NewUserEntry(string firstname, string lastname, string username);
        void SetAuthID(string authID);
        void SetUsername(string username);
        Task SubmitComment(int id, string comment);
        Task SubmitLike(Media media, bool likeSelected);
        Task UploadNewFile(string type, string fileName, MultipartFormDataContent convertedForm);
    }
}