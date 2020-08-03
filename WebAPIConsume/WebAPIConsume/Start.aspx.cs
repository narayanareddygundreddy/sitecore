using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
namespace WebAPIConsume
{
	public partial class Start : System.Web.UI.Page
	{
		HttpClient client;		
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				GetData();
			}
		}
		protected void btnInsert_Click(object sender, EventArgs e)
		{
			string url = "https://localhost:44327/api/Employee/Insert";
			CRUDOperations(url, "post");
			GetData();
		}

		protected void btnUpdate_Click(object sender, EventArgs e)
		{
			string url = "https://localhost:44327/api/Employee/Update";
			CRUDOperations(url, "put");
			GetData();
		}

		protected void btnDelete_Click(object sender, EventArgs e)
		{
			string url = "https://localhost:44327/api/Employee/Delete";
			CRUDOperations(url, "delete");
			GetData();
		}
		private void GetData()
		{
			string url = "https://localhost:44327/api/Employee/Get";
			client = new HttpClient();
			client.BaseAddress = new Uri(url);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpResponseMessage responseMessage = client.GetAsync(url).Result;
			if (responseMessage.IsSuccessStatusCode)
			{
				var responseData = responseMessage.Content.ReadAsStringAsync().Result;
				var employees = JsonConvert.DeserializeObject<List<Employee>>(responseData);
				EmpGridView.DataSource = employees;
				EmpGridView.DataBind();
			}
			else
			{
				lblMessage.Text = "WebAPI failed";
			}
		}
		private void CRUDOperations(string url, string type)
		{
			Employee emp = new Employee();
			emp.Id = Convert.ToInt32(txtbxId.Text.Trim());
			emp.Name = txtbxName.Text;
			emp.Position = txtbxPosition.Text;
			string jsonContent = JsonConvert.SerializeObject(emp);
			HttpRequestMessage request = new HttpRequestMessage();
			request.Content = new StringContent(jsonContent);
			request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			request.RequestUri = new Uri(url);
			switch (type)
			{
				case "post":
					request.Method = HttpMethod.Post;
					break;
				case "put":
					request.Method = HttpMethod.Put;
					break;
				default:
					request.Method = HttpMethod.Delete;
					break;
			}
			client = new HttpClient();
			HttpResponseMessage responseMessage = client.SendAsync(request).Result;
			if (responseMessage.IsSuccessStatusCode)
			{
				var responseData = responseMessage.Content.ReadAsStringAsync().Result;
				var resp = JsonConvert.DeserializeObject<String>(responseData);
				lblMessage.Text = resp;
			}
			else
			{
				lblMessage.Text = "WebAPI failed";
			}
			Clear();
		}
		private void Clear()
		{
			txtbxId.Text = string.Empty;
			txtbxName.Text = string.Empty;
			txtbxPosition.Text = string.Empty;
		}
	}
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Position { get; set; }
	}
}