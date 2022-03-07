namespace AlatechMachines.webAPI.utils
{
    public class Criptography
    {
        public string Criptografar(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public bool VerificarHash(string hash, string senha)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}
