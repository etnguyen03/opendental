using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using CodeBase;
using OpenDentBusiness;
using WpfControls.UI;

namespace OpenDental {
/*
You must implement Alt key for the Access Key on the button.
*/
	public partial class FrmJobGitBranch:FrmODBase {
		public string BranchName;

		public FrmJobGitBranch() {
			InitializeComponent();
			Load+=FrmJobGitBranch_Load;
			radioVersioned.Click+=radioVersioned_Click;
			radioUnversioned.Click+=radioUnversioned_Click;
			Lang.F(this);
		}
		
		private void FrmJobGitBranch_Load(object sender,EventArgs e) {
			textBranchName.Text=BranchName;
			textPath.Text="C:\\Development\\Versioned"; //default path
		}

		private void radioVersioned_Click(object sender,EventArgs e) {
			textPath.Text="C:\\Development\\Versioned";
		}

		private void radioUnversioned_Click(object sender,EventArgs e) {
			textPath.Text="C:\\Development\\Unversioned";
		}

		private void butCreateBranch_Click(object sender,EventArgs e) {
			Git git=new Git();
			git.RepoPath=textPath.Text;
			//Validate path
			if(!Directory.Exists(git.RepoPath)) {
				string message=Lang.g(this,"The directory")+" "+git.RepoPath+" "+Lang.g(this,"does not exist.");
				MsgBox.Show(message);
				return;
			}
			//Create and checkout local branch based on master then push to remote.
			UI.ProgressWin progressWin=new UI.ProgressWin();
			progressWin.StartingMessage="Checking for clean working tree...";
			progressWin.ActionMain=() => {
				//All of the git methods can throw exceptions
				if(!git.IsCleanWorkingTree()) {
					string message=Lang.g(this,"There are changes in your working tree. Commit or stash them before continuing.");
					throw new ODException(message);
				}
				ODEvent.Fire(ODEventType.ProgressBar,"Checking that branch doesn't already exist in remote...");
				if(git.RemoteBranchExists(BranchName)) {
					string message=Lang.g(this,"The branch origin/")+BranchName+" "+Lang.g(this,"already exists.");
					throw new ODException(message);
				}
				ODEvent.Fire(ODEventType.ProgressBar,"Checking out branch 'master'");
				git.Checkout("master");
				ODEvent.Fire(ODEventType.ProgressBar,"Pulling 'master'");
				git.Pull();
				ODEvent.Fire(ODEventType.ProgressBar,"Creating and checking out branch '"+BranchName+"'");
				git.CreateLocalBranchAndCheckout(BranchName);
				ODEvent.Fire(ODEventType.ProgressBar,"Pushing branch '"+BranchName+"' to remote");
				git.PushToRemote();
			};
			try {
				progressWin.ShowDialog();
			}
			catch(Exception ex) {//Let the engineer handle any git errors
				MsgBox.Show(ex.Message);
				return;
			}
			if(progressWin.IsCancelled) {
				return;
			}
			IsDialogOK=true;
		}
	}
}