namespace Solution.CrossCutting.Security
{
	public interface IHash
	{
		string Generate(string value);
	}
}
