using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Web.WebView2.Core;
using OpenDentBusiness;
using WpfControls.UI;

namespace OpenDental {
	public partial class FrmHelpBrowser:FrmODBase {
		private static string _stableVersion;
		private bool _hasInitialized=false;

		///<summary>If enableUI is set to false, then it just shows them the Help Feature page and doesn't let them click.</summary>
		public void EnableUI(bool enableUI) {
			//only intended to run once.
			if(!enableUI) {
				//Locks web browser UI on the form.
				webBrowserManual.IsEnabled=false;
				webView2.IsEnabled=false;
				toolBarMain.IsEnabled=false;
			}
		}

		///<summary>Gets the latest stable version in the format of "XXX" (205,194,etc).</summary>
		private static string GetStableVersion() {
			if(_stableVersion==null) {
				_stableVersion=OpenDentalHelp.ODHelp.GetStableVersion();
			}
			return _stableVersion;
		}

		public FrmHelpBrowser() {
			InitializeComponent();
			webBrowserManual.Navigated+=WebBrowserManual_Navigated;
			webView2.NavigationCompleted+=WebView2FAQ_NavigationCompleted;
			HasHelpButton=false;
			//webBrowserManual.ScriptErrorsSuppressed=true;
			//webBrowserFAQ.ScriptErrorsSuppressed=true;
			Load+=FrmHelpBrowser_Load;
			FormClosing+=FrmODBase_FormClosing;
		}

		private void FrmHelpBrowser_Load(object sender,EventArgs e) {
			LayoutToolBar();
			StartMaximized=true;
		}

		public void LayoutToolBar() {
			toolBarMain.Clear();
			if(PrefC.IsODHQ && Security.IsAuthorized(EnumPermType.FAQEdit,true)) {
				ToolBarButton toolBarButtonManageFaqs=new ToolBarButton();
				toolBarButtonManageFaqs.Text=Lans.g(this,"Manage FAQ's");
				toolBarButtonManageFaqs.Click+=ManageFAQs_Click;
				toolBarMain.Add(toolBarButtonManageFaqs);
				ToolBarButton toolBarButtonAddFaqs=new ToolBarButton();
				toolBarButtonAddFaqs.Text=Lans.g(this,"Add FAQ for Current Page");
				toolBarButtonAddFaqs.Click+=AddFAQ_Click;
				toolBarMain.Add(toolBarButtonAddFaqs);
			}
			ToolBarButton toolBarButtonBack=new ToolBarButton();
			toolBarButtonBack.Text=Lans.g(this,"Back");
			toolBarButtonBack.Icon=EnumIcons.ArrowLeft;
			toolBarButtonBack.Click+=Back_Click;
			toolBarMain.Add(toolBarButtonBack);
			ToolBarButton toolBarButtonForward=new ToolBarButton();
			toolBarButtonForward.Text=Lans.g(this,"Forward");
			toolBarButtonForward.Icon=EnumIcons.ArrowRight;
			toolBarButtonForward.Click+=Forward_Click;
			toolBarMain.Add(toolBarButtonForward);
		}

		public void GoToPage(string manualPageUrl) {
			webBrowserManual.Navigate(manualPageUrl);
		}

		///<summary>When the web browser navigates we attempt to determine if it has navigated to a manual page. If it has,
		///we parse it and send a new request for the associated faqs. If it navigates to a page not recognized, we hide
		///the faq browser pannel.</summary>
		private void WebBrowserManual_Navigated(object sender,NavigationEventArgs e) {
			ShowAndLoadFaq(e.Uri.ToString());
		}

		private void WebView2FAQ_NavigationCompleted(object sender,CoreWebView2NavigationCompletedEventArgs e) {
			//This event gets fired for every iframe in a page to load.  
			//We only care about the webBrowserFAQ.Url because e.Url will be iframe urls in addition to the original one.
			if(webView2.GetUri().Query.Contains("results=empty")) {
				ToggleFaqPanel(true);
			}
			else {
				ToggleFaqPanel(false);
			}
		}

		///<summary>Either shows or hides the FAQ panel depending on the URL passed in.
		///If the URL is a manual page, then the panel will navigate (load) the corresponding FAQ page.</summary>
		private async void ShowAndLoadFaq(string url) {
			if(!IsManualPageUrl(url)) {
				ToggleFaqPanel(true);
				return;
			}
			ToggleFaqPanel(false);
			if(!_hasInitialized) {
				try {
					await webView2.Init();
					_hasInitialized=true;
				}
				catch(Exception ex) {
					FriendlyException.Show("Error loading window. Run in x86 for debug.",ex);
					Close();
					return;
				}
			}
			webView2.Navigate(ManualUrlToFaqUrl(url));
		}

		private void ToggleFaqPanel(bool hideFaqPanel) {
			splitContainer.SetCollapsed(splitterPanel2,doCollapse:hideFaqPanel);
		}

		///<summary>A helper method that parses the manual page url into the associated faq page url. Should Jordan ever change
		///the manual publisher's routing pattern this will break.</summary>
		private string ManualUrlToFaqUrl(string manualPageUrl) {
			string version="";
			string page="";
			//The url params for the manual is /manualversion/pagename.html
			string[] urlParams=manualPageUrl.Replace("https://www.opendental.com/","").Split('/');
			if(urlParams[0]=="manual") {//"manual" signifies the stable version
				version=Faqs.GetStableManualVersion().ToString();
			}
			else {//for example '/manual183/'
				version=urlParams[0].Replace("manual","");
			}
			page=urlParams[1].Replace(".html","");
			return $"https://opendentalsoft.com:1943/ODFaq/{page}/{version}";
		}
		
		///<summary>Helper method that tries to determine if the navigated url is a manual page. To be honest,
		///this method is just hacking apart the url and returning false as soon as it finds something that doesn't fit
		///the manual page url pattern. This will definitely have to be added upon in the future.</summary>
		private bool IsManualPageUrl(string url) {
			if(!url.StartsWith("https://www.opendental.com/manual")) {
				return false;
			}
			if(url.EndsWith("searchmanual.html")) {//The user is most likely to hit 'search' from the help browser
				return false;
			}
			return true;
		}

		private void ManageFAQs_Click(object sender,EventArgs e) {
			MsgBox.Show("11/10/2024 Jordan - FAQs are currently undergoing an overhaul and cannot be edited. I estimate that version 244 will be released as beta in early December, and FAQ editing will be possible soon after that.");
			return;
			string url="";
			string programVersion="";
			if(webBrowserManual!=null) {
				url=GetPageTopicFromUrl(webBrowserManual.GetUri().ToString());
			}
			if(url.Contains("preferences")) {
				MsgBox.Show(this,"You cannot alter any Preference faqs. Preferences have a custom information table instead of faqs.");
				return;
			}
			if(!string.IsNullOrWhiteSpace(url)) {
				programVersion=FormatVersionNumber(webBrowserManual.GetUri().ToString());
			}
			FrmFaqPicker frmFaqPicker=new FrmFaqPicker(url,programVersion);
			frmFaqPicker.ShowDialog();
		}

		///<summary>
		///	Returns an empty string if the url passed in is empty or is not a manual page or if the url is formatted in a way we don't expect. (See IsManualPageUrl)
		///	Otherwise the manual page subject will be returned.
		///</summary>
		private string GetPageTopicFromUrl(string url) {
			//The url is expected to in this format: https://opendental.com/manual205/claimedit.html. We would just want the "claimedit" piece.
			if(string.IsNullOrWhiteSpace(url) || !IsManualPageUrl(url)) {
				return "";
			}
			int startIndex=url.LastIndexOf('/')+1;//we want to exclude the '/' so we go one position past the value of startIndex
			int length=(url.LastIndexOf('.')-startIndex);
			if(length<0) {
				length=0;
			}
			string retVal=url.Substring(startIndex,length);
			return retVal;
		}

		///<summary>Parses the version from the manual page url. Checks to make sure we're on a legitimate manual topic page first and returns an empty string if not.</summary>
		private string FormatVersionNumber(string url) {
			if(string.IsNullOrWhiteSpace(url) || !IsManualPageUrl(url)) {
				return "";
			}
			string retVal=new string(url.Where(x=>Char.IsDigit(x)).ToArray());
			if(string.IsNullOrWhiteSpace(retVal)) {//We're on a manual page for stable so no version number will be present. In that case, grab the latest stable from the mp database.
				retVal=GetStableVersion();
			}
			return retVal;
		}

		///<summary>Allows the user to go back in navigation of web pages if possible.</summary>
		private void Back_Click(object sender,EventArgs e) {
			if(!webBrowserManual.CanGoBack()) {//If nothing to navigate back to in history, do nothing
				return;
			}
			Cursor=Cursors.Wait;//Is set back to default cursor after the document loads inside the browser.
			//Application.DoEvents();//To show cursor change.
			webBrowserManual.GoBack();
			ShowAndLoadFaq(webBrowserManual.GetUri().ToString());
			Cursor=Cursors.Arrow;//Default didn't exist
		}

		///<summary>Allows the user to go forward in navigation of web pages if possible.</summary>
		private void Forward_Click(object sender,EventArgs e) {
			if(!webBrowserManual.CanGoForward()) {//If nothing to navigate forward to in history, do nothing
				return;
			}
			Cursor=Cursors.Wait;//Is set back to default cursor after the document loads inside the browser.
			//Application.DoEvents();//To show cursor change.
			webBrowserManual.GoForward();
			ShowAndLoadFaq(webBrowserManual.GetUri().ToString());
			Cursor=Cursors.Arrow;//Default didn't exist
		}

		private void AddFAQ_Click(object sender,EventArgs e) {
			MsgBox.Show("11/10/2024 Jordan - FAQs are currently undergoing an overhaul and cannot be edited. I estimate that version 244 will be released as beta in early December, and FAQ editing will be possible soon after that.");
			return;
			string url="";
			if(webBrowserManual!=null) {
				url=webBrowserManual.GetUri().ToString();
			}
			if(url.Contains("preferences")) {
				MsgBox.Show(this,"You cannot alter any Preference faqs. Preferences have a custom information table instead of faqs.");
				return;
			}
			FrmFaqEdit frmFaqEdit=new FrmFaqEdit();
			frmFaqEdit.FaqCur=new Faq();
			frmFaqEdit.FaqCur.IsNew=true;
			frmFaqEdit.IsQuickAdd=true;
			frmFaqEdit.FaqCur.ManualPageName=GetPageTopicFromUrl(url);
			frmFaqEdit.FaqCur.ManualVersion=PIn.Int(FormatVersionNumber(url));
			frmFaqEdit.ShowDialog();
		}

		private void FrmODBase_FormClosing(object sender,CancelEventArgs e) {
			webView2.Dispose();
		}
	}
}
