using AlatechMachines.webAPI.Domains;

namespace AlatechMachines.webAPI
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get a user by email and password
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <returns>User or null</returns>
        User FindByEmailAndPassword(string username, string password);

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>User or null</returns>
        User FindById(int id);

        /// <summary>
        /// Deletes a userToken
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>True if deleted</returns>
        bool DeleteUserToken(int userId);

        /// <summary>
        /// Saves the session token
        /// </summary>
        /// <param name="token"></param>
        void SaveToken(string token, int id);

        /// <summary>
        /// Verify if token is valid
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="id">user id</param>
        /// <returns>true if is valid</returns>
        bool VerifyToken(string token, int id);
    }
}
