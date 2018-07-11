using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Configuration;

using Varan.Security.Cryptography.DPAPI;

namespace DPAPIClient {
	public class Default : System.Web.UI.Page {
		protected System.Web.UI.WebControls.TextBox txtDataToEncrypt;
		protected System.Web.UI.WebControls.TextBox txtEncryptedData;
		protected System.Web.UI.WebControls.TextBox txtDecryptedData;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnEncrypt;
		protected System.Web.UI.WebControls.Button btnDecrypt;
		protected System.Web.UI.WebControls.Button btnDecryptConfig;
		protected System.Web.UI.WebControls.Label lblError;
	
		private void Page_Load(object sender, System.EventArgs e) {
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
			this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
			this.btnDecryptConfig.Click += new System.EventHandler(this.btnDecryptConfig_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnEncrypt_Click(object sender, System.EventArgs e) {
			DPAPI dp = new DPAPI( 
				DPAPI.Store.USE_MACHINE_STORE );
			try 
			{
				byte[] dataToEncrypt = 
					Encoding.ASCII.GetBytes(txtDataToEncrypt.Text);
				// Not passing optional entropy in this example
				// Could pass random value (stored by the application) for added
				// security when using DPAPI with the machine store.
				txtEncryptedData.Text =
					Convert.ToBase64String(dp.Encrypt(dataToEncrypt,null));
			}
			catch(Exception ex) 
			{
				lblError.ForeColor = Color.Red;
				lblError.Text = "Exception.<br>" + ex.Message;
				return;
			}
			lblError.Text = "";
		}

		private void btnDecrypt_Click(object sender, System.EventArgs e) {
			DPAPI dp = new 
				DPAPI(DPAPI.Store.USE_MACHINE_STORE);
			try 
			{
				byte[] dataToDecrypt = 
					Convert.FromBase64String(txtEncryptedData.Text);
				// Optional entropy parameter is null. 
				// If entropy was used within the Encrypt method, the same entropy
				// parameter must be supplied here
				txtDecryptedData.Text = 
					Encoding.ASCII.GetString(dp.Decrypt(dataToDecrypt,null));
			}
			catch(Exception ex) 
			{
				lblError.ForeColor = Color.Red;
				lblError.Text = "Exception.<br>" + ex.Message;
				return;
			}
			lblError.Text = "";
		}

		private void btnDecryptConfig_Click(object sender, System.EventArgs e) {
			DPAPI dp = new 
				DPAPI(DPAPI.Store.USE_MACHINE_STORE);
			try 
			{
				string appSettingValue =
					ConfigurationSettings.AppSettings["connectionString"];
				byte[] dataToDecrypt = Convert.FromBase64String(appSettingValue);
				string connStr = Encoding.ASCII.GetString(
					dp.Decrypt(dataToDecrypt,null));
				txtDecryptedData.Text = connStr;
			}
			catch(Exception ex) 
			{
				lblError.ForeColor = Color.Red;
				lblError.Text = "Exception.<br>" + ex.Message;
				return;
			}
			lblError.Text = "";
		}
	}
}
