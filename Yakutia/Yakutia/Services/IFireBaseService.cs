namespace Yakutia.Services
{
	public interface IFireBaseService
	{
		string GetToken(string email);

		void DeleteInstance();
	}
}
