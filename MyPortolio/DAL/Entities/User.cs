namespace MyPortfolio.DAL.Entities
{
    public class User
    {

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
		public string? NewPassword { get; internal set; }
        public string Image { get; set; }
        public string Cv { get; set; }

	}
}
