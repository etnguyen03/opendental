using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenDental.UI{ 

	///<summary></summary>
	public class ODToolBarButton {
		///<summary>The bounds of this button.</summary>
		public Rectangle Bounds;
		public Menu DropDownMenu;
		public ContextMenuStrip ContextMenuStripDropDown;
		public bool Enabled=true;
		public EnumIcons Icon;
		private Bitmap _bitmap;
		public int ImageIndex=-1;
		///<summary>Only used if style is ToggleButton.</summary>
		public bool IsTogglePushed;
		public bool IsRed;
		///<summary>A one or two character notification string which will show just above the dropdown arrow when dropDownMenu is not null.  If null or empty, the dropdown arrow background will draw in the typical color and no text will show.  Otherwise the dropdown rectangle will use the notification color background.</summary>
		public string NotificationText;
		public int PageMax;		
		public int PageValue;
		public ODToolBarButtonStyle Style=ODToolBarButtonStyle.NormalButton;
		///<summary>IsTogglePushed, Enabled, and isRed are handled separately</summary>
		public ToolBarButtonState State=ToolBarButtonState.Normal;
		///<summary>Holds extra information about the button, so we can tell which button was clicked.  Tag will be set to a string for module specific buttons and will be a Program object for program link buttons.</summary>
		public object Tag="";
		public string Text="";
		public string ToolTipText="";
		///<summary>DateTime of the last time this button was clicked. Used  to stop double clicking from firing 2 events.</summary>
		public DateTime DateTimeLastClicked;
		public EventHandler EventHandlerClick;

		///<summary></summary>
		public ODToolBarButton(){
			
		}

		///<summary>Deprecated because we're moving away from ImageLists.  buttonTag will be a string for most buttons and will be a Program object for program link buttons.</summary>
		public ODToolBarButton(string buttonText,int buttonImageIndex,string buttonToolTip,Object buttonTag){
			ImageIndex=buttonImageIndex;
			Text=buttonText;
			ToolTipText=buttonToolTip;
			Tag=buttonTag;
		}

		///<summary>ButtonTag will be a string for most buttons and will be a Program object for program link buttons.</summary>
		public ODToolBarButton(string buttonText,EnumIcons icon,string buttonToolTip,Object buttonTag){
			Text=buttonText;
			Icon=icon;
			ToolTipText=buttonToolTip;
			Tag=buttonTag;
		}

		///<summary></summary>
		public ODToolBarButton(string buttonText,EventHandler eventHandlerClick,EnumIcons icon=EnumIcons.None,string buttonToolTip=null,Object buttonTag=null){
			Text=buttonText;
			Icon=icon;
			ToolTipText=buttonToolTip;
			Tag=buttonTag;
			EventHandlerClick+=eventHandlerClick;
		}

		///<summary>Usually just used for Separators,</summary>
		public ODToolBarButton(ODToolBarButtonStyle buttonStyle){
			Style=buttonStyle;
		}

		public void Dispose(){
			_bitmap?.Dispose();
		}

		///<summary>Rarely, we might want to set an image manually.</summary>
		public Bitmap Bitmap{
			get{
				return _bitmap;
			}
			set{
				_bitmap?.Dispose();
				_bitmap=value;
			}
		}

	}

	///<summary>IsTogglePushed, Enabled, and isRed are handled separately</summary>
	public enum ToolBarButtonState{
		///<summary>0.</summary>
		Normal,
		///<summary>Mouse is hovering over the button and the mouse button is not pressed.</summary>
		Hover,
		///<summary>Mouse was pressed over this button and is still down, even if it has moved off this button or off the toolbar.</summary>
		Pressed,
		///<summary>In a dropdown button, only the dropdown portion is pressed. For hover, the entire button acts as one, but for pressing, the dropdown can be pressed separately.</summary>
		DropPressed
	}

	///<summary>Just like Forms.ToolBarButtonStyle, except includes some extras.</summary>
	public enum ODToolBarButtonStyle{
		///<summary>A button with a dropdown list on the right.</summary>
		DropDownButton,
		///<summary>A standard button</summary>
		NormalButton,
		///<summary></summary>
		Separator,
		///<summary>Toggles between pushed and not pushed when clicked on.</summary>
		ToggleButton,
		///<summary>Not clickable. Just text where a button would normally be. Can also include an image.</summary>
		Label,
		///<summary>Editable textbox that fires page nav events. Includes a label after the textbox to show total pages.</summary>
		PageNav,
	}

}






