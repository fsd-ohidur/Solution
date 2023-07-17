namespace Solution.Web.HR.Models
{
	public class ResponseDto
	{
		//public int MyProperty { get; set; }
		public bool IsSuccess { get; set; } = true;
		public object Result { get; set; }
		public string DisplayMessage { get; set; } = "";
		public List<string> ErrorMessages { get; set; }
	}
}
