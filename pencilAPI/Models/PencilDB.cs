namespace pencilAPI.Models;

public class PencilDB {
	public string ConnectionString {get;set;} = null!;
	public string DatabaseName {get;set;} = null!;
	public string ?PencilCollection {get;set;} = "pencils";
}