using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static OpenDental.WindowsHookApiTaskbarInterop;

namespace OpenDental {
/*
The purpose of the MouseWatcher is to handle an edge case in Windows.
If a user has their taskbar hidden, then it would normally show when they hover at the bottom of the screen.
But it's a known Windows issue that a maximized window like OD can block this.
We already built a workaround years ago into FormODBase, but we replaced it with this MouseWatcher
	because a modal dialog sitting on top of a maximized window did not cause the code in that spot to get hit.

This is a performance critical class. 
We cache as many things as possible to reduce api calls,
and we hide as many calculations as possible behind inexpensive early return checks.
*/
	public static class MouseWatcher {
		public static bool IsRunning;
		///<summary>Delegates are often stored in a static field because passing a method directly could result in the method being garbage collected. By keeping a static reference,the program ensures the method remains alive for the duration of the hook.</summary>
		private static readonly DelegateLowLevelMouseProc _delegateLowLevelMouseProc=HookCallback;
		private static IntPtr _intPtrHookID=IntPtr.Zero;
		///<summary>Cache for the taskbar window handle of the primary monitor to avoid repeated FindWindow() calls.</summary>
		private static IntPtr _intPtrTaskbarWnd=IntPtr.Zero;
		///<summary>We remember which window had focus. We stole focus to show taskbar, so when they move away from task bar we need to assign focus back to that window. May or may not be OD.</summary>
		private static IntPtr _intPtrCachedForegroundWindow=IntPtr.Zero;
		private static int _heightTaskbar;

		//Specific values here are determined by the Windows API.
		//Names follow Windows API conventions.
		///<summary>Low-level mouse hook identifier used to monitor low-level mouse input events.</summary>
		private const int WH_MOUSE_LL=14;
		///<summary>Windows message identifier used to detect and respond to mouse movement events.</summary>
		private const int WM_MOUSEMOVE=0x0200;
		///<summary>Left mouse button down</summary>
		private const int WM_RBUTTONDOWN=0x0204;
		///<summary>Right mouse button down</summary>
		private const int WM_LBUTTONDOWN=0x0201;

		public static void Start(bool forceStart=false) {
			IsRunning=false;
			if(!forceStart) {
				APPBARDATA aPPBARDATA=new APPBARDATA();
				aPPBARDATA.cbSize=(uint)Marshal.SizeOf(aPPBARDATA);
				aPPBARDATA.hWnd=_intPtrTaskbarWnd;
				TaskbarState taskbarState=(TaskbarState)SHAppBarMessage((int)TaskBarCommand.ABM_GETSTATE,ref aPPBARDATA);
				bool isAutoHideEnabled=(taskbarState & TaskbarState.ABS_AUTOHIDE)!=0;
				if(!isAutoHideEnabled) {
					return; //No need to hook if auto-hide is disabled.
					//If user hides taskbar after starting OD, then this watcher will not be running and user will still have the issue.
				}
			}
			_intPtrTaskbarWnd=FindWindow("Shell_TrayWnd",null); //Get and cache taskbar handle. This will always be the "primary" taskbar. i.e.: the taskbar on the primary monitor. FindWindow returns IntPtr.Zero on fail.
			if(_intPtrTaskbarWnd==IntPtr.Zero) {
				return; //No need to hook if if we couldn't find the taskbar.
			}
			using Process processCur=Process.GetCurrentProcess();
			using ProcessModule processModuleCur=processCur.MainModule;
			_intPtrHookID=SetWindowsHookEx(WH_MOUSE_LL,_delegateLowLevelMouseProc,GetModuleHandle(processModuleCur.ModuleName),0);
			RECT rectTaskbar=new RECT();
			GetWindowRect(_intPtrTaskbarWnd,ref rectTaskbar);
			_heightTaskbar=rectTaskbar.bottom-rectTaskbar.top;
			Application.ApplicationExit+=Application_ApplicationExit;
			IsRunning=true;
		}

		public static void Application_ApplicationExit(object sender,EventArgs e) {
			Stop();
		}

		public static void Stop() {
			if(_intPtrHookID!=IntPtr.Zero) {
				UnhookWindowsHookEx(_intPtrHookID);
				_intPtrHookID=IntPtr.Zero;
			}
			IsRunning=false;
		}

		///<summary>This method is for handling auto-hide taskbar behavior in edge cases caused by maximized windows. Handles low-level mouse input events and determines whether to process or pass them through. Processing involves managing taskbar visibility when the mouse is near the screen edge and ensures proper foreground window focus.</summary>
		///<param name="eventCode">Hook event context, tells you whether to process or pass. Negative number means pass.</param>
		///<param name="actionType">Action/event type (e.g., mouse move, left-click, etc.). We check this against WinAPI constants.</param>
		///<param name="eventData">Pointer to a structure containing additional event details.</param>
		private static IntPtr HookCallback(int eventCode,IntPtr actionType,IntPtr eventData) {
			//Normal windows behavior is for the taskbar to unhide only on the monitor that the mouse is on.
			//Scenario 1: OD is on mon1. Mouse moves to bottom. Our code causes taskbar to show on mon1.
			//Scenario 2: OD is on mon2. Mouse moves to bottom. We don't need any code. Windows already works fine.
			//That means that our code is only needed for monitor 1.
			//About 8 kickouts down, we test to see if we are in scenario 2 and kickout before doing anything.
			if(eventCode<0) {
				return CallNextHookEx(_intPtrHookID,eventCode,actionType,eventData); //Kickout on invalid code.
			}
			if(actionType==(IntPtr)WM_LBUTTONDOWN || actionType==(IntPtr)WM_RBUTTONDOWN) {
				if(_intPtrCachedForegroundWindow!=_intPtrTaskbarWnd) {
					//Skip this section if taskbar has focus. We don't want to ever cache that as the foreground window.
					//This handles the scenario where user clicked on a button in the taskbar to open a different program.
					//At this point, the new window will have focus.
					//We want this variable to be updated to that new program window.
					//But this gets hit a LOT, even when not using taskbar.
					//It gets hit for any mouse down anywhere in any window, but not resource intensive.
					_intPtrCachedForegroundWindow=GetForegroundWindow(); //Cache new focus so we don't break windows focus behavior.
				}
				return CallNextHookEx(_intPtrHookID,eventCode,actionType,eventData);
			}
			if(actionType!=(IntPtr)WM_MOUSEMOVE) { //Verify that event is a mouse movement.
				return CallNextHookEx(_intPtrHookID,eventCode,actionType,eventData); //Kick out on scrollwheel, etc.
			}
			if(_intPtrTaskbarWnd==IntPtr.Zero) { //True=>Taskbar handle is invalid (Maybe explorer.exe crashed?)
				_intPtrTaskbarWnd=FindWindow("Shell_TrayWnd",null); //Reinitialize taskbar handle if it's invalid
				return CallNextHookEx(_intPtrHookID,eventCode,actionType,eventData); //Return here in case it's still invalid.
			}
			Point cursorPosition=Cursor.Position;
			Screen screenMouseLocation=Screen.FromPoint(cursorPosition);
			if(cursorPosition.Y<screenMouseLocation.Bounds.Bottom-(_heightTaskbar*1.8)) { //Mouse isn't near bottom of it's screen
				return CallNextHookEx(_intPtrHookID,eventCode,actionType,eventData);
			}
			IntPtr mainWindowHandle=Process.GetCurrentProcess().MainWindowHandle; //Get handle for main form of OD app.
			if(mainWindowHandle==IntPtr.Zero || !IsWindow(mainWindowHandle)) { //Safety check before Screen.FromHandle() call
				return CallNextHookEx(_intPtrHookID,eventCode,actionType,eventData);
			}
			Screen screenAppLocation=Screen.FromHandle(mainWindowHandle); //Screen where main app window is currently located.
			if(screenAppLocation.DeviceName!=screenMouseLocation.DeviceName) { //Mouse isn't on the same screen as our main form
				//this is supposed to kick out if we are on monitor2, but it's failing for unknown reasons.
				//Burton thinks it has something to do with aggregation of app windows into a single entity handle.
				return CallNextHookEx(_intPtrHookID,eventCode,actionType,eventData);
			}
			RECT rectTaskbar=new RECT(); //bounds of primary taskbar on primary screen.
			if(!GetWindowRect(_intPtrTaskbarWnd,ref rectTaskbar)) { //Was not able to get taskbarInfo, specifically its 'bounds'.
				return CallNextHookEx(_intPtrHookID,eventCode,actionType,eventData);
			}
			//On multi-monitor set-ups, Windows manages each taskbar segment individually, but the taskbar (Shell_TrayWnd) is
			// treated as a single entity by the system, even in multi-monitor setups where taskbars are extended.
			//If we want to exert full control over all of the system's taskbar(s), we would need to enumerate the various taskbars
			// when we start mousewatcher and map them to specific monitors, then use that map to determine which taskbar to show
			// based on which screen the mouse is currently on. Not difficult, but not necessary for our MouseWatcher.
			if(!(rectTaskbar.left<screenMouseLocation.Bounds.Right
				&& rectTaskbar.right>screenMouseLocation.Bounds.Left
				&& rectTaskbar.top<screenMouseLocation.Bounds.Bottom
				&& rectTaskbar.bottom>screenMouseLocation.Bounds.Top))
			{ //Primary Taskbar is not on the active screen. In other words, we are on monitor 2 (scenario 2 above)
				return CallNextHookEx(_intPtrHookID,eventCode,actionType,eventData);
			}
			bool isMouseAtBottom=cursorPosition.Y>=screenAppLocation.Bounds.Bottom-1; //Very bottom of screen (-1px)
			bool isMouseAboveTaskbar=cursorPosition.Y<screenAppLocation.Bounds.Bottom-(_heightTaskbar*1.2); //Slightly above taskbar
			bool hasValidCachedWindow=_intPtrCachedForegroundWindow!=IntPtr.Zero && IsWindow(_intPtrCachedForegroundWindow);
			if(isMouseAtBottom) {
				IntPtr intPtrActiveWindow=GetForegroundWindow(); //grabs whichever window has focus, which could be another app floating over OD.
				if(intPtrActiveWindow!=_intPtrTaskbarWnd) { //if not taskbar
					_intPtrCachedForegroundWindow=intPtrActiveWindow; //Cache active/focused window
				}
				SetWindowToForeground(_intPtrTaskbarWnd); //Set taskbar visible.
			}
			else if(isMouseAboveTaskbar && hasValidCachedWindow) {
				SetWindowToForeground(_intPtrCachedForegroundWindow);
				_intPtrCachedForegroundWindow=IntPtr.Zero; //Release cache
			}
			return CallNextHookEx(_intPtrHookID,eventCode,actionType,eventData);
		}

		private static void SetWindowToForeground(IntPtr hWnd) {
			uint foregroundThread=GetWindowThreadProcessId(_intPtrCachedForegroundWindow, IntPtr.Zero);
			uint currentThread=GetCurrentThreadId();
			if(foregroundThread!=currentThread) {
				//Attach the current thread to the foreground window thread
				AttachThreadInput(currentThread,foregroundThread,fAttach:true);
				SetForegroundWindow(hWnd);
				//Detach the threads
				AttachThreadInput(currentThread,foregroundThread,fAttach:false);
			}
			else {
				SetForegroundWindow(hWnd);
			}
		}
	}
}
