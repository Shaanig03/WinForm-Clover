
	This software that I'm sharing is my personal control panel for quick various tasks, tasks such as alarm, and the ability to execute methods by typing commands from a command bar, picture notes to show a picture each day to remind myself of something, and opening a text file to note down things quickly all from keyboard shortcuts, you press Alt+1 to open the main UI, and Alt+2 for the command bar, you can add your own commands with methods or implement your own features to this software through the project .sln or through mods, the main project folder is "CPLib" if you wana make changes, this software was built on "Windows 10", ".NET Framework 4.7.2"
				
				
		features:
		
			- alarm system
			
			- command bar
			
			- mods
			
			- picture notes
			
			
				main:
				
					- press "Alt+1" to bring up the main UI
					
					- press "Alt+3" to bring up the command bar 
					
					- you can change the controls from "files/settings.xml", "config/keys", after changing the controls close the application or press "Alt+~" to restart
					
					- press "Alt+~" to restart the application
				
				alarm system:
				
					- alarms are added by typing in the alarm textbox, below textbox is for the alarm's description, if the description is empty then the name will be displayed as the description
					
					- when adding an alarm, you can choose a picture or a specific sound for that alarm, picture and sound can be a file or a folder
					
					- alarms are stored in "files/alarms.xml"
					
					- each alarm element is in "alarms.xml", "list/alarms/alarm" has 8 elements
					8
						- name
						
						- description
						
						- the days which this alarm would be active 
						
						- alarm's time 
						
						- alarm repeats
						
						- alarm's picture
						
						- alarm's sound
						
					- alarms are added by typing in the alarm textbox in the following format:
					
						format: <alarm_name> <alarm_time> <alarm_period>
						
						examples:
						
							wake wakey 5:00 AM
							
							feed fish 12:00 PM
							
							download this game 2:00 PM
							
					
					- press [+] to add alarm after typing in the textbox
					
					- press [-] to remove the selected alarm from the listbox
					
					- alarm's volume can be changed 	

				
				
				command bar:
				
					- you can open up the command bar by pressing Alt+1, can be changed through "files/settings.xml", "config/key/hide_and_show_cmdbar"
					
					- enter a command to execute the command's method
					
					- you can add your own commands through mods
					
				
				
				mods:
				
					- mods are stored in "Files/Mods"
					
					- a mod folder inside "Mods" must have a "mod.xml" with the elements:
					
					<mod>
						<name>mod's name</name>
						<desc>mod's description</desc>
					</mod>
					
					- .dll/assembly files stored in mod folders are loaded on start
					
					- .dll/assembly files can have a method named "OnLoad" which is executed on start 
					
					- inside "OnLoad" method, you can add custom commands by referencing "CPLib.dll" and using "CPCmdBar.RegisterCmd"			
		
					
					notes:
					
						adding a command:
						
							- open up Visual Studio

								- create a new project
								
								- choose Class Library (.NET framework)
								
							- from the Solution Explorer, right click your "References" and add "CPLib.dll" as a reference, and include "using CPLib;" at the top of your class
							
							- before building click "CPLib" from "References" and set "Copy Local" to false from the "Properties"
							
							- create a folder inside mods folder
							
							- click "Project" from the top menu and open up the project's "Properties", then click "Build", scroll down and look for "Output Path", select your mod's folder
							
							- create a static class, inside it create a static void method with no parameters named "OnLoad"
							
							- use CPCmdBar.RegisterCmd() to register a command inside "OnLoad"
							
							- see ExampleMod/examplemod.cs
							
				picture notes:
				
					- pressing [Picture Note] will display a picture note
					
					- pressing [Add Picture Note] with a name written in the alarm textbox will add a picture note
					
					- pressing [Remove Picture Note] with a name written in the alarm textbox will remove that picture note 
					
					- after a picture note is displayed by pressing [Picture Note], you cannot display it again, you have to wait for a new day to display it again ^_^
					
					- picture notes are stored in "files/vars.xml", if you want a picture note to be removed then delete it from "vars.xml" or enter it's name and use the button to delete it
				
				other:
				
					quick note:
			
						- open up a note file anytime by pressing Alt+Q, you change the file through "settings.xml", "config/paths/quickNote"
						
						- it doesn't have to be a note file it can be a .exe as well, but I use a note file for noting down things quickly, makes things easy for me ^_^
				
				
				settings.xml:
				
					config:
					
						keys:
	
							- key codes https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=net-5.0
							
							- modifier:
							
								- "1": Alt+Key
								
								- "0": Key
								
								// modifier : Alt = 1, Ctrl = 2, Shift = 4, Win = 8
								// Compute the addition of each combination of the keys you want to be pressed
								// ALT+CTRL = 1 + 2 = 3 , CTRL+SHIFT = 2 + 4 = 6...
							
						paths:
						
							- quickNote path
							
						
						on windows start:
						
							- this application will run on Windows start
						
						
		notes:
		
		
			#issue [issues with keys and controls]
			--------------------
			
			- this application uses (RegisterHotKey) to create global keys
			
				// DLL libraries used to manage hotkeys
				[DllImport("user32.dll")] 
				public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
				[DllImport("user32.dll")]
				public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
				
				
			- if a different software has suddenly issues with keys and controls after opening this, try changing the "KeyManager.keys_id" to a random number like 523578, 34234, 35235
			
			- open CPLIb.sln and in Form Load change "KeyManager.keys_id" to a random number if you encounter this issue but it shouldn't happen and it should be extremely rare

			
			