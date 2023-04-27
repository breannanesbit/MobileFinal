using Shared;
using System.Net.Http.Json;

namespace Mobile_final.Services
{
    public interface IUserService
    {
        string Username { get; set; }
        string AuthenticationID { get; set; }
        Task NewUserEntry(string firstname, string lastname, string username);

        void SetUsername(string username);
        void SetAuthID(string authID);

        Task<List<User>> GetAllUsers();

        Task<User> GetCurrentUser();

        Task<List<Media>> GetUserMedia();

        Task<Category> GetCategory(int categoryId);

        Task<List<Media>> GetMostRecentUploaded();


        Task SubmitComment(int id, string comment);

        Task<List<Comment>> GetAllCommentsForMediaElement(int id);

        Task<Media> GetMediaByKey(string mediaKey);

        Task CreateAppointment(Appointment appoint);

        Task<List<Appointment>> GetAllAppointments();

        Task UploadNewFile(string type, string fileName, MultipartFormDataContent convertedForm);
    }
}